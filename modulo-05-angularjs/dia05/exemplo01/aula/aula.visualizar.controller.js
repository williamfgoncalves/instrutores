angular.module('app')
  .controller('AulaVisualizarController', function ($scope, $routeParams, aulaService) {

    $scope.aula = {};

    buscarAula($routeParams.idAula);
    
    function buscarAula(id) {
      let promessa = aulaService.buscarPorId(id);

      promessa.then(function (response) {
        $scope.aula = response.data;
      })
    };

  });