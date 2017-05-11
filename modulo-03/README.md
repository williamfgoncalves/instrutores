#
HTML e CSS

### O que é HTML?

A Hypertext Markup Language (linguagem de marcação de hipertexto) não é uma linguagem de programação e sim, como o nome diz, uma linguagem de marcação. Ela funciona através de marcações chamadas tags, com propósito de estruturar e definir a natureza do conteúdo de uma página.

### Estrutura básica de um documento

#### Tag html
Tag que delimita o início e o fim do documento HTML. Ela é composta de duas tags, a `head` e a `body`.

```html
<html>
  <head></head>
  <body></body>
</html>
```

#### Tag head
Tag de metadados do documento utilizada para informar ao navegador coisas como o título da página e o encoding do documento. É obrigatório a inclusão da tag `title` dentro do `head`.

```html
<html>
  <head>
    <title>Mirror Fashion</title>
    <meta charset="utf-8">
  </head>
  <body>
  </body>
</html>
```
#### Tag body
O corpo do documento. Diferente da tag `head` que são informações utilizadas exclusivamente pelo navegador, aqui ficam os conteúdos destinados a serem visualizados pelo usuário.

#### DOCTYPE
Utilizado para especificar ao navegador a versão do HTML.

Apontar para a última versão: `<!DOCTYPE html>`. A tag doctype fica no topo do documento, antes da tag html:

```html
<!DOCTYPE html>
<html>
  <head>
    <title>Mirror Fashion</title>
    <meta charset="utf-8">
  </head>
  <body>
  </body>
</html>
```

## Tags

### Titulos

```html
<h1>Titulo 1</h1>
<h2>Titulo 2</h2>
<h3>Titulo 3</h3>
<h4>Titulo 4</h4>
<h5>Titulo 5</h5>
<h6>Titulo 6</h6>
```

### Parágrafos

```html
<p>
  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lacinia lorem tellus, ut scelerisque erat viverra quis. Proin vehicula ultricies risus ut laoreet.
</p>
<p>
  Ut nunc eros, pellentesque sed rhoncus ut, vehicula eget mi. Donec gravida non ante pharetra iaculis. Nulla molestie mi quis nisl lobortis, vitae scelerisque arcu rutrum. Cras vulputate tempor bibendum. Sed varius, eros ut dignissim rutrum, massa turpis dictum nulla, sed malesuada sem ante sed vitae eros lacus. Ut auctor consectetur elit, et tincidunt est convallis sed. Nam eget arcu orci. Pellentesque ut dignissim velit. Donec fringilla commodo blandit.
</p>
<p>
  Curabitur in vestibulum ipsum. Suspendisse at lorem id diam porttitor dignissim et sed risus. Quisque maximus augue in tincidunt imperdiet. In sollicitudin faucibus leo, at finibus augue euismod id. Duis feugiat nunc metus, ac malesuada velit vehicula id. Aenean sed imperdiet turpis. Nulla congue consectetur nisi eu molestie. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Sed eleifend fringilla mauris in tempor.
</p>
```

### Ênfase
Mais forte (negrito): `<strong>`

Ênfase: `<em>`

Fine print: `<small>`

### Imagens
Apontando para uma imagem no servidor:

```html
<img src="imagem.png" alt="Descrição a ser exibida caso a imagem nao seja carregada">
```

Apontando para uma imagem em outro servidor HTTP:

```html
<img src="http://www.site.com/imagem.png" alt="Descrição a ser exibida caso a imagem nao seja carregada">
```

#### Fallback de imagens

*Fallback* é uma técnica de contingência bastante utilizada em diversos tipos de aplicações, na qual dado um recurso, caso ele não esteja disponível utiliza-se outro (e assim por diante).

Nesse exemplo caso a imagem descrita na tag `object` não exista o navegador irá exibir a imagem interna.

```html
<object data="user-198985.png" type="image/png">
  <img src="unknow-user.png" />
</object>
```

Caso esteja usando um navegador muito antigo (`< IE 6`) e o mesmo não der suporte para o `object`, ele irá ignorar ela e irá mostrar apenas a tag `img`.

### Links

```html
<a href="google.com">Clique aqui</a>
<a href="teste.html">Clique aqui</a>
<a href="#idElemento">Clique aqui</a>
```

### Listas ordenadas e não ordenadas

```html
<ol>
  <li>Primeiro item da lista</li>
  <li>Segundo item da lista</li>
  <li>Terceiro item da lista</li>
  <li>Quarto item da lista</li>
  <li>Quinto item da lista</li>
</ol>

<ul>
  <li>Primeiro item da lista</li>
  <li>Segundo item da lista</li>
  <li>Terceiro item da lista</li>
  <li>Quarto item da lista</li>
  <li>Quinto item da lista</li>
</ul>
```

### Tables

```html
<table>
  <thead>
    <tr>
      <th>Coluna 1</th>
      <th>Coluna 2</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Dado 1</td>
      <td>Dado 2</td>
    </tr>
  </tbody>
</table>
```

### Divs

Utilizado para organizar conteúdo.

```html
<div>
  Meu conteúdo
</div>
```

### Span

Utilizado para organizar conteúdo "inline". A diferença básica entre `div` e `span` é que o primeiro é utilizado para envolver seções inteiras de um documento, enquanto o segundo é utilizado para envolver pequenas porções de textos, imagens, etc.

Note que sendo o `span` um elemento *"inline"* ele não pode possuir dentro dele elementos *"block"*, segundo as especificações da W3C.

### Exemplo:

**Isso pode:**

```html
<span>
  <img src="img.png" />
  <a href="#link">Link</a>
</span>
```

**Isso não:**

```html
<span>
  <div></div>
</span>
```

Pois div é um elemento "block"!

### Iframe

```html
<iframe width="700" height="450" src="https://www.youtube.com/embed/yG8_tTImLdM" allowfullscreen>
</iframe>
```

OBS: O conteúdo do iframe não é indexado pelos *search engines*.

### Comentários

```html
<!–- Seu comentário aqui –->
```

### Atributos globais

`id`, `title`, `data-*`, `style`, `class`

[Lista completa](http://www.w3schools.com/tags/ref_standardattributes.asp)

## CSS

### Como estilizar uma página HTML
Antigamente se usavam tags como a `font` para mudar a cor de um texto, como no exemplo abaixo para mudar a cor de um link:

```html
<a href="www.site.com"><font color="red">Clique aqui</font></a>
```

Mas hoje isso é considerado uma má prática.

Por dois principais motivos:

1. Isso é estilo. O objetivo do HTML é estruturar e dar semântica ao conteúdo;
2. Se quiséssemos alterar a cor desse link em todas as páginas do nosso site teríamos que alterar em diversos lugares, provavelmente em diversos arquivos.

Portanto para recursos de estilo como esse e muitos outros utilizamos o **CSS**.

### As três maneiras de utilizar CSS

#### Atributo Style

```html
<div style="border-style: solid;">div com borda</div>
```

#### Tag Style

```html
<html>
  <head>
    <title>teste</title>
    <style>
      div {
        border-style: solid;
      }
    </style>
  </head>
  <body>
    <div>
      todas as divs ficarão com borda!
    </div>
  </body>
</html>
```

A tag style no HTML5 passou a funcionar, quando dentro do body, por escopo. Atingindo assim os elementos no qual ela presente e também nos seus filhos.

#### Arquivo CSS separado

Basta criar um arquivo com a extensão **.css** e referenciá-lo na página. Exemplo:

Arquivo `minha-folha-de-estilos.css`:

```css
div {
  border-style: solid;
}
```
Arquivo `index.html`:

```html
<html>
  <head>
    <title>teste</title>
    <link rel="stylesheet" href="minha-folha-de-estilos.css">
  </head>
  <body>
    <div>
      todas as divs ficarão com borda!
    </div>
  </body>
</html>
```

*Bônus(produtividade):* Utilizar a sintaxe do [Emmet](http://docs.emmet.io/cheat-sheet/).

### Atributos CSS

#### Color

![RGB](https://cwisoftware.gitbooks.io/projetocrescer/content/html-css/images/rgb.png)

Utilizando o nome (140 possibilidades de cor):
```css
color: red;
```
Formato decimal (mais de 16 milhoes de possibilidades de cor):
```css
color: rgb(255, 0, 0);
```
Formato hexadecimal (mais de 16 milhoes de possibilidades de cor):
```css
color: #FF0000; /* Nesse caso poderia ser resumido em: #F00 */
```
#### Border
```css
border-color: yellowgreen;
border-width: 4px;
border-style: dotted;
```
Ou:
```css
border: 4px dotted yellowgreen;
```
Para arredondar as pordas pode ser usado o `border-radius`:
```css
border-radius: 10px;
```
#### Dimensões
```css
width: 100px; /* Largura */
height: 100px; /* Altura */
```
[Unidades de medida CSS](https://www.tutorialspoint.com/css/css_measurement_units.htm)

#### Font

Família:
```css
font-family: serif;
font-family: sans-serif;
font-family: monospace;
```
Ordem de prioridade (caso não exista a fonte no computador, utiliza a próxima):
```css
font-family: "Arial", "Helvetica", sans-serif;
```
Estilo da fonte:
```css
font-style: italic;
font-weight: bold;
```
Tamanho:
```css
font-size: 30px;
```
#### Text

Alinhamento:
```css
text-align: right;
```
Configurações de espaçamento:

```css
line-height: 20px; /* tamanho da altura de cada linha */
letter-spacing: 2px; /* tamanho do espaço entre cada letra */
word-spacing: 5px; /* tamanho do espaço entre cada palavra */
text-indent: 20px; /* tamanho da margem da primeira linha do texto */
```

Decoração e transoformação:
```css
text-decoration: underline;
text-transform: uppercase;
```
#### Background

##### Cor:
```css
background-color: yellow;
```
##### Imagem de fundo:

```css
background-image: url(http://dominio.com.br/img.jpg);
```
Não repetir imagem:
```css
background-repeat: no-repeat;
```
Ou:
```css
background: url(http://dominio.com.br/img.jpg) no-repeat;
```
##### Múltiplas imagens de fundo
```css
background: url(pattern.png) repeat, url(wallpaper.jpg) center top no-repeat;
```
Live example:
https://www.youmovin.com.br/backoffice/#/auth
#### Espaçamento

**Padding - Espaçamento INTERNO**
Exemplo de padding
```css
padding: 10px;
```
Resultado:

![div-padding](https://cwisoftware.gitbooks.io/projetocrescer/content/html-css/images/padding-10px.png)

**Margin - Espaçamento EXTERNO**
```css
margin: 10px;
```
Resultado:

![div-margin](https://cwisoftware.gitbooks.io/projetocrescer/content/html-css/images/margin-10px.png)

Para especificar valores diferentes a cada lado, basta usar:
```css
padding-top: 10px;
padding-right: 15px;
padding-bottom: 20px;
padding-left: 5px;
margin-top: 10px;
margin-right: 15px;
margin-bottom: 20px;
margin-left: 5px;
```
Ou passando os 4 valores em ordem, no sentido: TOP, RIGHT, BOTTOM, LEFT
```css
padding: 10px 15px 20px 5px;
margin: 10px 15px 20px 5px;
```
Caso passe apenas 2 valores, o primeiro irá valer para TOP e BOTTOM, e o segundo para RIGHT E LEFT:
```css
padding: 10px 15px; /* Mesma coisa que padding: 10px 15px 10px 15px */
margin: 10px 15px; /* Mesma coisa que margin: 10px 15px 10px 15px */
```
Também é possível passar 3 valores:
```css
padding: 10px 20px 15px; /* Mesma coisa que padding: 10px 20px 15px 20px */
margin: 10px 20px 15px; /* Mesma coisa que margin: 10px 20px 15px 20px */
```
*Esses "atalhos" citados nos exemplos acima se chamam `short-handed properties`. E podem ser aplicados em diversas outras propriedades CSS.*
**Espaçamento automático**

O valor `auto` indica que aquela posição deve receber o tamanho que está disponivel aos lados daquele elemento na tela. Por exemplo:
```css
margin: 10px auto;
```
Isso irá colocar os valores de TOP e BOTTOM em `10px` e colocar o RIGTH e LEFT como `auto`, resultando na centralização do elemento horizontalmente. O resultado seria esse (a margem, em rosa, ocupando o tamanho inteiro disponível ao redor do elemento):

![margin-auto](https://cwisoftware.gitbooks.io/projetocrescer/content/html-css/images/margin-auto.png)

#### Overflow
```css
overflow: hidden;
```
Esconde o conteúdo interno que excede as dimensões do conteúdo pai.
```css
overflow: scroll;
```
Cria uma barra de scroll caso o conteúdo interno exceda as dimensões do conteúdo pai.

Exemplo:
```css
.div-pequena {
  width: 500px;
  height: 200px;
  background: darkred;
}

.div-grande {
  width: 200px;
  height: 400px;
  background: deeppink;
  overflow: hidden; /*Esconde o que exceder o conteúdo pai*/
}
```
HTML:
```html
<div class="div-pequena">
<div class="div-grande">
</div>
</div>
```
### Seletores CSS

#### Por elemento:
```css
div {
  border-style: solid;
}
```
#### Por id:
```css
#rodape {
  background: yellow;
}
```
#### Por classe:
```css
.background-feio {
  background: yellow;
}
```
#### Hierarquia:
```css
#rodape img {
  border: 1px solid black;
}
```
Isso irá setar uma borda em todas as tags `img` filhas, netas, bisnetas, ..., ∞, dentro da tag com id `rodape`. Por outro lado, isso:
```css
#rodape > img {
  border: 1px solid black;
}
```
Isso irá setar uma borda em todas as tags `img` que são filhas diretas da tag com id `rodapé`.

### Seletores avançados

#### Por atributo
```css
a[href*="facebook"] {
  font-weight: bold;
}
```
[Lista completa (com exemplos) dos attributes selectors](https://developer.mozilla.org/en-US/docs/Web/CSS/Attribute_selectors)

#### :hover
```css
a:hover {
  color: red;
}
```
#### :visited
```css
a:visited {
  color: #559;
}
```
#### :not
```css
div:not(.footer) {
  font-weight: bold;
}
```
####:first-child/:last-child
```css
ul li:first-child { /* pega o primeiro li dentro do ul */
  font-weight: bold;
}

ul li:last-child { /* pega o último li dentro do ul */
  font-weight: bold;
}
```
####:nth-child
```css
div :nth-child(3) { /* pega o terceiro elemento filho da div, independete do tipo */
  font-weight: bold;
}

div p:nth-child(3) { /* pega o terceiro elemento filho da div, contanto que ele seja um p */
  font-weight: bold;
}
```
Pode ser utilizado os valores even e odd para indicar elementos pares e ímpares, respectivamente:
```css
table tr:nth-child(even) { /* todas as linhas pares de uma tabela */
  background-color: silver;
}

table tr:nth-child(odd) { /* todas as linhas ìmpares de uma tabela */
  background-color: white;
}

table tr:nth-child(3n) { /* as linhas 3, 6, 9, 12, ..., de uma tabela */
  font-weight: bold;
}
```
####:nth-of-type

Muito parecido com o nth-child, a diferença é que isso:
```css
div p:nth-child(3) {
  font-weight: bold;
}
```
}
Pegaria isso:
```html
<div>
  <span>span</span>
  <p>parágrafo</p>
  <p>parágrafo</p> <!-- elemento selecionado -->
  <p>parágrafo</p>
</div>
```
Enquanto o nth-of-type:
```css
div p:nth-of-type(3) {
  font-weight: bold;
}
```
Pegaria:
```html
<div>
  <span>span</span>
  <p>parágrafo</p>
  <p>parágrafo</p>
  <p>parágrafo</p> <!-- elemento selecionado -->
</div>
```
####:before/:after
```css
.elemento:after {
  content: "Texto";
}

ul li:after {
  content: url('../images/small_triangle.png');
}
```
#### Ordem de prioridade CSS:

É importante ter noção que os navegadores respeitam uma certa ordem de prioridades na hora de aplicar o css em sua página.

Por exemplo, estilos que você colocar de forma "inline" nas tags redeberão uma prioridade maior do que aqueles que você colocar dentro de uma tag `style` ou na tag `link` (arquivo css extero).

##### Especificidade

Além disso, quanto mais específico for o seletor, maior será a prioridade dele.
```css
span#vermelho.azul {
  color: black;
}
#vermelho.azul {
  color: purple;
}
#vermelho {
  color: red;
}
.azul {
  color: blue;
}
span {
  color: green;
}
```
Mais detalhes [aqui](http://codepen.io/pedrohenriquepires/pen/kkjoRo).

##### Sobrescrita de atributos

O que acontece se dois seletores (com mesma especificidade) alterarem o mesmo atributo?
```html
<style>
  span {
    color: green;
  }
  span {
    color: blue;
  }
</style>
```
Nesse caso o valor aplicado será o do seletor carregado por último. Caso os seletores estejam em arquivos css separados a ideia é a mesma, o que estiver no arquivo css que foi referênciado por último na página é o que vale.

##### !important

Para driblar essa ordem de prioridade é possivel usar o `!important`, exemplo:
```css
p {
  color: blue !important;
}
```
No entanto não é ideal espalhar expressões `!important` em seu CSS, use isso somente quando for estritamente necessário!

#### Transition
```css
div {
  width: 100px;
  height: 100px;
  background: red;
  transition: background-color 2s;
}

div:hover {
  background-color: blue;
}
```
### Exercício

### Display

#### None

Elementos com o display **none**, e todos os demais elementos que estiverem dentro de sua hierarquia, são ocultados pelo navegador.
```css
display: none;
```
#### Block

É o display padrão da maioria dos elementos HTML, como div, p, ul, ol, li, table, figure, h1, h2, etc). Elementos setados com esse display são tratados como blocos que são **emplilhados um em cima do outro**, mesmo que haja espaço em seus lados.
```css
display: block;
```
Exemplo:
```html
<div style="margin: 5px; border: 1px solid cyan; width: 190px;">div 1</div>
<div style="margin: 5px; border: 1px solid blue; width: 60px;">div 2</div>
<div style="margin: 5px; border: 1px solid yellowgreen; width: 60px">div 3</div>
<div style="margin: 5px; border: 1px solid orange;width: 500px;">div 5</div>
<div style="margin: 5px; border: 1px solid red;width: 370px;">div 5</div>
```
Observe que não foi setado o `display: block` nas divs pois esse é o display padrão delas, portanto não é necessário especificar. O resultado é esse:

![divs-block](https://cwisoftware.gitbooks.io/projetocrescer/content/html-css/images/disvs-block.png)

#### Inline

Elementos com esse tipo de display são exibidos "em linha", um seja, ficam lado a lado e não ocupam o width total da tela. Algumas tags que são `inline` por default: span, a, img, em, strong.
```css
display: inline;
```
Exemplo de uso:
```html
<div style="margin: 5px; border: 1px solid cyan; width: 190px;">div 1</div>
<div style="display: inline; margin: 5px; border: 1px solid blue; width: 60px;">div 2</div>
<div style="display: inline; margin: 5px; border: 1px solid yellowgreen; width: 60px">div 3</div>
<div style="margin: 5px; border: 1px solid orange;width: 500px;">div 5</div>
<div style="margin: 5px; border: 1px solid red;width: 370px;">div 5</div>
```
Resultado:

![divs-inline](https://cwisoftware.gitbooks.io/projetocrescer/content/html-css/images/divs-inline.png)

Observe que as divs 2 e 3, setadas como `inline` não respeitam mais a propriedade `width`. Para que ela seja respeitada podemos usar o `display: inline-block`. Esse [link](http://quirksmode.org/css/css2/display.html) possui mais detalhes, com alguns *live examples* e outros tipos de display importantes, como o `display: table`.

### Float

O `float` serve para mudar o comportamento de posição de elementos `block` no navegador. Com essa propriedade CSS é possível fazer os elementos "flutuarem" à esquerda ou direita.

Como já vimos antes, por default os elementos `block` ocupam 100% do width do elemento pai, portanto, o HTML abaixo resultaria numa lista de caixas azuis, uma embaixo da outra.
```html
<html>

  <head>
    <meta charset="UTF-8">
    <title>Float</title>
    <style>
      .caixinha {
        width: 200px;
        height: 150px;
        background-color: aqua;
        border: 1px solid black;
        margin: 20px;
      }
    </style>
  </head>

  <body>
    <div>
      <div class="caixinha"></div>
      <div class="caixinha"></div>
      <div class="caixinha"></div>
      <div class="caixinha"></div>
      <div class="caixinha"></div>
      <div class="caixinha"></div>
    </div>
  </body>

</html>
```
Resultado:

![divs-sem-float](https://cwisoftware.gitbooks.io/projetocrescer/content/html-css/images/float-divs-sem-float.png)

Agora experimente adicionar a propriedade `float: left` na classe das divs, conforme o HTML abaixo, e veja o que acontece.
```html
<html>

  <head>
    <meta charset="UTF-8">
    <title>Float</title>
    <style>
      .caixinha {
        float: left;

      /* Frescuras visuais */
        width: 200px;
        height: 150px;
        background-color: aqua;
        border: 1px solid black;
        margin: 20px;
      }
    </style>
  </head>

  <body>
    <div>
      <div class="caixinha"></div>
      <div class="caixinha"></div>
      <div class="caixinha"></div>
      <div class="caixinha"></div>
      <div class="caixinha"></div>
      <div class="caixinha"></div>
    </div>
  </body>

</html>
```
Mudou completamente, não? As divs "flutuam" à esquerda uma da outra:

![float-left](https://cwisoftware.gitbooks.io/projetocrescer/content/html-css/images/float-divs-com-float-left.png)

Para "limpar" e começar numa nova linha é possível usar a propriedade `clear`. Por exemplo, se colocássemos um `clear: left` na terceira div do HTML acima, o resultado seria esse:

![float-clear-left](https://cwisoftware.gitbooks.io/projetocrescer/content/html-css/images/float-clear-left.png)

#####Cuidados:

Elemento pai de um float não calcula o tamanho dos filhos.
* Solução 1: Adicionar a propriedade `overflow: auto` no elemento pai;
* Solução 2: Adicionar um elemento no final da div, com a propriedade `clear: both`

### Position

Todas os elementos possuem `static` como valor default de sua posição.
```css
position: static;
```
O valor `static` indica que o elemento será renderizado na sua posição original, aquela em que o navegador entende como sendo sua posição "correta".

Porém é possível trocar esse comportamento através de outros valores de posição como o `relative` e o `absolute`.

#### Position Relative

Um elemento com esse atributo se comporta, aparentemente, como se fosse um `static`, ficando relativo a sua posição original. No entanto, com ele é possível usar outras propriedades CSS, como o `top`, `left`, `rigth`, `bottom` e `z-index`, e assim, mudar a posição do elemento. Exemplo:
```css
.div-relativa {
  position: relative;
  top: 10px;
  left: -20px;
}
```
O resultado é que a div ficará 10 pixels abaixo e 20 pixels à esquerda da sua posição original. O interessante de usar essas propriedades (top, left, right e bottom) é que elas não afetam os elementos irmãos e pais na hierarquia.

#### Position Absolute

Elementos com `position: absolute` usam de referência a posição de qualquer elemento que seja seu pai na estrutura do HTML cujo modo de posicionamento seja diferente de `static`. Caso nenhum elemento pai se enquadre nessa regra o que vale é o `body`.

#### Position Fixed

Utilizado para "fixar" um elemento em uma posição. Por exemplo:
```css
.header {
  position: fixed;
  top: 0px;
  left: 0px;
  width: 100%;
  height: 70px;
  background: aquamarine;
}
```
Esse elemento ficará sempre fixo no topo, mesmo que a página seja "scrollada".

### Initial vs Inherit

## Semântica HTML

### Tags de Semântica

![tags de semantica](https://cwisoftware.gitbooks.io/projetocrescer/content/html-css/images/semantic-tags-example.jpg)

#### Header

Tag utilizada para definir um cabeçalho, pode ser o header da página ou até mesmo cabeçalhos de artigos, notícias, etc. Ou seja, podem existir vários cabeçalhos em uma mesma página.

#### Footer

Objetivo equivalente ao header, só que para definir o rodapé. Pode ser o rodapé da página como um todo, ou de pequenas seções de conteúdo, como arigos, notícias, etc.

#### Article

Porção de conteúdo que poderia ser apresentado de forma independente ao site, sem peder seu significado.
Pode ser uma postagem em um fórum, um artigo de uma revista ou uma notícia.

#### Section

Das tags de semântica é uma das menos específicas. Ela indica áreas de conteúdo ou, como o nome sugere, seções de conteúdo. Um article, por exemplo, pode ter várias sections dentro dele.

#### Nav

Representa um trecho da página que aponta para outros sites ou para partes dentro da própria página. Basicamente é uma seção com links de navegação. Normalmente o header das páginas, além de conter logotipos e o nome da página, possuem também uma lista de links para navegação interna.

#### Aside

É como se fosse um complemento de conteúdo que tem uma importância um pouco menor do que o conteúdo principal a sua volta, mas que ainda assim está relacionada de alguma forma a ele.

#### Figure
```html
<figure>
  <img src="" alt="">
  <figcaption>Legenda da imagem</figcaption>
</figure>
```
#### Mas e as divs?

As divs ainda assim são amplamente utilizadas para conteúdos não semânticos. As divs podem, e devem, ser utilizadas para estruturar e estilizar o HTML, estando elas dentro ou fora de tags de semântica. Um header por exemplo, pode ter dentro dele várias divs para estruturarem os conteúdos: uma div para conter a imagem, outra para o título, e um `nav` para agrupar os links de navegação.

#### Exemplo de semântica ruim vs boa
![](https://cwisoftware.gitbooks.io/projetocrescer/content/html-css/images/html-semantico-vs-nao-semantico.png)
Imagem retirada do site [css tricks](https://css-tricks.com/semantic-class-names/).

### Microdata (microdados)

https://diveintohtml5.com.br/extensibility.html

### Meta tags
```html
<meta charset="UTF-8">
<meta name="author" content="Fabrício Rissetto">
<meta name="description" content="Apostila HTML e CSS">
<meta name="keywords" content="projeto crecer, apostila, html, css">
```
### Responsividade

#### Media Queries
```html
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8">
    <title>Document</title>
    <style>
      @media screen and (max-width: 768px) {
        p {
          color: yellow;
          font-size: 70px;
        }
      }

      @media screen and (min-width: 769px) and (max-width: 992px) {
        p {
          color: blue;
          font-size: 30px;
        }
      }

      @media screen and (min-width: 993px) {
        p {
          color: red;
          font-size: 27px;
        }
      }
    </style>
  </head>
  <body>
    <p>Hello world</p>
  </body>
</html>
```
Devemos tomar cuidado com a precedência, pois se colocarmos o seletor abaixo no fim da tag style ele vai sobrescrever os seletores de media query.
```css
p {
  color: black;
  font-size: 15px;
}
```
#### ViewPort

Dispositivos móvies normalmente "mentem" sua resolução real. Eles fazem isso para que seja possível abrir no seu navegador sites que foram feitos com resoluções voltadas a desktop. Entretanto, quando fazemos um site responsivo, precisamos nos basear na resolução real do aparelho. Isso é possivel usando a metatag abaixo:
```html
<meta name="viewport" content="width=device-width, initial-scale=1">
```

Não esqueça:

### Frameworks CSS
* Bootstrap
* Material Framework
* Semantic UI
* Foundation
* Bulma

### Outros conteúdos para estudo

#### HTML

Tags:
* video
* audio
* canvas
* svg

Novos atributos "type" dos inputs no HTML5

#### Outros atributos CSS

* tex-shadow
* box-shadow
* @import url("estilo.css");
* transform
* gradientes
* keyframes
* media types
