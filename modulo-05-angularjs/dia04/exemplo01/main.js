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
  
  // ações de click 
  $scope.create = create;
  $scope.update = update;

  // Ações executadas quando criar a controller
  findById($scope.id); // buscar aula por id (passado na url)
  list(); // listar aulas

  // Funções internas

  function create(aula) {
    aulaService.create(aula);
  };

  function findById(id) {
    aulaService.findById(id).then(function (response) {
      $scope.aula = response.data;
    });
  };

  function list() {
    aulaService.list().then(function (response) {
      $scope.aulas = response.data;
    });
  }

  function update(aula) {
    aulaService.update(aula).then(function () {
      list();  
    });
  };
});