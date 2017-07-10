package br.com.crescer.social.service;

import java.math.BigDecimal;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 * @author carloshenrique
 */
@Service
public class ExemploService {

    @Autowired
    private Exemplo2Service service2;

    public BigDecimal get() {
        service2.save(BigDecimal.ZERO);
        return service2.getTen();
    }

}
