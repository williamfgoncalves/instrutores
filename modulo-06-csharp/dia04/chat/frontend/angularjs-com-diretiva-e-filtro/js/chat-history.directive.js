modulo.directive("chatHistory", function () {

    var controller = function ($scope, chatService) {
        setInterval(obterMensagens, 850);
        $scope.mensagemFoiEnviadaPorMim = mensagemFoiEnviadaPorMim

        function obterMensagens() {
            chatService
            .obterMensagens()
            .then(mensagens => {
                $scope.mensagens = mensagens;
                setTimeout(empurrarScrollDoChatPraBaixo, 200); 
            })
        }

        function mensagemFoiEnviadaPorMim(mensagem) {
            return mensagem.Usuario.Nome == chatService.obterUsuarioLogado().nome
        }

        function empurrarScrollDoChatPraBaixo() {
            let element = document.querySelector(".body-panel");
            element.scrollTop = element.scrollHeight;
        }
    }

    var template = 
        `<ul class="chat">
            <li ng-class="mensagemFoiEnviadaPorMim(mensagem) ? 'left' : 'right'" class="clearfix" ng-repeat="mensagem in mensagens | orderBy : 'Timestamp'">
                
                <div ng-if="mensagemFoiEnviadaPorMim(mensagem)"> 
                    <!--Div com mensagem do usuário-->
                    <span class="chat-img pull-left">
                        <img ng-src="{{ mensagem.Usuario.Foto }}" alt="{{ mensagem.Usuario.Nome }}" class="img-circle" />
                    </span>
                    <div class="chat-body clearfix">
                        <div class="header">
                            <strong class="primary-font">{{ mensagem.Usuario.Nome }}</strong> 
                            <small class="pull-right text-muted">
                                <span class="glyphicon glyphicon-time"></span>{{ mensagem.Timestamp | timestampToDate}}
                            </small>
                        </div>
                        <p>
                            {{ mensagem.Texto }}
                        </p>
                    </div>
                </div>

                <div ng-if="!mensagemFoiEnviadaPorMim(mensagem)"> 
                    <!--Div com mensagem dos outros usuários-->
                    <span class="chat-img pull-right">
                        <img ng-src="{{ mensagem.Usuario.Foto }}" alt="{{ mensagem.Usuario.Nome }}" class="img-circle" />
                    </span>
                    <div class="chat-body clearfix">
                        <div class="header">
                            <small>
                                <span class="glyphicon glyphicon-time"></span>{{ mensagem.Timestamp | timestampToDate }}
                            </small>
                            <strong class="primary-font pull-right">{{ mensagem.Usuario.Nome }}</strong> 
                        </div>
                        <p>
                            {{ mensagem.Texto }}
                        </p>
                    </div>
                </div>
            </li>
        </ul>`

    return {
        template: template,
        controller: controller
    };
});