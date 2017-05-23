Crescer 2017-1 | Módulo 05 - AngularJS  

# AngularJS - Trabalho - Final de Semana (CRUD)

**Avisos**
- Limite de Entrega (commit) **22/05/2017 13:29**  
- Criar um diretório chamado `crud` com a solução.

## CRUD Aulas

1. Listar todas as aulas (em ordem alfabética).
2. Permitir a inclusão de uma nova aula, informando apenas o `nome`.
3. Permitir a alteração (apenas o `nome`) de uma aula existente.
4. Permitir exclusão de uma aula, caso ela não esteja sendo usada por nenhum instrutor. Se estiver sendo usada, informar o usuário: "Não é possível excluir esta aula. Está sendo utilizada."  

### Observações:
- Não permitir aulas com mesmo `nome`. Caso usuário tente incluir uma aula com mesmo nome, informá-lo que a mesma já existe: "Aula já cadastrada."  
- O `id` deve ser único (na lista de aulas) e deve ser controlado (gerado) pelo sistema. Usuário não modifica o `id` mas deve visualizá-lo.  

```javascript
// Exemplo Aula
aula = {
  id: 0,
  nome: 'OO' // Obrigatório (length = min 3, max 20)
};
```

## CRUD Instrutores

1. Listar todos os instrutores (em ordem alfabética pelo nome) e suas respectivas aulas (em ordem alfabética). Permitir visualização de todas as informações (inclusive a foto).
2. Permitir a inclusão de um novo instrutor. Permitir que o usuário selecione (e desfaça a seleção) quais as aulas que o instrutor ministra (a partir das aulas já cadastradas).
3. Permitir a alteração das informações de um instrutor (exceto o `id`).
4. Permitir exclusão de um instrutor, caso ele não esteja dando aula (`dandoAula`). Se estiver dando aula, informar o usuário: "Não é possível excluir este instrutor. Está dando aula."

### Observações:
- Não permitir instrutores com mesmo `nome`. Informar: "Instrutor já cadastrado."
- O `email` deve ser único. Informar: "Email já está sendo utilizado."
- Se usuário não informar uma `urlFoto`, utilizar uma default (livre escolha).
- O `id` deve ser único (na lista de instrutores) e deve ser controlado (gerado) pelo sistema. Usuário não modifica o `id` mas deve visualizá-lo.  

```javascript
// Exemplo Instrutor
instrutor = {
    id: 0,                            // Gerado
    nome: 'Nome',                     // Obrigatório (length = min 3, max 20)
    sobrenome: 'Sobrenome',           // Opcional (length = max 30)
    idade: 25,                        // Obrigatório (max 90)
    email: 'email@cwi.com.br',        // Obrigatório (type=email)
    dandoAula: true,                  // true ou false
    aula: [1, 4],                     // Opcional (array)
    urlFoto: 'http://foto.com/3.png'  // Opcional (porém tem uma default de livre escolha)
  }
];

```

## GERAL  
- Sempre que o usuário realiza uma ação com sucesso, ele deve receber um feedback disso. Exemplo: "Inclusão realizada com Sucesso."
- Sempre que um erro previsto ocorre o usuário deve ser informado.
- Deve ficar claro para o usuário quando uma informação é obrigatória ou quando a informação fornecida é inválida. Fica livre como isso (HTML e CSS) vai ser feito.
- Façam algo funcional e que tenha uma boa apresentação (vai ser o filho de vocês).  

```javascript
$scope.instrutores = []; // array `instrutor`
$scope.aulas = [];       // array `aula`
```  

## DICA  
- Lembrem que a cada `F5` vocês perdem os dados de instrutores e aulas. Portanto, façam `console.log($scope.instrutores)` e `console.log($scope.aulas)` para evitar retrabalho.
- Como não vimos a parte de rotas ainda, façam tudo em uma página só (vamos separar isso na segunda).
- Não se assustem!! É trabalhoso mas não é complexo. Quebrem o problema em partes pequenas... fica mais simples de resolver e de perceber a evolução.

_Boa Sorte..._
