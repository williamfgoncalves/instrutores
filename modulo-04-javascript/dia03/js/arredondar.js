Number.prototype.arredondar = function(casasDecimais = 2) {
  //casasDecimais = casasDecimais || 2;
  //return parseFloat(this.toFixed(2));
  let casas = Math.pow(10, casasDecimais);
  return Math.round(this * casas) / casas;
}
