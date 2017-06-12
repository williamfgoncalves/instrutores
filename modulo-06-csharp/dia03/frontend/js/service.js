modulo.factory("heroisService", function ($http) {
    return ({
        obterHerois: obterHerois,
        enviarHeroi: enviarHeroi
    });

    function obterHerois() {
        return $http.get("http://localhost:24206/api/herois");
    }

    function enviarHeroi() {
        return $http({
            method: "post",
            url: "http://localhost:24206/api/herois",
            data: {
                "Id": 0,
                "Nome": "Giovani",
                "Poder": {
                    "Nome": "Threads",
                    "Dano": 9999
                }
            }
        });
    }
});