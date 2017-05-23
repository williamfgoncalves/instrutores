angular.module('app').config(function ($routeProvider) {

  $routeProvider
    .when('/home', {
      controller: 'HomeController',
      templateUrl: 'home/home.html'
    })
    .when('/aula', {
      controller: 'AulaController',
      templateUrl: 'aula/aula.html'
    })
    .when('/aula/visualizar/:idAula', {
      controller: 'AulaVisualizarController',
      templateUrl: 'aula/aula.visualizar.html'
    })
    .when('/instrutor', {
      controller: 'InstrutorController',
      templateUrl: 'instrutor/instrutor.html'
    })
    .otherwise({
      redirectTo: '/home'
    });
});