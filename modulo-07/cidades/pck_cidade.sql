/*

  Package que permite eliminar cidades duplicadas alterando os clientes
  
*/

create or replace package pck_cidade as
  
  procedure ajusta_cidade_cliente(pNome in varchar2, 
                                  pUF in varchar2, 
                                  pMenorIDCidade in integer);
  procedure exclui_cidades_duplicadas(pNome in varchar2, 
                                      pUF in varchar2, 
                                      pMenorIDCidade in integer);
  procedure elimina_duplicadas;
                                        
end;
/


create or replace package body pck_cidade as
  
  /* Altera clientes com cidades duplicadas */
  procedure ajusta_cidade_cliente(pNome          in varchar2, 
                                  pUF            in varchar2, 
                                  pMenorIDCidade in integer) as
  begin
     
     Update Cliente
     Set    IDCidade  = pMenorIDCidade
     Where  exists (Select 1
                    From   Cidade cid
                    where  cid.Nome     = pNome
                    and    cid.UF       = pUF
                    and    cid.IDCidade = cliente.IDCidade)
     and    IDCidade != pMenorIDCidade;                    
    
  end ajusta_cidade_cliente;
  --------------------------------------------------------------------------------------------
  /* Exclui cidades duplicadas */
  procedure exclui_cidades_duplicadas(pNome in varchar2, 
                                      pUF in varchar2, 
                                      pMenorIDCidade in integer) as
  begin
  
     Delete Cidade
     Where  Nome      = pNome
     and    UF        = pUF
     and    IDCidade != pMenorIDCidade;
     
  end exclui_cidades_duplicadas;
  --------------------------------------------------------------------------------------------
  /* Processo principal */
  procedure elimina_duplicadas as
  
     cursor cidades_duplicadas is
         select Nome, UF, MIN(IDCidade) MenorIDCidade
         from   Cidade
         group  by Nome, UF
         having count(1) > 1;
  
  begin
    
     for c in cidades_duplicadas loop     
        ajusta_cidade_cliente(pNome=> c.Nome, pUF=> c.UF, pMenorIDCidade=>c.MenorIDCidade);
        exclui_cidades_duplicadas(pNome=> c.Nome, pUF=> c.UF, pMenorIDCidade=>c.MenorIDCidade);     
     end loop;
    
  end elimina_duplicadas;


end pck_cidade;
/
