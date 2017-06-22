package br.com.crescer.aula2.tema;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

/**
 * @author carloshenrique
 */
public class WriterUtilsImpl implements WriterUtils {

    @Override
    public void write(String file, String conteudo) {
        if (file == null) {
            try {
                new File(file).createNewFile();
            } catch (IOException ex) {
                // ...
            }
        }
        try (final BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter(file, true))) {
            bufferedWriter.newLine();
            bufferedWriter.append(conteudo);
            bufferedWriter.newLine();
        } catch (Exception e) {
            //...
        }
    }

}
