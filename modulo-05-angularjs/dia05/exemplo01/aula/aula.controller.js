angular.module('app')
  .controller('AulaController', function ($scope, aulaService, $location, toastr) {

    $scope.editar = editar;
    $scope.salvar = salvar;
    $scope.excluir = excluir;
    $scope.visualizar = visualizar;

    carregarAulas();
    
    // Funções internas

    function visualizar(aula) {
      $location.path('/aula/visualizar/' + aula.id);
    }

    function editar(aula) {
      $scope.aulaNova = angular.copy(aula);
    }

    function salvar(aula) {
      if ($scope.formAula.$invalid) {
        return;
      }

      let promise = {};

      if (angular.isDefined(aula.id)) {
        promise = aulaService.alterar(aula);
      
      } else {
        promise = aulaService.incluir(aula)
      }

      promise.then(function (response) {
        carregarAulas();
        toastr.success('Sucesso!', '', { closeButton: true })
      });

      $scope.aulaNova = {};      
    }

    function excluir(aula) {
      let promise = aulaService.excluir(aula);

      promise.then(function (response) {
        carregarAulas();
      });
    }

    function carregarAulas() {
      let promessa = aulaService.listar();

      promessa.then(function (response) {
        $scope.aulas = response.data;
      })
    };

  });