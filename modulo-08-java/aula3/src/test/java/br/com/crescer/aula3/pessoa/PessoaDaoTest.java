package br.com.crescer.aula3.pessoa;

import br.com.crescer.aula3.AbstractDaoTest;
import br.com.crescer.aula3.ResultMapper;
import java.sql.ResultSet;
import java.sql.SQLException;
import org.junit.After;
import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNull;
import org.junit.Test;

/**
 * @author carloshenrique
 */
public class PessoaDaoTest extends AbstractDaoTest implements DaoTest {

    private static final Long ID = 99999999L;

    private final PessoaDao pessoaDao;

    public PessoaDaoTest() {
        this.pessoaDao = new PessoaDaoImpl();
    }

    @After
    public void setAfter() {
        executeUpdate("DELETE FROM PESSOA WHERE ID = " + ID);
    }

    @Test
    @Override
    public void testInsert() {
        final Pessoa pessoa = new Pessoa();
        pessoa.setId(ID);
        pessoa.setNome("teste");
        pessoaDao.insert(pessoa);
        assertEquals(pessoa.getNome(), loadPessoa(ID).getNome());
    }

    @Test
    @Override
    public void testUpdate() {
        executeUpdate("INSERT INTO PESSOA (ID, NOME) VALUES (" + ID + ", 'ABC')");
        final Pessoa pessoa = new Pessoa();
        pessoa.setId(ID);
        pessoa.setNome("teste");
        pessoaDao.update(pessoa);
        assertEquals(pessoa.getNome(), loadPessoa(ID).getNome());
    }

    @Test
    @Override
    public void testDelete() {
        executeUpdate("INSERT INTO PESSOA (ID, NOME) VALUES (" + ID + ", 'ABC')");
        final Pessoa pessoa = new Pessoa();
        pessoa.setId(ID);
        pessoa.setNome("teste");
        pessoaDao.delete(pessoa);
        assertNull(loadPessoa(ID));
    }

    @Test
    @Override
    public void testLoadBy() {
        executeUpdate("INSERT INTO PESSOA (ID, NOME) VALUES (" + ID + ", 'ABC')");
        final Pessoa pessoa = pessoaDao.loadBy(ID);
        assertEquals(pessoa.getNome(), loadPessoa(ID).getNome());
    }

    /**
     * Retorna a pessoal cadastrada com o ID
     *
     * @return Pessoa
     */
    private Pessoa loadPessoa(Long idPessoa) {
        final Pessoa pessoa = executeQuery("SELECT * FROM PESSOA WHERE ID = " + idPessoa, new ResultMapper<Pessoa>() {
            @Override
            public Pessoa mapper(ResultSet resultSet) throws SQLException {
                if (resultSet.next()) {
                    final Pessoa pessoa = new Pessoa();
                    pessoa.setId(resultSet.getLong("ID"));
                    pessoa.setNome(resultSet.getString("NOME"));
                    return pessoa;
                }
                return null;
            }
        });
        return pessoa;
    }

}
