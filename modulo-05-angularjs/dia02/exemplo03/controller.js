var modulo = angular.module('aula02', []);

modulo.controller('Exemplo03', function ($scope, $filter) {

  $scope.converter = function converter() {

    if (angular.isUndefined($scope.dataDigitada)) {
      return;
    }

    let dataFormatada = $scope.dataDigitada.replace(/(\d{2})\/(\d{2})\/(\d{4})/, '$2.$1.$3');

    let dataObjeto = new Date(dataFormatada);
    
    $scope.dataObjeto = dataObjeto;
    $scope.dataPronta = $filter('date')(dataObjeto, 'mediumDate')
  }
});
