class SerieDeDrama extends SerieDeTV {
  constructor(nome, anoEstreia) {
    super(nome, anoEstreia);
  }

  get mediaDeMortesPorEpisodio() {
    return 4;
  }

}
