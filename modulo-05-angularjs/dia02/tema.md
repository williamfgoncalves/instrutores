Crescer 2017-1 | Módulo 04 - AngularJS  

# AngularJS - Aula 02 - Exercícios

**Aviso**: Utilizar a lista de `instrutores` que está neste arquivo.

1- Listar todas as aulas (nome) e o respectivo instrutor (nome). A Ordem de exibição deve ser pelo número da aula (crescente).  
```
Ex:

OO                  Bernardo
Banco de Dados      Nunes
HTML e CSS          Pedro (PHP)
Javascript          Bernardo
AngularJS           Zanatta
```

2- Criar um filtro que substitui adiciona '$ ' no início e fim da palavra 'nunes' (sem considerar o `case`) e utilizar ele na listagem do exercício 1 (no nome do instrutor).  
```
Ex:

OO                  Bernardo
Banco de Dados      $ Nunes $
HTML e CSS          Pedro (PHP)
Javascript          Bernardo
AngularJS           Zanatta
```

3- Criar um novo filtro que recebe o objeto `aula` e formata como "`numero` - `aula`", onde `numero` deve ser **lpad 3 (0)** e `aula` **uppercase**. utilizar ele na listagem do exercício 2. 
```
Ex:

001 - OO                  Bernardo
002 - BANCO DE DADOS      $ Nunes $
003 - HTML e CSS          Pedro (PHP)
004 - Javascript          Bernardo
005 - AngularJS           Zanatta
```

### Observações
- HTML e CSS ainda existem. Façam algo bonito.

```javascript
let instrutores = [{
    nome: 'Pedro (PHP)',
    aula: [{
      numero: 3,
      nome: 'HTML e CSS'
    }]
  },
  {
    nome: 'Zanatta',
    aula: [{
      numero: 5,
      nome: 'AngularJS'
    }]
  },
  {
    nome: 'Bernardo',
    aula: [{
        numero: 1,
        nome: 'OO'
      },
      {
        numero: 4,
        nome: 'Javascript'
      }
    ]
  },
  {
    nome: 'Nunes',
    aula: [{
      numero: 2,
      nome: 'Banco de Dados I'
    }]
  }
];
```
