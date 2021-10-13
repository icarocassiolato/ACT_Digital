# ACT_Digital

<h1 align="center">Instruções</h1>

<h2 align="center">1 - String de conexão</h2>
Informar a string de conexão com o banco de dados no arquivo .ENV (presente na pasta Api).<br/>
Para compilação em modo release é usada a chave CONNECTION_STRING_PRO<br/>
Para compilação em modo debug é usada a chave CONNECTION_STRING_DEV<br/><br/>

Exemplo:<br/>
CONNECTION_STRING_DEV=Server=LAPTOP-CLJFOA4K\SQLEXPRESS;Database=Aplicativo;Trusted_Connection=True;MultipleActiveResultSets=true<br/>

CONNECTION_STRING_PRO=Server=LAPTOP-CLJFOA4K\SQLEXPRESS;Database=Aplicativo;Trusted_Connection=True;MultipleActiveResultSets=true<br/>

<h2 align="center">2 - Exceções</h2>
Foi criado um middleware para o gerenciamento de exceções (ExceptionMiddleware), <br/>
caso ocorra uma exceção em modo release, será dada a seguinte mensagem ao usuário: "Erro inesperado".<br/>
caso ocorra uma exceção em modo debug, será exibida a callstack do erro.<br/>

<h2 align="center">3 - Token de autorização</h2>
Foi implementada a funcionalidade de atutenticação do usuário por token.<br/>
Desse modo, antes de fazer a chamada dos endpoints da API, é necessário gerar um token através do seguinte endpoint (Método POST):<br/>

https://localhost:5001/Token<br/>

No body da requisição, deverão ser informados o Nome e Acesso do usuário. Por exemplo:<br/>

{<br/>
  Nome:"Usuário teste",<br/>
  Acesso:1<br/>
}<br/>

Onde<br/>
Acesso = 1 - Usuário<br/>
Acesso = 2 - Administrador<br/>

<h2 align="center">4 - Extras</h2>
Criei arquivo docker para rodar a aplicação como microsserviço<br/>
Foi gerado o Swagger da aplicação, bastando acessar a URL base (https://localhost:5001) para ter acesso ao mesmo
