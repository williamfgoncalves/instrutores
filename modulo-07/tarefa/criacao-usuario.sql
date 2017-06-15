-- EXECUTAR CONECTADO COM SYS !!!!!

-- criação da tablespace
create tablespace MEGASENADAT
  DATAFILE
      'C:\ORACLEXE\APP\ORACLE\ORADATA\XE\MEGASENADAT01.DBF'
      SIZE 100M
	  AUTOEXTEND ON 
	  NEXT 100M
	  MAXSIZE 4096M;

-- criação do usuário	  
Create user MEGASENA identified by MEGASENA default tablespace MEGASENADAT;

-- definição de permissões
grant connect, resource, create view to MEGASENA;


-- as permissões abaixos são importantes para a execução dos testes unitários já existentes!
grant select on dba_roles to "MEGASENA";
grant select on dba_role_privs to "MEGASENA";
---------------------------------------------
create role UT_REPO_ADMINISTRATOR;
create role UT_REPO_USER;
grant create public synonym,drop public synonym to UT_REPO_ADMINISTRATOR;
grant select on dba_role_privs to UT_REPO_USER;
grant select on dba_role_privs to UT_REPO_ADMINISTRATOR;
grant select on dba_roles to UT_REPO_ADMINISTRATOR;
grant select on dba_roles to UT_REPO_USER;
grant select on dba_tab_privs to UT_REPO_ADMINISTRATOR;
grant select on dba_tab_privs to UT_REPO_USER;
grant execute on dbms_lock to UT_REPO_ADMINISTRATOR;
grant execute on dbms_lock to UT_REPO_USER;
grant UT_REPO_USER to UT_REPO_ADMINISTRATOR with admin option;
grant UT_REPO_ADMINISTRATOR to "MEGASENA" with admin option;