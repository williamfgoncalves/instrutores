package br.com.crescer.aula1;

import java.util.List;
import static java.util.stream.Collectors.toList;
import java.util.stream.LongStream;

/**
 * @author carloshenrique
 */
public class Exemplo2 {

    public static void main(String[] args) {

        final List<Long> longs = LongStream.range(0, 10).boxed().collect(toList());

        longs.stream()
                .forEach(l -> {
                    try {
                        Thread.sleep(1000l);
                    } catch (Exception e) {
                    }

                    System.out.println(l);
                });

        longs.parallelStream()
                .forEach(l -> {
                    try {
                        Thread.sleep(1000l);
                    } catch (Exception e) {
                    }

                    System.out.println(l);
                });

        for (Long l : longs) {
            try {
                Thread.sleep(100l);
            } catch (Exception e) {
            }
        }
    }

}
