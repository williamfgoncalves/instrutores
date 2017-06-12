var app = angular.module('aula02', []);

app.controller('Tema01', function ($scope, $locale) {

  console.log($locale);

  $scope.valor = 123456;

  $scope.pokemons = [
  {
    nome: 'Pokemona 1',
    tipo: 'Agua'
  },
  {
    nome: 'Pokemonb 2',
    tipo: 'Fogo'
  },
  {
    nome: 'Pokemonc 3',
    tipo: 'Fantasma'
  }
  ];
});