package br.com.crescer.aula1.tema;

import java.math.BigDecimal;
import java.util.Date;
import java.util.Map;

/**
 * @author carloshenrique
 */
public interface Parcelator {

    Map<String, BigDecimal> calcular(BigDecimal valorParcelar, int numeroParcelas, double taxaJuros, Date dataPrimeiroVencimento);

}
