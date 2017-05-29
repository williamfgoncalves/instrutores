var modulo = angular.module('chat-crescer', []);

modulo.controller('ChatController', function ($scope, chatService) {
    verificarLoginUsuario();
    
    function verificarLoginUsuario() {
        if (!chatService.usuarioEstaLogado()) {
            chatService.realizarLoginUsuario();
        }
    }

});