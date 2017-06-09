angular.module('app').config(function ($routeProvider) {

  $routeProvider

    .when('/home', {
      controller: 'HomeController',
      templateUrl: 'home/home.html',
      resolve: {
        autenticado: function (authService) {
          return authService.isAutenticadoPromise();
        }
      }
    })

    // pública
    .when('/login', {
      controller: 'LoginController',
      templateUrl: 'login/login.html'
    })

    .otherwise('/home');
});
