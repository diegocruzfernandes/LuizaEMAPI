using LuizaEM.Domain.Services;

namespace LuizaEM.Infra.Service
{
    public class EmailService : IEmailService
    {
        public void Send(string name, string email, string subject, string body)
        {
            //Need implement server Email for Reset Password
        }
    }
}
