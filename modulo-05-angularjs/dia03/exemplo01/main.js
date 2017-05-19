let app = angular.module('app', []);

app.controller('MainController', function ($scope) {
  
  $scope.nomes = ['Bernardo', 'Nunes'];

  $scope.incluir = function (novoNome) {

    if ($scope.meuForm.$valid) {
      $scope.nomes.push(novoNome);
    }
  }
});
