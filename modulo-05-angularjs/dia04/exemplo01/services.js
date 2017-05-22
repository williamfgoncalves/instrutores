app.factory('aulaService', function () {

  let idAtual = 1;

  let aulas = [
    { id: 0, nome: 'OO' },
    { id: 1, nome: 'HTML e CSS' }
  ];

  function getTodasAsAulas(params) {
    return aulas;
  };

  function getAulaPorId(id) {
    return aulas.find((aula) => aula.id == id)
  };

  function atualizar(aula) {
    aulas.splice(aula.id, 1, aula);
  };

  function criar(aula) {
    aula.id = ++idAtual;
    aulas.push(angular.copy(aula));
  };

  return {
    list: getTodasAsAulas,
    findById: getAulaPorId,
    update: atualizar,
    create: criar
  };
});