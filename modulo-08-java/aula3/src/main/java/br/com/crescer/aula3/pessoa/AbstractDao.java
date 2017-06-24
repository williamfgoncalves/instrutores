package br.com.crescer.aula3.pessoa;

import br.com.crescer.aula3.ConnectionUtils;
import br.com.crescer.aula3.ResultMapper;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

/**
 *
 * @author carloshenrique
 */
public abstract class AbstractDao<T> {

    public Class<T> clazz;

    public AbstractDao(Class<T> clazz) {
        this.clazz = clazz;
    }

    private String query = "SELECT * FROM %s WHERE ID = ?";

    public T loadBy(Long id, ResultMapper<T> r) throws SQLException {
        T t = null;
        try (final Connection connection = ConnectionUtils.getConnection();
                final PreparedStatement preparedStatement = connection.prepareStatement(String.format(query, clazz.getSimpleName()))) {
            preparedStatement.setLong(1, id);
            try (final ResultSet resultSet = preparedStatement.executeQuery()) {
                t = r.mapper(resultSet);
            } catch (final SQLException e) {
                System.err.format("SQLException: %s", e);
            }
        } catch (final SQLException e) {
            System.err.format("SQLException: %s", e);
        }
        return t;
    }

}
