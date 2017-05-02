/*
1) Faça uma consulta que liste o total de empregados admitidos no ano de 1980. 
   Deve ser projetado nesta consulta: ID, Nome e Idade no momento da admissão.
*/

-- Nesta consulta foi aplicado o BETWEEN para que não seja necessário aplicar funções sobre colunas.
-- O uso de funções sobre colunas na cláusula WHERE pode ser prejudicial para o desempenho
Select COUNT(1) TotalEmpregados
From   Empregado
Where  DataAdmissao between CONVERT(date, '01/01/1980', 103)   
                        and CONVERT(date, '31/12/1980', 103)
go

/*
2) Qual o cargo (tabela empregado) possui mais empregados ? Deve ser projetado apenas um registro. 
   ** DICA: Pesquise recursos específicos para esta funcionalidade.
*/

-- para o critério de desempate deve-se utilizar o recurso de WITH TIES no TOP, neste caso não haveria a necessidade
Select TOP 1 WITH TIES
       Cargo,
	   COUNT(1) TotalEmpregados
  From Empregado
 Group by Cargo
 Order by TotalEmpregados desc


 /*
 3) Liste os estados (atributo UF) e o total de cidades existente em cada estado na tabela cidade.
 */

 Select UF,
        COUNT(1) TotalCidades
   From Cidade
  Group by UF

/*
 4) Crie um novo departamento, denominado 'Inovação' com localização em 'SÃO LEOPOLDO'. 
    Todos os empregados que foram admitidos no mês de dezembro (qualquer ano) que não ocupam o cargo de 'Atendente' 
	devem ser ter o departamento (IDDepartamento) atualizado para este novo registro (inovação).
*/

begin transaction
go

Insert into Departamento 
  (IDDepartamento, NomeDepartamento, Localizacao)
  values
  (70, 'Inovação', 'SAO LEOPOLDO')
go

Update Empregado
set    IDDepartamento = 70
where  MONTH(DataAdmissao) = 12  -- função que extrai apenas o mês de uma data
  and  Cargo != 'Atendente'
go

commit
go
