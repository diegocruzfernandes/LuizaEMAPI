# Luiza Employee Manager - API
 Autor: Diego Fernandes  - Versão: 1.0.3 (07/12/2017)\
 contatos: diegocruzfernandes@hotmail.com

---

####  Resumo:

Está API de serviço tem como objetivo fornecer uma interface para a manutenção e distribuição de dados referente aos empregados(Employee).
O serviço está disponível nas nuvens pelo link [luizaemapi](http://luizaemapi.azurewebsites.net "Luiza EM - API - Azure - Clound").
Os serviços estão padronizados nos comando HTTP/REST, assim como seu comandos/verbos de envios: GET, POST, PUT e DELETE bem como os códigos de retorno (HTTP Status Code): 200 Ok, 204 No Content, 403 Forbidden, etc..\
:warning: Importante : As rotas estão protegidas pelo padrão OAuth 2 e não permite seu uso sem autorização.

---

### Como Utilizar:
Primeiro Acesso:\
Utilizaremos como exemplo o Swagger que está diponível em http://luizaemapi.azurewebsites.net/swagger
As rotas estão bloqueadas, assim antes de mais nada é necessário adquirir um TOKEN para fazer uso dos serviços existentes.\
Como exemplo iremos utilizar um usuário: **company**  com email: **company@mail.com** e senha **company**

Clicando em Account devemos preencher os dados de Email e Password
![alt text](http://uploaddeimagens.com.br/images/001/201/435/full/01a.png)


Para uso através de comandos o acesso deve ser feito através da rota: http://luizaemapi.azurewebsites.net/v1/authenticate
deve-se realizar um POST contendo em seu cabeçalho:

>Content-Type: application/x-www-form-urlencoded
>Accept: text/plain: email={youremail} % password={yourpassword}

```
Exemplo: 
>curl -X POST --header 'Content-Type: application/x-www-form-urlencoded' --header 'Accept: text/plain' -d 'Email=company%40mail.com&Password=company' 'http://luizaemapi.azurewebsites.net/v1/authenticate
```

É esperado no Corpo/Body um JSON com resposta:

![alt text](http://uploaddeimagens.com.br/images/001/201/438/full/01bb.png)

São informado dados como:
- token: valor encriptografado da chave de acesso. 
- expires: tempo de duração do token em segundos.
- user: dados do usuário e sua Role/Regra 
   
Para acesso as rotas deve seprem ser enviado no cabeçalho da requisição o token de autenticar.

Através de comandos deve ser indicado no Header/Cabeçalho
```
Authorization: Bearer {seutoken}
```

Através do Swagger deve-se clicar em 'Authorize'\
No campo **value:** devemos inserir o Token da seguinte maneira
```
Bearer {seutoken}
```
em seguida clicar em **Authorize**.

![alt text](http://uploaddeimagens.com.br/images/001/201/439/full/01c.png)

Neste momento o Swagger ira inserir a cada requisição o token atual.

Para testarmos podemos acessar um dos link's 
```
Exemplo:
luizaemapi.azurewebsites.net/V1/Department
```

:warning: Importante : Apenas os usuários com poderes administrativos poderão fazer uso das rotas POST/PUT/DELETE

---

### Rotas

As rotas foram pensadas no sentido de permitir fácil acesso mantendo o padrão nominal

- v1/department - Get/Post/Put/Delete
- v1/employee  - Get/Post/Put/Delete
- v1/user - Get/Post/Put/Delete

Através da documentação de rotas é possível saber mais detalhes e exemplos de como utiliza-las
http://luizaemapi.azurewebsites.net/swagger

:warning: Importante :
Existe um relacionamento de _um para um_ entre Department e Employee, assim ao excluir um Department todos os Employee que fizerem parte daquele Department **também** serão excluído!
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

Para testes o projeto está rodando no Clound Azure em uma VM, junto com o Banco de Dados SQL Server.
Há uma Integração Continua entre o GitHub e o Azure, através da Pull Request na branch Master do GitHub.

Como base de arquitetura o projeto se baseou no modelo DDD (Domain Driven Design *Eric Evans) tendo seu desenvolvimento com foco no domínio. O Programa ficou separado em 4 projetos:

- 1-API - WEB, RESTFul
- 2-ApplicationService - Canal de comunicação entre (1-API)->(3-Domain) / (1-API)->(4-Infra)
- 3-Domain - Onde estão as Entidade e os Contratos entre ApplicationService e Infra
- 4-Infra - Onde fica o Repositório e Serviços externos (ex: envio de Email)

É importante salientar que o conceito de Entidades foi baseado no padrão **Domínio Rico** com o padrão de **Notification** através do uso do FluentValidator visando facilitar a manutenção e evolução do projeto.

---
### TODO

1 - Teste de integração - Apenas foi feito Smoke Tests\
2 - Melhorar a cobertura de código e testes com ferramentas como OpenCover ou SonarQube\
3 - Implementar o serviço de envio de E-mail's\
4 - Logs para Autenticações e Falhas
5 - Tranduzir o Readme para o idioma Inglês
