let app = angular.module('app', []);

app.controller('MainController', function ($scope) {

  $scope.incluir = function () {
    if ($scope.meuForm.$valid) {
      $scope.instrutores.push(angular.copy(novoInstrutor));
      $scope.novoInstrutor = {};
    }
  };

  $scope.instrutores = [{
    nome: 'Bernardo',
    sobrenome: 'Rezende',
    idade: 30,
    email: 'bernardo@cwi.com.br',
    jaDeuAula: true,
    aula: 'OO'
  }];
  
  //$scope.visivel = true;
  $scope.aulas = [
    'OO',
    'HTML e CSS',
    'Javascript',
    'AngularJS',
    'Banco de Dados I'
  ];
});