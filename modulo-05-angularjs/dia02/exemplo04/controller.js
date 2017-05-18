var modulo = angular.module('aula02', []);

modulo.filter('mascada', function () {
  return function (nome) {
    return nome.replace(/(nunes)/i, '$ $1 $');
  }
});

modulo.controller('Exemplo04', function ($scope, $filter) {

  $scope.instrutores = [{
      nome: 'Bernardo'
    },
    {
      nome: 'Nunes'
    },
    {
      nome: 'Pedro (PHP)'
    },
    {
      nome: 'Zanatta'
    }
  ];

  let saida = $filter('mascada')('Teste Nunes Teste');
  console.log(saida);
});