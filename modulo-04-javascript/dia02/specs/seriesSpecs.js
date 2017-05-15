var seriesMemes = JSON.parse('[{"titulo":"Eu Sei JavaScript","anoEstreia":2015,"diretor":["O carinha do TI"],"genero":["Caos","Ficção","Drama"],"elenco":["Cliente","Testador"],"temporadas":1,"numeroEpisodios":null,"distribuidora":null},{"titulo":"Memes Brasil","anoEstreia":2010,"diretor":["Dougras"],"genero":["Comédia","Zoeira"],"elenco":["Jailson Mendes","Cara da Tainha","Irineu"],"temporadas":7,"numeroEpisodios":150,"distribuidora":"Teste"},{"titulo":"Sem nome","anoEstreia":19999,"diretor":["Sem nome"],"genero":["Sem nome"],"elenco":["Sem O. nome","Sem L. Nome","Sem A. nome"],"temporadas":1,"numeroEpisodios":10,"distribuidora":"Sem nome"}]');

describe("seriesInvalidas()", function() {
    it("Teste para o array series", function() {
        var resultado = "Séries Inválidas: Band of Brothers - Mr. Robot - Narcos";
        expect(resultado).toBe(seriesInvalidas(series));
    });
    it("Teste para o array seriesMemes", function() {
        var resultado = "Séries Inválidas: Eu Sei JavaScript - Sem nome";
        expect(resultado).toBe(seriesInvalidas(seriesMemes));
    });
});

describe("filtrarSeriesPorAno()", function() {
    it("Teste para o array series - ano 2017", function() {
        expect(3).toBe(filtrarSeriesPorAno(series, 2017).length);
        expect("Band of Brothers").toBe(filtrarSeriesPorAno(series, 2017)[0].titulo);
        expect("Bernardo The Master of the Wizards").toBe(filtrarSeriesPorAno(series, 2017)[1].titulo);
        expect("Mr. Robot").toBe(filtrarSeriesPorAno(series, 2017)[2].titulo);
    });
    it("Teste para o array series - ano 99999 (array vazio)", function() {
        expect(0).toBe(filtrarSeriesPorAno(series, 99999).length);
    });
    it("Teste para o array seriesMemes - ano 2017", function() {
        expect(1).toBe(filtrarSeriesPorAno(seriesMemes, 2017).length);
        expect("Sem nome").toBe(filtrarSeriesPorAno(seriesMemes, 2017)[0].titulo);
    });
});

describe("mediaDeEpisodios()", function() {
    it("Teste para o array series", function() {
        expect(34.1).toBe(mediaDeEpisodios(series));
    });
    it("Teste para o array seriesMemes", function() {
        expect(53.333333333333336).toBe(mediaDeEpisodios(seriesMemes));
    });
});

describe("procurarPorNome()", function() {
    it("Teste para o array de series (Bernardo)", function() {
        expect(true).toBe(procurarPorNome(series, "Bernardo"));
    });
    it("Teste para o array de series (Nunes)", function() {
        expect(false).toBe(procurarPorNome(series, "Nunes"));
    });
    it("Teste para o array de seriesMemes (Irineu)", function() {
        expect(true).toBe(procurarPorNome(seriesMemes, "Irineu"));
    });
    it("Teste para o array de seriesMemes (Quero Café)", function() {
        expect(false).toBe(procurarPorNome(seriesMemes, "Quero Café"));
    });
});

describe("mascadaEmSerie()", function() {
    it("Teste para o array de series[0]", function() {
        expect(640000).toBe(mascadaEmSerie(series[0]));
    });
    it("Teste para o array de series[5]", function() {
        expect(180000).toBe(mascadaEmSerie(series[5]));
    });
});

describe("queroGenero() e queroTitulo()", function() {
    it("Teste para o array de series - gênero(Caos)", function() {
        expect(2).toBe(queroGenero("Caos").length);
        expect("Bernardo The Master of the Wizards").toBe(queroGenero("Caos")[0].titulo);
        expect("10 Days Why").toBe(queroGenero("Caos")[1].titulo);
    });
    it("Teste para o array de series - gênero(Zoeira)", function() {
        expect(0).toBe(queroGenero(series, "Zoeira").length);
    });
    it("Teste para o array de series - titulo(The)", function() {
        expect(2).toBe(queroTitulo("The").length);
        expect("The Walking Dead").toBe(queroTitulo("The")[0]);
        expect("Bernardo The Master of the Wizards").toBe(queroTitulo("The")[1]);
    });
    it("Teste para o array de series - titulo(Stranger)", function() {
        expect(1).toBe(queroTitulo("Stranger").length);
        expect("Stranger Things").toBe(queroTitulo("Stranger")[0]);
    });
    it("Teste para o array de series - titulo(Zoeira)", function() {
        expect(0).toBe(queroTitulo(series, "Zoeira").length);
    });
});

describe("Testando palavraIlluminati() e palavraIlluminatiComContador()", function() {
    it("Teste para palavraIlluminati array series", function() {
        expect("#NUNESILLUMINATI").toBe(descobrirSerieComTodosAbreviados(series));
    });
});
