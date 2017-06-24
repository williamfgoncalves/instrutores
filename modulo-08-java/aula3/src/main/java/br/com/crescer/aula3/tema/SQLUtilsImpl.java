package br.com.crescer.aula3.tema;

import br.com.crescer.aula3.ConnectionUtils;
import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author carloshenrique
 */
public class SQLUtilsImpl implements SQLUtils {

    @Override
    public void runFile(String filename) {
        if (filename == null || !filename.contains(".sql")) {
            throw new RuntimeException("Arquivo Inválido");
        }
        try {
            final String script = String.join(" ", Files.readAllLines(Paths.get(filename)));
            try (final Connection connection = ConnectionUtils.getConnection();
                    final Statement statement = connection.createStatement();) {
                for (String sql : script.split(";")) {
                    statement.execute(sql);
                }
            } catch (SQLException e) {
                System.err.format("SQLException: %s", e);
            }
        } catch (IOException e) {

        }
    }

    @Override
    public String executeQuery(String query) {
        return executeQuery(query, "|");
    }

    @Override
    public void importCSV(File file) {
        if (file == null || !file.getName().contains(".csv")) {
            throw new RuntimeException("Arquivo Inválido");
        }
        final String tableName = file.getName().replaceAll("(.*)\\.\\w{3}", "$1");

        try {

            final String template = "INSERT INTO %1s (%2s) VALUES (%3s)";
            final List<String> lines = Files.readAllLines(file.toPath());

            final String cols = String.join(",", lines.stream().findFirst().get().split(";"));
            final String sql = String.format(template, tableName, cols, cols.replaceAll("\\w{1,}", "?"));

            try (final Connection connection = ConnectionUtils.getConnection();
                    final PreparedStatement preparedStatement = connection.prepareStatement(sql);) {
                connection.setAutoCommit(false);
                for (int i = 1; i < lines.size(); i++) {
                    final String[] vals = lines.get(i).split(";");
                    for (int j = 0; j < vals.length; j++) {
                        preparedStatement.setObject(j + 1, vals[j]);
                    }
                    preparedStatement.executeUpdate();
                }
                connection.commit();
            } catch (SQLException e) {
                System.err.format("SQLException: %s", e);
            }
        } catch (IOException e) {
            //...
        }
    }

    @Override
    public File exportCSV(String query) {
        final String result = executeQuery(query, ";");
        final Path path;
        try {
            path = Files.createTempFile("result", "css");
            Files.write(path, result.getBytes());
            return path.toFile();
        } catch (IOException ex) {
            Logger.getLogger(SQLUtilsImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }

    /**
     * Retorna um string com um delimitador
     *
     * @param query
     * @param delimiter
     * @return String
     */
    private String executeQuery(String query, String delimiter) {
        final StringBuilder sb = new StringBuilder();
        try (final Connection connection = ConnectionUtils.getConnection();
                final Statement statement = connection.createStatement();
                final ResultSet resultSet = statement.executeQuery(query);) {
            final ResultSetMetaData metaData = resultSet.getMetaData();
            for (int i = 1; i <= metaData.getColumnCount(); i++) {
                sb.append(metaData.getColumnName(i));
                sb.append(delimiter);
            }
            sb.append("\n");
            while (resultSet.next()) {
                for (int i = 1; i <= metaData.getColumnCount(); i++) {
                    sb.append(resultSet.getObject(metaData.getColumnName(i)));
                    sb.append(delimiter);
                }
                sb.append("\n");
            }
        } catch (SQLException e) {
            System.err.format("SQLException: %s", e);
        }
        return sb.toString();
    }

    public static void main(String[] args) {
        System.out.println("id_pessoa, nm_pessoa, _dt".replaceAll("\\w{1,}", "?"));
    }

}
