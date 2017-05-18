var modulo = angular.module('aula02', []);

modulo.controller('Exemplo01', function ($scope, $locale) {

  console.log($locale);

  $scope.valor = 123;
  $scope.dataDigitada = 1288323623006

  $scope.minhaFuncao = minhaFuncao;
  $scope.imprime = imprime;

  function minhaFuncao() {
    console.log('funcionou');
  };

  function imprime() {
    console.log($scope.dataNumero);
  };
});