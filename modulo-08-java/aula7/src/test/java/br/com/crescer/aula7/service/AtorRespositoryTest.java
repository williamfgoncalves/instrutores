package br.com.crescer.aula7.service;

import br.com.crescer.aula7.entity.Ator;
import br.com.crescer.aula7.repository.AtorRespository;
import static java.util.stream.Collectors.toList;
import java.util.stream.StreamSupport;
import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.jdbc.AutoConfigureTestDatabase;
import org.springframework.boot.test.autoconfigure.jdbc.AutoConfigureTestDatabase.Replace;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.autoconfigure.orm.jpa.TestEntityManager;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;

/**
 * @author carloshenrique
 */
@RunWith(SpringRunner.class)
@DataJpaTest
@Transactional(propagation = Propagation.REQUIRED)
@AutoConfigureTestDatabase(replace = Replace.NONE)
public class AtorRespositoryTest {

    @Autowired
    private TestEntityManager testEntityManager;

    @Autowired
    private AtorRespository atorRespository;

    /**
     * Test of save method, of class AtorService.
     */
    @Test
    public void testSave() {
        final Ator ator = new Ator();
        ator.setNome("Carlos");
        atorRespository.save(ator);
        assertEquals(ator.getNome(), testEntityManager.find(Ator.class, ator.getId()).getNome());
    }

    /**
     * Test of findAll method, of class AtorService.
     */
    @Test
    public void testFindAll() {
        final Ator ator = new Ator();
        ator.setNome("Carlos");
        testEntityManager.persist(ator);

        assertTrue(StreamSupport.stream(atorRespository.findAll().spliterator(), false)
                .map(Ator::getNome)
                .collect(toList())
                .contains(ator.getNome()));

    }

    /**
     * Test of findOne method, of class AtorService.
     */
    @Test
    public void testFindOne() {
        final Ator ator = new Ator();
        ator.setNome("Carlos");
        testEntityManager.persist(ator);
        assertEquals(ator.getNome(), atorRespository.findOne(ator.getId()).getNome());
    }

}
