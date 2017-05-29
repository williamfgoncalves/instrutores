modulo.factory("chatService", function ($http) {
    return {
        obterMensagens: obterMensagens,
        enviarMensagem: enviarMensagem,
        usuarioEstaLogado: usuarioEstaLogado,
        realizarLoginUsuario: realizarLoginUsuario,
        obterUsuarioLogado: obterUsuarioLogado
    };

    function obterMensagens() {
        return $http({
            method: "get",
            url: "http://localhost:43791/api/chats"
        })
        .then(response => {
            return response.data;
        });
    }

    function enviarMensagem(mensagem) {
        return $http({
            method: "post",
            url: "http://localhost:43791/api/chats",
            data: {
                "Usuario": obterUsuarioLogado(),
                "Texto": mensagem
            }
        });
    }

    function usuarioEstaLogado() {
        let usuario = obterUsuarioLogado()
        return usuario.nome && usuario.foto
    }

    function realizarLoginUsuario() {
        let nomeUsuario = prompt("Digite seu nome")
        let fotoUsuario = prompt("Digite o link da sua foto")

        if (nomeUsuario && fotoUsuario) {
            localStorage.setItem("nomeUsuario", nomeUsuario)
            localStorage.setItem("fotoUsuario", fotoUsuario)
        }
    }

    function obterUsuarioLogado() {
        class Usuario {
            constructor(nome, foto) {
                this.nome = nome;
                this.foto = foto;
            }
        };

        return new Usuario(localStorage.getItem("nomeUsuario"), localStorage.getItem("fotoUsuario"));
    }
});