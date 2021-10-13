# ACT_Digital

#Instruções

#1 - String de conexão
Informar a string de conexão com o banco de dados no arquivo .ENV (presente na pasta Api).
Para compilação em modo release é usada a chave CONNECTION_STRING_PRO
Para compilação em modo debug é usada a chave CONNECTION_STRING_DEV

Exemplo:
CONNECTION_STRING_DEV=Server=LAPTOP-CLJFOA4K\SQLEXPRESS;Database=Aplicativo;Trusted_Connection=True;MultipleActiveResultSets=true
CONNECTION_STRING_PRO=Server=LAPTOP-CLJFOA4K\SQLEXPRESS;Database=Aplicativo;Trusted_Connection=True;MultipleActiveResultSets=true

#2 - Exceções
Foi criado um middleware para o gerenciamento de exceções (ExceptionMiddleware), 
caso ocorra uma exceção em modo release, será dada a seguinte mensagem ao usuário: "Erro inesperado".
caso ocorra uma exceção em modo debug, será exibida a callstack do erro.

#3 - Token de autorização
Foi implementada a funcionalidade de atutenticação do usuário por token.
Desse modo, antes de fazer a chamada dos endpoints da API, é necessário gerar um token através do seguinte endpoint (Método POST):

https://localhost:5001/Token

No body da requisição, deverão ser informados o Nome e Acesso do usuário. Por exemplo:

{
  Nome:"Usuário teste",
  Acesso:1
}

Onde
Acesso = 1 - Usuário
Acesso = 2 - Administrador

#Extras
Criei arquivo docker para rodar a aplicação como microsserviço
Foi gerado o Swagger da aplicação, bastando acessar a URL base (https://localhost:5001) para ter acesso ao mesmo
