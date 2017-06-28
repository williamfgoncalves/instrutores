package br.com.crescer.aula7.service;

import br.com.crescer.aula7.entity.Ator;
import org.springframework.data.domain.Page;

/**
 * @author carloshenrique
 */
public interface AtorService {

    Ator save(Ator a);

    Page<Ator> findAll();

    Ator findOne(Long id);
}
