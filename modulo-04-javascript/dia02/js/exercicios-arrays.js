console.log("series", series);

// Ex 01
// 1. criar funcao para verificar se série é inválida
// 2. aplicar criterio de verificação de série inválida para as séries originais
// 3. retornar string resultante de acordo com o formato esperado
function seriesInvalidas(series) {
  let invalidas = series.filter(serie => {
    // for (let campo in serie) { }
    let algumCampoInvalido = Object.values(serie).some(v => v === null || typeof v === 'undefined');
    let estreiaInvalida = serie.anoEstreia > new Date().getFullYear();
    return estreiaInvalida || algumCampoInvalido;
  });
  return `Séries Inválidas: ${ invalidas.map(s => s.titulo).join(" - ") }`;
}

// retorna um array com todas as séries com
// ano de estreia igual ou maior que 2017.
function filtrarSeriesPorAno(series, ano) {
  return series.filter(s => s.anoEstreia >= ano)
}

// numeroEpisodios
// 34.1
function mediaDeEpisodios(series) {
  // return series
  //   .map(function(s) { return s.numeroEpisodios })
  //   .reduce(function(acc, numeroEpisodios) { return acc + numeroEpisodios }, 0) / series.length;
  return series
    .map(s => s.numeroEpisodios)
    .reduce((acc, numeroEpisodios) => acc + numeroEpisodios) / series.length;
}

function procurarPorNome(series, nome) {
  // indexOf
  return series.some(s => s.elenco.some(e => e.includes(nome)));
}
//
