Crescer 2017-1 | Módulo 05 - AngularJS  

# AngularJS - Aula 04
Éverton Zanatta  
_zanatta.everton@cwi.com.br_

## Agenda
- Rotas (ngRoute)
- Ambiente (NodeJS)
- Services
- Ajax

## Guia
1. [Instalar `NodeJS`](https://nodejs.org).
2. [Instalar `http-server`](https://www.npmjs.com/package/http-server).
3. Em um novo `terminal`, entrar no diretório do exercício, executar `http-server` e acessar <http://localhost:8080>.
4. Adicionar rota para `/aulas`. Não esquecer de carreagr o `script` do *ngRoute*, colocar o módulo como dependência e da diretiva `ng-view` ([+informações](https://docs.angularjs.org/api/ngRoute)).
5. Criar `service` (factory) para `aulas`, para encapsular a lógica das operações de CRUD.
6. [Instalar `json-server`](https://github.com/typicode/json-server#install).
7. No diretório do exercício adicionar o arquivo [`db.json`](https://github.com/cwi-crescer-2017-1/instrutores/blob/master/modulo-05-angularjs/dia04/exemplo01/db.json)
6. Em um novo `terminal`, entrar no diretório do exercício, executar `json-server --watch db.json` e acessar: <http://localhost:3000/aula>.
7. Na `service` passar a consumir a nova [`api`](http://localhost:3000/aula). Observar [`contrato`](https://github.com/cwi-crescer-2017-1/instrutores/blob/master/modulo-05-angularjs/dia04/exemplo01/contrato.md)`.  

## Referências
#### Servidor vs Cliente
[Getting started with the Web](https://developer.mozilla.org/en-US/docs/Learn/Getting_started_with_the_web)   
[Common questions](https://developer.mozilla.org/en-US/docs/Learn/Common_questions)  
[HTTP: The Protocol Every Web Developer Must Know](https://code.tutsplus.com/tutorials/http-the-protocol-every-web-developer-must-know-part-1--net-31177)    

#### Rotas
[ngRoute](https://docs.angularjs.org/api/ngRoute)  
[$route](https://docs.angularjs.org/api/ngRoute/service/$route)  
[$routeProvider](https://docs.angularjs.org/api/ngRoute/provider/$routeProvider)  

#### Services (factory)
[Services](https://docs.angularjs.org/guide/services)  
[Tipos de Services](https://rafaell-lycan.com/2015/angular-services-factories-providers)  

#### Requisições HTTP ($http)
[$http](https://docs.angularjs.org/api/ng/service/$http)  

#### JSON Server (API)
[Como usar](https://egghead.io/lessons/nodejs-creating-demo-apis-with-json-server)  
[Postman - Chrome Extension](https://chrome.google.com/webstore/detail/postman/fhbjgbiflinjbdggehcddcbncdddomop)  
