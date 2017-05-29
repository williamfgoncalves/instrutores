var modulo = angular.module('chat-crescer', []);

modulo.controller('ChatController', function ($scope, chatService) {
    verificarLoginUsuario();
    setInterval(obterMensagens, 850);
    adicionaFuncionalidadeAltEnterNoTextArea(); 

    $scope.mensagemAtual = {}
    $scope.enviarMensagem = enviarMensagem
    $scope.mensagemFoiEnviadaPorMim = mensagemFoiEnviadaPorMim
    $scope.converterTimeStampParaData = converterTimeStampParaData

    function obterMensagens() {
        chatService
        .obterMensagens()
        .then(mensagens => {
            $scope.mensagens = mensagens;
            setTimeout(empurrarScrollDoChatPraBaixo, 200);  
        })
    }

    function enviarMensagem() {
        chatService.enviarMensagem($scope.mensagemAtual.Texto)
        .then(_ => {
            document.querySelector("textarea").value = "";
        });
    }

    function mensagemFoiEnviadaPorMim(mensagem) {
        return mensagem.Usuario.Nome == chatService.obterUsuarioLogado().nome
    }

    function empurrarScrollDoChatPraBaixo() {
        let element = document.querySelector(".body-panel");
        element.scrollTop = element.scrollHeight;
    }

    function verificarLoginUsuario() {
        if (!chatService.usuarioEstaLogado()) {
            chatService.realizarLoginUsuario();
        }
    }

    function adicionaFuncionalidadeAltEnterNoTextArea() {
        document.querySelector("textarea").onkeyup = function(e){
            e = e || event;
            if (e.keyCode === 13 && e.ctrlKey) {
                enviarMensagem();
            }
            return true;
        }
    }

    function converterTimeStampParaData(timestamp) {
        var date = new Date(timestamp)

        return  ("0" + date.getDate()).slice(-2) + "-" + ("0"+(date.getMonth()+1)).slice(-2) + "-" +
        date.getFullYear() + " " + ("0" + date.getHours()).slice(-2) + ":" + ("0" + date.getMinutes()).slice(-2);
    }
});