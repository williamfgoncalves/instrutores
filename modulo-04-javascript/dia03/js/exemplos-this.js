function Jedi() {
  this.nome = "Luke";
  this.outraFuncao = () => {
    console.log("Outra func", this.nome);
  }
  this.ligarSabre = function() {
    console.log(this.nome);
    //let self = this;
    // setInterval(function() {
    //   console.log("UÓÓÓÓÓÓÓÓÓÓÓÓM", this.nome);
    // }.bind(this), 2000);
    setInterval(() => {
      console.log("UÓÓÓÓÓÓÓÓÓÓÓÓM", this.nome);
    }, 2000)
  }
  console.log(this);
}
let luke = new Jedi();
let ray = {
  nome: "Ray",
  ligarSabre: function(texto) {
    console.log("uma vez só: ", this.nome, texto);
  }
}
ray.ligarSabre(); // "uma vez só: Ray undefined"
let fnGlobal = ray.ligarSabre;
fnGlobal(); // "uma vez só: undefined undefined"
ray.ligarSabre.call(luke, "Via Call"); // "uma vez só: Luke Via Call"
// ray.ligarSabre.apply(jedi, [ "Via Apply" ]);
ray.outraFuncao = function() {
  console.log(this);
  //let fn = luke.outraFuncao.bind(this);
  let fn = luke.outraFuncao;
  fn();
  //fn.call(this);
  //fn.apply(this);
}















//
