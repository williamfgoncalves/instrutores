package br.com.crescer.aula3;

import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.List;
import static java.util.stream.Collectors.toList;
import java.util.stream.LongStream;

/**
 * @author carloshenrique
 */
public class TestDaoImpl implements TestDao {

    private static final String DROP_TABLE = "DROP TABLE TESTE";

    private static final String CREATE_TABLE = "CREATE TABLE TESTE ( \n"
            + "  ID NUMBER(8) NOT NULL,\n"
            + "  NOME VARCHAR2(60) DEFAULT NULL, \n"
            + "  CONSTRAINT TESTE_PK PRIMARY KEY (ID)  ENABLE \n"
            + ")";

    private static final String INSERT_TESTE = " INSERT INTO TESTE (ID, NOME) VALUES (?,?)";

    @Override
    public void insert() {
        try (final PreparedStatement preparedStatement = ConnectionUtils.getConnection().prepareStatement(INSERT_TESTE)) {
            final List<Long> list = LongStream.range(1, 1000).boxed().collect(toList());

            for (Long id : list) {
                preparedStatement.setLong(1, id);
                preparedStatement.setString(2, String.format("%s pessoa de 999", id));
                preparedStatement.executeUpdate();
            }

        } catch (final SQLException e) {
            System.err.format("SQLException: %s", e);
        }
    }

    @Override
    public void create() {
        try (final Statement statement = ConnectionUtils.getConnection().createStatement()) {
            statement.executeQuery(CREATE_TABLE);
        } catch (SQLException e) {
            System.err.format("SQLException: %s", e);
        }
    }

    @Override
    public void drop() {
        try (final Statement statement = ConnectionUtils.getConnection().createStatement()) {
            statement.executeQuery(DROP_TABLE);
        } catch (SQLException e) {
            System.err.format("SQLException: %s", e);
        }

    }

}
