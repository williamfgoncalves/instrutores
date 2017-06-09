// Cria módulo
angular.module('data', []);

// Service de autenticação
angular.module('data').factory('dataService', function ($http, appConfig) {

  let urlBase = appConfig.urlBase;

  function getCliente(cpf) {
    return $http.get(urlBase + '/clientes?cpf=' + cpf);
  };

  function postCliente(cliente) {
    return $http.post(urlBase + '/clientes', cliente);
  };

  function getProdutos() {
    return $http.get(urlBase + '/produtos');
  };

  function getPacotes() {
    return $http.get(urlBase + '/pacotes');
  };

  function getOpcionais() {
    return $http.get(urlBase + '/opcionais');
  };

  function postCalcular(reserva) {
    return $http.post(urlBase + '/reservas/calcular', reserva);
  };

  function postFinalizarReserva(reserva) {
    return $http.post(urlBase + '/reservas', reserva);
  };

  return {
    getCliente: getCliente,
    postCliente: postCliente,
    getProdutos: getProdutos,
    getPacotes: getPacotes,
    getOpcionais: getOpcionais,
    postCalcular: postCalcular,
    postFinalizarReserva: postFinalizarReserva
  };
});