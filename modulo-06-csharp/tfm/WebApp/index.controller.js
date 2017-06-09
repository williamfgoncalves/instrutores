angular.module('app')
  .controller('IndexController', function ($scope, authService, $http) {

        // Cuidado pra não executar a função '()'
        $scope.logout = authService.logout;
        $scope.isAutenticado = authService.isAutenticado;
        $scope.usuarioLogado = authService.getUsuario();
    });