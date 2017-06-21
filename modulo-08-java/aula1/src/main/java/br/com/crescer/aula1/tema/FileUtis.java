package br.com.crescer.aula1.tema;

/**
 * @author carloshenrique
 */
public interface FileUtis {

    boolean mk(String string);

    boolean rm(String string);

    String ls(String string);

    boolean mv(String in, String out);

/**
 * @author carloshenrique
 */
public interface WriterUtils {

    void write(String string);

}
}
