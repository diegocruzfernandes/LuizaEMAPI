using FluentValidator;
using LuizaEM.Api.Security;
using LuizaEM.Domain.Commands.UserCommands;
using LuizaEM.Domain.Entities;
using LuizaEM.Domain.Services;
using LuizaEM.Domain.Shared;
using LuizaEM.Infra.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LuizaEM.Api.Controllers
{
    public class AccountController : BaseController
    {
        private User _user;
        private readonly IUserAppService _service;
        private readonly TokenOptions _tokenOptions;
        private readonly JsonSerializerSettings _serializerSettings;

        public AccountController(IOptions<TokenOptions> jwtOptions, IUserAppService service, IUow uow) : base(uow)
        {
            _service = service;
            _tokenOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_tokenOptions);

            _serializerSettings = new JsonSerializerSettings
            {  
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
        
        [HttpPost]
        [AllowAnonymous]
        [Route("v1/authenticate")]
        public async Task<IActionResult> Post([FromForm] AuthenticateUserCommand command)
        {
            if (command == null)
                return await Response(null, new List<Notification> { new Notification("User", "Usuário ou senha inválidos") });

            var identity = await GetClaims(command);
            if (identity == null)
                return await Response(null, new List<Notification> { new Notification("User", "Usuário ou senha inválidos") });

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, command.Email),
                new Claim(JwtRegisteredClaimNames.NameId, command.Email),
                new Claim(JwtRegisteredClaimNames.Email, command.Email),
                new Claim(JwtRegisteredClaimNames.Sub, command.Email),
                new Claim(JwtRegisteredClaimNames.Jti, await _tokenOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_tokenOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                identity.FindFirst("LuizaEMAPI")
            };

            var jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: claims.AsEnumerable(),
                notBefore: _tokenOptions.NotBefore,
                expires: _tokenOptions.Expiration,
                signingCredentials: _tokenOptions.SiniginCredential);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            EPermission permission = (EPermission)_user.Permission;
            var response = new
            {
                token = encodedJwt,
                expires = (int)_tokenOptions.ValidFor.TotalSeconds,
                user = new
                {
                    id = _user.Id,
                    name = _user.Username.ToString(),
                    email = _user.Email.ToString(),
                    username = _user.Username.ToString(),
                    role = permission.ToString()
                }
            };
            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }

        #region //Authenticate Methods
        private static void ThrowIfInvalidOptions(TokenOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
                throw new ArgumentException("O período deve ser maior que zero", nameof(TokenOptions.ValidFor));

            if (options.SiniginCredential == null)
                throw new ArgumentNullException(nameof(TokenOptions.SiniginCredential));

            if (options.JtiGenerator == null)
                throw new ArgumentNullException(nameof(TokenOptions.JtiGenerator));
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private Task<ClaimsIdentity> GetClaims(AuthenticateUserCommand command)
        {
            var user = _service.GetByEmail(command.Email);

            if (user == null)
                return Task.FromResult<ClaimsIdentity>(null);

            if (!user.Authenticate(command.Email, command.Password))
                return Task.FromResult<ClaimsIdentity>(null);

            _user = user;

            return Task.FromResult(new ClaimsIdentity(
                new GenericIdentity(user.Email, "Token"),
                new[]
                {
                    new Claim("LuizaEMAPI", "Admin"),
                    new Claim("LuizaEMAPI", "User")                    
                }));
        }       
        #endregion
    }
}
