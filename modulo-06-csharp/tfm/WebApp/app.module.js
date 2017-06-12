angular.module('app', ['ngRoute', 'auth','data'])    


// Configurações utilizadas pelo módulo de autenticação (authService)
angular.module('app').constant('appConfig', {

    // Obrigatória - URL da API que retorna o usuário
    urlBase: 'http://localhost:52254/api',

    // Obrigatória - URL da aplicação que possui o formulário de login
    urlLogin: '/login',

    // Opcional - URL da aplicação para onde será redirecionado (se for informado) após o LOGIN com sucesso
    urlPrivado: '/home',

    // Opcional - URL da aplicação para onde será redirecionado (se for informado) após o LOGOUT
    urlLogout: '/login'
});
