class SerieDeTV {
  constructor(nome, anoEstreia) {
    this.nome = nome || 'NI';
    this.anoEstreia = anoEstreia;
  }

  // SerieDeTV.verificarClassificacaoIndicativa()
  static verificarClassificacaoIndicativa() {
    console.log(this);
    return this.nome;
  }

  get nomeSerie() {
    return this.nome.toUpperCase();
  }

  set nomeSerie(valor) {
    this.nome = valor.toUpperCase();
  }

  imprimirNome() {
    console.log(this.nome.toUpperCase());
  }

  html() {
    return `<h2>${ this.nome }</h2><br/><h3>${ this.anoEstreia }</h3>`;
  }

}
