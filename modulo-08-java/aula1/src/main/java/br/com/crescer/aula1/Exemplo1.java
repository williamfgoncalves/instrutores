package br.com.crescer.aula1;

import java.text.Normalizer;
import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import static java.util.stream.Collectors.toList;
import java.util.stream.Stream;

/**
 * @author carloshenrique
 */
public class Exemplo1 {

    public static void main(String[] args) {
        // Usando o java 7  
        final List<Estados> estados = Arrays.asList(Estados.values());
        Collections.sort(estados, new Comparator<Estados>() {
            @Override
            public int compare(Estados e, Estados e1) {
                return normalize(e.getNome()).compareTo(normalize(e1.getNome()));
            }
        });

        final StringBuilder builder = new StringBuilder();
        for (final Estados estado : estados) {
            builder.append(estado.getNome()).append(", ");
        }

        builder.deleteCharAt(builder.toString().trim().length() - 1);
        System.out.println(builder);

        final Stream<String> map = estados.stream().map(Estados::getNome);
        final Comparator<String> name = (e, e1) -> normalize(e).compareTo(normalize(e1));
//         Usando java 8 
        String.join(", ", Arrays
                .asList(Estados.values())
                .stream()
                .filter(Estados.AC::equals)
                .map(Estados::getNome)
                .sorted((e, e1) -> normalize(e).compareTo(normalize(e1)))
                .collect(toList())
        );

    }

    private static String normalize(String nome) {
        return Normalizer.normalize(nome, Normalizer.Form.NFD)
                .replaceAll("\\p{InCombiningDiacriticalMarks}+", "");
    }

}
