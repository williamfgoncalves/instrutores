angular.module('app')
  .controller('HomeController', function ($scope, $http) {

    $scope.parametros = {
      quantidadeTrazer: 5,
      quantidadePular: 0,
    };

    $scope.buscar = function (parametros) {

      // Lembrar de trocar a PORTA na URL

      // Duas formas de fazer a mesma coisa

      // Forma 1: $http()
      $http({
          url: 'http://localhost:1234/api/livros',
          method: 'GET',
          params: parametros
        })
        .then(function (response) {
          $scope.livros = response.data.dados;
        });


      // Forma 2: $http.get()
      $http.get(`http://localhost:1234/api/livros?quantidadePular=${parametros.quantidadePular}&quantidadeTrazer=${parametros.quantidadeTrazer}`)
        .then(function (response) {
          $scope.livros = response.data.dados;
        });

    };

  });
  