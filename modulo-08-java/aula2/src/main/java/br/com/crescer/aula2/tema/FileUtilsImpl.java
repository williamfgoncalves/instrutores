package br.com.crescer.aula2.tema;

import java.io.File;
import java.util.Arrays;
import static java.util.stream.Collectors.toList;

/**
 * @author carloshenrique
 */
public class FileUtilsImpl implements FileUtils {

    @Override
    public boolean mk(String s) {
        if (s != null) {
            try {
                File file = new File(s);
                if (file.getParentFile() != null) {
                    file.getParentFile().mkdirs();
                }
                return file.exists() || s.matches(".*\\..{3}") ? file.createNewFile() : file.mkdir();
            } catch (Exception e) {
            }
        }
        return false;
    }

    @Override
    public boolean rm(String string) {
        if (string != null) {
            final File file = new File(string);
            if (file.exists() && file.isDirectory()) {
                throw new RuntimeException("Arquivo inválido");
            }
            return file.delete();
        }
        return false;
    }

    @Override
    public String ls(String string) {
        if (string != null) {
            final File file = new File(string);
            if (!file.exists()) {
                return null;
            } else if (file.isDirectory()) {
                try {
                    return String.join("\n", Arrays.asList(file.listFiles())
                            .stream()
                            .map(File::getAbsolutePath)
                            .collect(toList()));
                } catch (Exception e) {
                    // ...
                }
            } else {
                return file.getAbsolutePath();
            }
        }
        return null;
    }

    @Override
    public boolean mv(String in, String out) {
        if (in != null && out != null) {
            File file = new File(in);
            if (file.exists() && file.isDirectory()) {
                throw new RuntimeException("Arquivo inválido");
            }
            
            return file.renameTo(new File(out));
        }
        return false;

    }

}
