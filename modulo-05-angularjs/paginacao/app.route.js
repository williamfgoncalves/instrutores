angular.module('app')
  .config(function ($routeProvider) {

    $routeProvider
      .when('/home', {
        controller: 'HomeController',
        templateUrl: 'home/home.html'
      })
      .otherwise('/home');

  });
  