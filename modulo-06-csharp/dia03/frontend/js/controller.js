var modulo = angular.module('herois-app', []);

modulo.controller('HeroisController', function ($scope, heroisService) {
    $scope.herois = {};
    $scope.enviarHeroi = enviarHeroi;
    obterHerois();    

    function obterHerois() {
        heroisService
        .obterHerois()
        .then(response => {
            $scope.herois = response.data;
        })
    }

    function enviarHeroi() {
        heroisService
        .enviarHeroi()
        .then(herois => {
            obterHerois();
        })
    }
});