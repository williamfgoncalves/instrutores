angular.module('app')
  .controller('HomeController', function ($scope, $http, dataService) {

    limpar();

    $scope.generos = [{ id: 1, texto: 'Não Informado' }, { id: 2, texto: 'Masculino' }, { id: 1, texto: 'Feminino' }];

    $scope.buscarCliente = function () {
      dataService.getCliente($scope.cliente.cpf)
        .then(function (response) {
          if (response.data.result) {
            $scope.reserva.idCliente = response.data.result.id;
            $scope.cliente.id = response.data.result.id;
            $scope.cliente.nome = response.data.result.nome;
            $scope.cliente.cpf = response.data.result.cpf;
            $scope.cliente.dtNascimento = new Date(response.data.result.dtNascimento);
            $scope.cliente.genero = response.data.result.genero;
            $scope.cliente.logradouro = response.data.result.endereco.logradouro;
            $scope.cliente.cidade = response.data.result.endereco.cidade;
            $scope.cliente.estado = response.data.result.endereco.estado;
            $scope.cliente.cep = response.data.result.endereco.cep;
          }
        })
        .catch(function (e) {
          console.log(e);
        });
    };

    $scope.salvarCliente = function () {
      dataService.postCliente($scope.cliente)
        .then(function (response) {
          $scope.cliente.id = response.data.result.id;
          $scope.reserva.idCliente = response.data.result.id;
        })
        .catch(function (e) {
          console.log(e);
        });
    };

    dataService.getProdutos()
      .then(function (response) {
        $scope.produtos = response.data.result;
      });

    dataService.getPacotes()
      .then(function (response) {
        $scope.pacotes = response.data.result;
      });

    dataService.getOpcionais()
      .then(function (response) {
        $scope.opcionais = response.data.result;
      });

    $scope.selecionarProduto = function (produto) {
      if (produto.quantidade > 0) {
        $scope.reserva.idProduto = produto.id;
      }
      calcularReserva();
    };

    $scope.selecionarPacote = function (pacote) {
      $scope.reserva.idPacote = pacote.id;
      calcularReserva();
    };

    $scope.selecionarOpcional = function (opcional) {
      let obj = $scope.opcionais.find(x => x.id == opcional.id);
      obj.selecionado = !!!obj.selecionado;
      if (obj.selecionado) {
        adicionarOpcional(opcional);
      } else {
        removerOpcional(opcional)
      }

      calcularReserva();
    };

    $scope.finalizar = function (reserva) {
      dataService.postFinalizarReserva(reserva)
        .then(function (response) {
          $scope.reserva.id = response.data.result.id;
        })
        .catch(function (e) {
          console.log(e);
        });
    };

    $scope.fecharModal = function () {
      limpar();
    }

    function limpar() {
      $scope.reserva = {
        id: 0,
        idProduto: 0,
        idPacote: 0,
        idCliente: 0,
        opcionais: []
      };

      $scope.totais = {
        totalProduto: 0,
        totalPacote: 0,
        totalReserva: 0,
        totalOpcionais: 0,
        totalDescontos: 0
      }

      $scope.cliente = {
        id: 0,
        nome: '',
        cpf: '',
        dtnascimento: '',
        genero: 1,
        logradouro: '',
        cidade: '',
        estado: '',
        cep: ''
      };
    }

    function calcularReserva() {
      dataService.postCalcular($scope.reserva)
        .then(function (response) {
          $scope.totais = response.data.result;
        })
        .catch(function (e) {
          console.log(e);
        });
    };

    function adicionarOpcional(opcional) {
      $scope.reserva.opcionais.push({ idOpcional: opcional.id });
    }

    function removerOpcional(opcional) {
      let obj = $scope.reserva.opcionais.find(x => x.idOpcional == opcional.id);
      let i = $scope.reserva.opcionais.indexOf(obj);
      $scope.reserva.opcionais.splice(i, 1);
    }

  });