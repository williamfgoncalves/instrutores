let app = angular.module('app', []);

app.controller('MainController', function ($scope) {


  $scope.opcoes = [{
      nome: 'nome',
      type: 'text'
    },
    {
      nome: 'sobrenome',
      type: 'text'
    },
    {
      nome: 'idade',
      type: 'number'
    },
    {
      nome: 'email',
      type: 'email'
    },
    {
      nome: 'aula',
      type: 'text'
    }
  ];

  $scope.selecionado = $scope.opcoes[0];

  $scope.reset = function () {
    $scope.search = {};
  }

  $scope.incluir = function () {
    if ($scope.meuForm.$valid) {
      $scope.instrutores.push(angular.copy(novoInstrutor));
      $scope.novoInstrutor = {};
    }
  };

  $scope.instrutores = [{
      nome: 'Bernardo',
      sobrenome: 'Rezende',
      idade: 25,
      email: 'bernardo@cwi.com.br',
      aula: 'OO'
    },
    {
      nome: 'Pedro',
      sobrenome: 'Henrique Pires',
      idade: 21,
      email: 'php@cwi.com.br',
      aula: 'HTML e CSS'
    },
    {
      nome: 'Everton',
      sobrenome: 'Zanatta',
      idade: 25,
      email: 'zanatta.everton@cwi.com.br',
      aula: 'AngularJS'
    },
    {
      nome: 'André',
      sobrenome: 'Nunes',
      idade: 32,
      email: 'nunes@cwi.com.br',
      aula: 'Banco de Dados'
    }
  ];
});