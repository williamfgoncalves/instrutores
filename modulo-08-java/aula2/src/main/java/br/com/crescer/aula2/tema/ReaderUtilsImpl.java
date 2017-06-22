package br.com.crescer.aula2.tema;

import java.io.BufferedReader;
import java.io.FileReader;
import static java.util.stream.Collectors.toList;

/**
 * @author carloshenrique
 */
public class ReaderUtilsImpl implements ReaderUtils {

    @Override
    public String read(String string) {
        try (final BufferedReader b = new BufferedReader(new FileReader(string))) {
            return String.join("\n", b.lines().collect(toList()));
        } catch (Exception e) {
            // ...
        }
        return null;
    }

}
