// Exercício 01

function daisyGame(numero) {
  //return numero % 2 !== 0 ? 'Love me' : 'Love me not'
  var impar = numero % 2 !== 0
  return `Love me${ impar ? '' : ' not' }`
}
console.log(daisyGame(1))
console.log(daisyGame(4))

function maiorTexto(textos) {
  //console.log('antes', i);
  var maiorTamanho = textos.length > 0 ? textos[0] : "";
  for (let i = 1; i < textos.length; i++) {
    if (textos[i].length > maiorTamanho.length) {
      maiorTamanho = textos[i];
    }
  }
  //console.log('depois', i);
  return maiorTamanho;
}

console.log(maiorTexto([ 'a', 'bb', 'ccc', 'dd' ]))
//console.log(maiorTexto([ ]))

function imprime(textos, funcaoParaExecutar) {
  if (typeof funcaoParaExecutar === 'function') {
    textos.forEach(funcaoParaExecutar)
  }
}

imprime(
  // primeiro parâmetro: array
  [ 'bernardo', 'nunes', 'php', 'zanatta', 'fabrício', 'jotz', 'carlos' ],
  // segundo parâmetro: função
  function(instrutor) {
    console.log('olá querido instrutor:', instrutor)
  }
);

imprime([ 'nunes', 'php' ], true);

console.log((function adicionar(numero1) {
  return function segundaParte(numero2) {
    return numero1 + numero2;
  }
})(3)(6))

//console.log(adicionar(3)(4));
//console.log(adicionar(5642)(8749));

function fibonacci(n) {
  if (n === 1 || n === 2) {
    return 1;
  }
  return fibonacci(n-1) + fibonacci(n-2);
}
console.log(fibonacci(3));

// 1+1+2+3+5+8+13
// fiboSum(1) => 1
// fiboSum(2) => 2
// fiboSum(3) => 4
function fiboSum(n) {
  if (n === 1) {
    return 1;
  }
  let elementoSequencia = fibonacci(n);
  return elementoSequencia + fiboSum(n-1);
}
console.log(fiboSum(3));
//console.log(fiboSum(100));

function queroCafe(mascada, precos) {
  return precos
    .filter(function(a) {
      return a <= mascada;
    })
    .sort(function(a,b) {
      return a - b; }
    )
    .join(',')


  return precos
    .filter(a => a <= mascada)
    .sort((a,b) => a-b)
    .join(',')
}

console.log(queroCafe(3.14, [ 5.16, 2.12, 1.15, 3.11, 17.5 ]));


























































//
