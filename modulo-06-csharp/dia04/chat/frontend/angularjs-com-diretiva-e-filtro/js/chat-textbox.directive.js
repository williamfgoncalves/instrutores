modulo.directive("chatTextbox", function () {

    var controller = function ($scope, chatService) {
        
        adicionaFuncionalidadeAltEnterNoTextArea()
        $scope.mensagemAtual = {} 
        $scope.enviarMensagem = enviarMensagem 

        function enviarMensagem() {
            chatService.enviarMensagem($scope.mensagemAtual.Texto)
            .then(_ => {
                document.querySelector("textarea").value = "";
            });
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
    }

    var template = 
        `<div class="input-group input-digitacao">
            <textarea ng-model="mensagemAtual.Texto" class="form-control custom-control" rows="3"></textarea>     
            <button ng-click="enviarMensagem()" class="input-group-addon btn btn-primary" id="btn-send">Enviar</button>
        </div>`

    return {
        template: template,
        controller: controller
    };
});