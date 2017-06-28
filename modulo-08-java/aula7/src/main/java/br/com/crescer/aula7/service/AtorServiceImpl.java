package br.com.crescer.aula7.service;

import br.com.crescer.aula7.entity.Ator;
import br.com.crescer.aula7.repository.AtorRespository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;

/**
 * @author carloshenrique
 */
@Service
public class AtorServiceImpl implements AtorService {

    @Autowired
    private AtorRespository atorRespository;

    @Override
    public Ator save(Ator a) {
        return atorRespository.save(a);
    } 

    @Override
    public Page<Ator> findAll() {
        return atorRespository.findAll(new PageRequest(0, 5));
    }

    @Override
    public Ator findOne(Long id) {
        return atorRespository.findOne(id);
    }

}
