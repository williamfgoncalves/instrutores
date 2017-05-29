iniciarSessao();

function iniciarSessao() {
    realizarLogin();

    setInterval(buscarMensagens, 900);

    adicionaEventosDeSubmit();
}

function realizarLogin() {
    class Usuario {
        constructor(nome, foto) {
            this.nome = nome;
            this.foto = foto;
        }
    };

    window.usuario = new Usuario(localStorage.getItem("nomeUsuario"), localStorage.getItem("fotoUsuario"));

    if (!usuario.nome || !usuario.foto) {
        usuario.nome = prompt("Digite seu nome");
        usuario.foto = prompt("Digite o link da sua foto");

        localStorage.setItem("nomeUsuario", usuario.nome);
        localStorage.setItem("fotoUsuario", usuario.foto);
    }
}

function buscarMensagens() {
    fetch("http://localhost:43791/api/chats")
    .then(response => {
        let json = response.json()

        json.then(mensagens => {
            escreverMensagensNoChat(mensagens);
        })
    })
    .catch(erro => {
        console.log("Não foi possível obter as mensagens");
    })
}

function escreverMensagensNoChat(mensagens) {
    let ultimaMensagem = mensagens[0];

    if (window.timestampUltimaMensagemRecebida == null)
        window.timestampUltimaMensagemRecebida = 0;

    if (ultimaMensagem.Timestamp > window.timestampUltimaMensagemRecebida) {
        window.timestampUltimaMensagemRecebida = ultimaMensagem.Timestamp;

        for (i = mensagens.length-1; i >= 0; i--) {
            let mensagem = mensagens[i];
            let chat = document.querySelector(".chat");

            chat.innerHTML += TemplateEngine(mensagem.Usuario.Nome == window.usuario.nome ? messageLeftTemplate : messageRightTemplate, mensagem);
        }

        empurrarScrollDoChatPraBaixo();
    }
}

function empurrarScrollDoChatPraBaixo() {
    let element = document.querySelector(".body-panel");
    element.scrollTop = element.scrollHeight;
}


function adicionaEventosDeSubmit() {
    //Submit ao clicar no botao
    let botaoEnviar = document.querySelector("#btn-send");
    botaoEnviar.addEventListener("click", enviarMensagem);

    //submit ao dar CTRL + Enter
    document.querySelector("textarea").onkeyup = function(e){
        e = e || event;
        if (e.keyCode === 13 && e.ctrlKey) {
            enviarMensagem();
        }
        return true;
    }
}

function enviarMensagem() {
    let message = { 
        usuario,
        texto: document.querySelector("textarea").value
    }

    fetch("http://localhost:43791/api/chats",
    {
        method: "POST",
        headers: {
        'Accept': 'application/json',
        'Content-Type': "application/json",
        },
        body: JSON.stringify(message)
    })
    .then(_ => {
        document.querySelector("textarea").value = ""
    })
    .catch(erro => {
        console.log("Não foi possível enviar a menasgem", erro, JSON.stringify(message));
    })
};



