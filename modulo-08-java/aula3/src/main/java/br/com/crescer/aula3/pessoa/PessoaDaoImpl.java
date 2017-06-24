package br.com.crescer.aula3.pessoa;

import br.com.crescer.aula3.ConnectionUtils;
import br.com.crescer.aula3.ResultMapper;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

/**
 * @author carloshenrique
 */
public class PessoaDaoImpl extends AbstractDao<Pessoa> implements PessoaDao {

    private static final String INSERT_PESSOA = "INSERT INTO PESSOA (ID, NOME) VALUES (?,?)";
    private static final String UPDATE_PESSOA = "UPDATE PESSOA SET NOME = ? WHERE ID = ?";
    private static final String DELETE_PESSOA = "DELETE FROM PESSOA WHERE ID = ?";

    public PessoaDaoImpl() {
        super(Pessoa.class);
    }

    @Override
    public void insert(Pessoa pessoa) {
        try (final PreparedStatement preparedStatement
                = ConnectionUtils.getConnection().prepareStatement(INSERT_PESSOA)) {

            preparedStatement.setLong(1, pessoa.getId());
            preparedStatement.setString(2, pessoa.getNome());
            preparedStatement.executeUpdate();
        } catch (final SQLException e) {
            System.err.format("SQLException: %s", e);
        }
    }

    @Override
    public void update(Pessoa pessoa) {
        try (final PreparedStatement preparedStatement
                = ConnectionUtils.getConnection().prepareStatement(UPDATE_PESSOA)) {
            preparedStatement.setString(1, pessoa.getNome());
            preparedStatement.setLong(2, pessoa.getId());
            preparedStatement.executeUpdate();
        } catch (final SQLException e) {
            System.err.format("SQLException: %s", e);
        }
    }

    @Override
    public void delete(Pessoa pessoa) {
        try (final PreparedStatement preparedStatement
                = ConnectionUtils.getConnection().prepareStatement(DELETE_PESSOA)) {
            preparedStatement.setLong(1, pessoa.getId());
            preparedStatement.executeUpdate();
        } catch (final SQLException e) {
            System.err.format("SQLException: %s", e);
        }
    }

    @Override
    public Pessoa loadBy(Long id) {
        try {
            return loadBy(id, new PessoaMapper());
        } catch (Exception e) {
        }
        return null;
    }

    public class PessoaMapper implements ResultMapper<Pessoa> {

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
    }

}
