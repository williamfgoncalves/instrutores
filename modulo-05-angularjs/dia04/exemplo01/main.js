let app = angular.module('app', ['ngRoute']);

app.config(function ($routeProvider) {

  $routeProvider
    .when('/pagina01', {
      controller: 'Pagina01Controller',
      templateUrl: 'pagina01.html'
    })
    .when('/pagina02', {
      controller: 'Pagina02Controller',
      templateUrl: 'pagina02.html'
    })
    .when('/pagina03/:idUrl', {
      controller: 'AulaController',
      templateUrl: 'pagina03.html'
    })
    .when('/pokemon', {
      controller: 'PokemonController',
      templateUrl: 'pokemon.html'
    })
    .otherwise({
      redirectTo: '/pagina01'
    });
});

app.controller('Pagina01Controller', function ($scope) {
  $scope.controller = 'Pagina01Controller';
});

app.controller('Pagina02Controller', function ($scope) {
  $scope.controller = 'Pagina02Controller';
});

app.controller('PokemonController', function ($scope, $http) {

  let url = 'http://pokeapi.co/api/v2/pokemon/25/';

  $http.get(url).then(function (response) {
    $scope.name = response.data.name;
  });
});

app.controller('AulaController', function ($scope, $routeParams, aulaService) {
  
  $scope.id = $routeParams.idUrl;
  
  // listar aulas
  $scope.aulas = aulaService.list();

  // atualizar
  $scope.atualizar = aulaService.update;

  // incluir
  $scope.criar = aulaService.create;
  
  buscarAulaPorId($scope.id)

  function buscarAulaPorId(id) {
    $scope.aula = angular.copy(aulaService.findById(id));
  }
});