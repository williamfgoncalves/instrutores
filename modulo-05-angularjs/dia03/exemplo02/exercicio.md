# Aula 03 - Exercício

1. Listar os instrutores.
2. Permitir inclusão de novos instrutores.

## Um instrutor deve ter:
- Nome (Texto - Obrigatório - 3 a 20 letras)
- Sobrenome (Texto - máximo 30 letras)
- Idade (Número - Obrigatório)
- Email (Obrigatório)
- Informar se já deu aula (Checkbox)
- Qual aula ele ministra (Select - lista de string de aulas)

```javascript

let instrutores = [
  {
    nome: 'Bernardo',
    sobrenome: 'Rezende',
    idade: 30,
    email: 'bernardo@cwi.com.br',
    jaDeuAula: true,
    aula: 'OO'
  }
];

let aulas = [
  'OO',
  'HTML e CSS',
  'Javascript',
  'AngularJS',
  'Banco de Dados I'
];
```
