angular.module('app').factory('aulaService', function ($http) {

  let urlBase = 'http://localhost:3000/aula';

  function listar() {
    return $http.get(urlBase);
  };

  function buscarPorId(id) {
    return $http.get(urlBase + '/' + id);
  };

  function alterar(aula) {
    return $http.put(urlBase + '/' + aula.id, aula);
  };
  
  function incluir(aula) {
    return $http.post(urlBase, aula);
  };

  function excluir(aula) {
    return $http.delete(urlBase + '/' + aula.id);
  };

  return {

    listar: listar,
    alterar: alterar,
    incluir: incluir,
    excluir: excluir,
    buscarPorId: buscarPorId

    /*

    buscarPorId: function (id) {
      
    },
    criar: function (aula) {
      
    },
    atualizar: function (aula) {
      
    },
    remover: function (aula) {
      
    }
    */
  };
})