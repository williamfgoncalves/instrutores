console.log("Carregou!");
/*
alert("Bem vindo(a)!");
var pi = 3.14;
*/
if (typeof pi !== "undefined") {
    console.log(pi)
}

// ES 2015
// http://caniuse.com/#search=arrow%20functions
var somarArrowFunction = (a, b, c = 3) => a + b

console.log("somarArrowFunction", somarArrowFunction(1, 2))
console.log("typeof somarArrowFunction", typeof somarArrowFunction)

console.log("tem somarSemReturn?", somarSemReturn)
function somarSemReturn(a, b, c) {
  c = c || 3;
  console.log("c", c);
  return a + b;
}
console.log("somarSemReturn", somarSemReturn(1,2))
console.log("typeof somarSemReturn", typeof somarSemReturn)

console.log("tem somar?", somar)
var calcular = function(funcao, a, b) {
  //return funcao(arguments[0], arguments[1])
  return typeof funcao === "function" && funcao(a, b);
}
var somar = (a, b) => a - b
console.log("somar", calcular(somar, 1, 2))
console.log("typeof somar", typeof calcular)

console.log("somar(1, 2, 4)", calcular(1, 2, 4))

// IIFE - http://benalman.com/news/2010/11/immediately-invoked-function-expression/
var resultado = (function (a, b) {
  return a * b;
})(1, 2);

console.log(resultado)

var funcoes = [
  function(a, b) {
    return a + b;
  },
  function(a, b) {
    return a - b;
  },
  function(a, b) {
    return a * b;
  }
]
// ECMA 2015 - for-of
for (var funcao of funcoes) {
  var a = 1, b = 2;
  console.log(funcao(a, b));
}

var obj = { };
obj[0] = 'Nome';
console.log(obj[0]);
obj['Nome Completo'] = 'Bernardo Bosak de Rezende';
console.log(obj['Nome Completo']);

funcoes['outraProp'] = "outraProp";
console.log(funcoes['outraProp']);

// for (var funcao in funcoes) {
//   var a = 1, b = 2;
//   console.log(funcoes[funcao](a,b));
// }
