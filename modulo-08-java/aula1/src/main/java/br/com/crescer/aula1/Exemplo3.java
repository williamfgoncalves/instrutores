package br.com.crescer.aula1;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Scanner;

/**
 * @author carloshenrique
 */
public class Exemplo3 {

    private static final SimpleDateFormat FORMAT = new SimpleDateFormat("dd/MM/yyyy");

    public static void main(String[] args) {

        try (final Scanner scanner = new Scanner(System.in)) {

            System.out.print("Informe a data:");
            String date = scanner.nextLine();

            System.out.print("\nInforme os dias:");
            int dias = scanner.nextInt();

            final Calendar calendar = Calendar.getInstance();
            calendar.setTime(FORMAT.parse(date));
            calendar.add(Calendar.DAY_OF_YEAR, dias);

            System.out.println("A data é " + FORMAT.format(calendar.getTime()));
            
        } catch (Exception e) {
            //...
        }

    }

}
