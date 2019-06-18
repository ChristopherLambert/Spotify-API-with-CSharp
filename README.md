# Spotify-API-with-C#
Consultando a API do spotify utilizando c#

[API Spotify](https://developer.spotify.com/documentation/web-api/quick-start/)

Utilizado o Swagger para documentação

[Swagger](https://swagger.io/)

Utilizado o nuget da api do Spotify para consultas a api

[Nuget Spotify C#](https://github.com/JohnnyCrazy/SpotifyAPI-NET/)

VocÊ precisa do SQLSERVER na sua maquina para rodar, desenvolvido no Visual Studio 2017, usando ASPNET CORE 2.0.
Apenas iniciando o projeto no visual studio, ele automaticamente criara o banco, e os dados iniciais.

Você pode testar diretamente no swagger ou em qualquer ferramenta de REST de sua preferencia.
Quando a aplicação começar ele automaticamente abrira a pagina do Swagger no seu navegador.

Contem 4 Controllers 
1.SpotyTestController (Apenas um Get para testar a comunicação com SpotifyAPI)
2.CashController (Apenas Get dos valores da teabela de cash)
3.Disco Controler(Apenas Get com filtro pra trazer DISCOS casdastrados na base)

Filtras por IS,Categoria ou Todos.

4.VendasController(Get e Post para trazer e registrar novas vendas)

GET
Filtro Paginado por todos, ou por data de venda no padrão brasileiro --> '15/06/2019' 
Se não passar a pagina nem o numeo de paginas ele traz a primeira pagina com tamanho 10 por padrão.

Filtrar por ID.

POST
Recebe uma lista de IDs do disco que serão vendidos, a data da venda ee sempre a data atual.
Retorna uma lista de disco vendidos conforme id, e o cashback total.
