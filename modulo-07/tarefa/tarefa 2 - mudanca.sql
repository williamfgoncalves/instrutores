/*
  
  Devido à uma falha no sistema uma aposta do DF não foi registrada no sistema.
  Em tempo, seguem os dados!
  
  Executar dentro da base da megasena!  
*/

insert into Aposta (Idaposta, Idconcurso, Idcidade, Data_Hora, Quantidade_Numeros, Valor)
  values (5000124, 1824, 171, sysdate, 6, 3.5);

insert into Numero_Aposta (idnumero_aposta, idaposta, numero) values (sqnumero_aposta.nextval, 5000124, 14); 
insert into Numero_Aposta (idnumero_aposta, idaposta, numero) values (sqnumero_aposta.nextval, 5000124, 15);
insert into Numero_Aposta (idnumero_aposta, idaposta, numero) values (sqnumero_aposta.nextval, 5000124, 23);
insert into Numero_Aposta (idnumero_aposta, idaposta, numero) values (sqnumero_aposta.nextval, 5000124, 54);
insert into Numero_Aposta (idnumero_aposta, idaposta, numero) values (sqnumero_aposta.nextval, 5000124, 27);
insert into Numero_Aposta (idnumero_aposta, idaposta, numero) values (sqnumero_aposta.nextval, 5000124, 46);

commit;
