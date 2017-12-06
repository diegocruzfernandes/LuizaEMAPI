# Luiza Employee Manager - API
 Autor: Diego Fernandes  - Versão: 1.0.1 (05/12/2017)\
 contatos: diegocruzfernandes@hotmail.com

---

####  Resumo:

Está API de serviço tem como objetivo fornecer uma interface para a manutenção e distribuição de dados referente aos empregados(Employee).
O serviço está disponivel nas nuvems pelo link [luizaemapi](http://luizaemapi.azurewebsites.net "Luiza EM - API - Azure - Clound")
Os serviçõs estão padronizados nos comando HTTP/REST, assim como seu comandos/verbos de envios: GET, POST, PUT e DELETE, como em códigos de retorno (HTTP Status Code): 200 Ok, 204 No Content, 403 Forbidden, etc..\
:warning: Importante : As rotas estão protegidas pelo padrão OAuth 2, não permitindo seu uso sem autorização.

---

### Como Utilizar:
Primeiro Acesso:
Utilizaremos como exemplo o Swagger que está diponivel em http://luizaemapi.azurewebsites.net/swagger
As rotas estão bloqueadas, assim antes de mais nada é necessário adquirir um TOKEN para fazer uso dos serviços existes.\
Como exemplo iremos utilizar um usuario: **company**  com email: **company@mail.com** e senha **company**

Atravez da rota: luizaemapi.azurewebsites.net/v1/authenticate deve-ser realizado um POST contendo em seu cabeçalho :

>Content-Type: application/x-www-form-urlencoded
>Accept: text/plain: email={youremail} % password={yourpassword}

```
Exemplo: 
>curl -X POST --header 'Content-Type: application/x-www-form-urlencoded' --header 'Accept: text/plain' -d 'Email=company%40mail.com&Password=company' 'http://luizaemapi.azurewebsites.net/v1/authenticate
```

![alt text](http://uploaddeimagens.com.br/images/001/201/435/full/01a.png)

É esperado no Corpo/Body um JSON com resposta:

![alt text](http://uploaddeimagens.com.br/images/001/201/438/full/01bb.png)

São informado dados como:
- token: valor encriptografado da chave de acesso. 
- expires: tempo de duração do token em segundos.
- user: dados do usuario e sua Role/Regra 
   
Para acesso as rotas é necessário fazer uma autenticação.
devemos copiar o valor do Token gerado e clicar em 'Authorize'\
em value: devemos inserir o Token da seguinte maneira
*Bearer {seutoken}*
em seguida clicar em Authorize.
neste momento o Swagger ira inserrir a cada requisição o token atual.

Para testarmos podemos acessar um dos link's 
```
Exemplo:
luizaemapi.azurewebsites.net/V1/Department
```

---

### Rotas

As rotas foram pensadas no sentido de permitir facil acesso mantendo o padrão nominal

- v1/department - Get/Post/Put/Delete
- v1/employee  - Get/Post/Put/Delete
- v1/user - Get/Post/Put/Delete

Atravez da documentação de rotas é possivel saber mais detalhes e exemplos de como utiliza-las
http://luizaemapi.azurewebsites.net/swagger

:warning: Importante :
Existe um relacionamento de _um para um_ entre Department e Employee, assim ao excluir um Department todos os Employee que fizerem parte daquele Department **também** serão excluido!
Obs: **ON DELETE CASCADE**

---
### Sobre o Projeto

O projeto foi desenvolvido sobre a plataforma .Net Framework 4.6.1 
Na linguagem C#, fazendo uso:

- ASP.Net Core 1.1.0
- EntityFramework 6.1.3
- FluentValidator 1.0.5
- AspNetCore.JwtBearer 1.1.3
- SQL Server 2012

Para testes o projeto está rodando no Clound Azure em uma VM, junto com o Bando de Dados SQL Server.
Há uma *Integração Continua* entre o *GitHub* e o *Azure*, atravez da Pull Request na branch Master do GitHub.

Como base de arquiterura o projeto se baseou no modelo DDD (Domain Driven Design *Martin Fowler) ficando separados em 4 projetos:

- 1-API - WEB, RESTFul
- 2-ApplicationService - Canal de comunicação entre (1-API)->(3-Domain) / (1-API)->(4-Infra)
- 3-Domain - Onde estão as Entidade e os Contratos entre ApplicationService e Infra
- 4-Infra - Onde fica o Repositorio e Serviços externos (ex: envio de Email)

É importante salientar que o conceito de Entidades foi baseado no padrão **Dominio Rico** com o padrão de **Notification** atraves do uso do FluentValidator.

---
### TODO

1 - Teste de integração - Apenas foi feito Smoke Tests\
2 - Melhorar a cobertura de código e testes com ferramentas como OpenCover ou SonarQube\
3 - Implementar o serviço de envio de E-mail's\
4 - Logs para Autenticações e Falhas\
