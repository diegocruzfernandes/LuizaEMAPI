# Luiza Employee Manager - API
V1.0.1

### Resumo:
Está API de serviço tem como objetivo fornecer uma interface para a manutenção e distribuição de dados referente aos empregados(Employee).
O serviço está disponivel nas nuvems pelo link [luizaemapi](http://luizaemapi.azurewebsites.net "Luiza EM - API - Azure - Clound")
Os serviçõs estão padronizados nos comando HTTP/REST, assim como seu comandos/verboz de envios: GET, POST, PUT e DELETE, como em códigos de retorno (HTTP Status Code): 200 Ok, 204 No Content, 403 Forbidden, etc..
As rotas estão protegidas pelo padrão OAuth 2, não permitindo seu uso se autorização.

### Como Utilizar:
Primeiro Acesso:
As rotas estão bloqueadas, assim é necessário adquirir um TOKEN para fazer uso dos serviços existes.
Como exemplo iremos utilizar um usuario: 'company' com email: 'company@mail.com' e senha 'company'

Atravez da rota: luizaemapi.azurewebsites.net/v1/authenticate deve-ser realizado um POST contendo em seu cabeçado :
Content-Type: application/x-www-form-urlencoded
Accept: text/plain: email={youremail} % password={yourpassword}

Exemplo:curl -X POST --header 'Content-Type: application/x-www-form-urlencoded' --header 'Accept: text/plain' -d 'Email=company%40mail.com&Password=company' 'http://luizaemapi.azurewebsites.net/v1/authenticate'
![]({{site.baseurl}}/C:\Users\Diego\Desktop\dados para o teste\documentação\01a.jpg)

É esperado no Corpo/Body um JSON com resposta:
![]({{site.baseurl}}/C:\Users\Diego\Desktop\dados para o teste\documentação\01b.jpg)
Nos são informado dados como:
	- token: valor encriptografado da chave de acesso. 
    - expires: tempo de duração do token em segundos.
	- user: dados do usuario e sua Role/Regra 
   
Para acesso as rotas é necessário fazer uma autenticação.
    
