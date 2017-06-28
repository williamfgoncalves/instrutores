package br.com.crescer.aula7.application;

import br.com.crescer.aula7.entity.Ator;
import com.fasterxml.jackson.databind.ObjectMapper;
import java.util.Map;
import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNotNull;
import static org.junit.Assert.assertTrue;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.context.embedded.LocalServerPort;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.context.SpringBootTest.WebEnvironment;
import org.springframework.boot.test.web.client.TestRestTemplate;
import org.springframework.test.context.ActiveProfiles;
import org.springframework.test.context.junit4.SpringRunner;

/**
 * @author carloshenrique
 */
@RunWith(SpringRunner.class)
@SpringBootTest(webEnvironment = WebEnvironment.RANDOM_PORT)
@ActiveProfiles("test")
public class IntegrationTest {

    @LocalServerPort
    private int port;

    @Autowired
    private TestRestTemplate restTemplate;
    
    @Autowired
    private ObjectMapper mapper;

    /**
     * Test of getCurrentDateTime method, of class TestController.
     */
    @Test
    public void testGetCurrentDateTime() {
        final Map map = this.restTemplate.getForObject("http://localhost:" + port + "/ator/current_date_time.php", Map.class);
        assertNotNull(map.containsKey("data"));
    }

    /**
     * Test of findOne method, of class TestController.
     */
    @Test
    public void testFindOne() {
        final Long id = Long.valueOf(1);
        assertEquals(id, this.restTemplate.getForObject("http://localhost:" + port + "/ator/" + id, Ator.class).getId());
    }

    /**
     * Test of findAll method, of class TestController.
     */
    @Test
    public void testFindAll() {
        final String json = this.restTemplate.getForObject("http://localhost:" + port + "/ator", String.class);
        assertTrue(json.contains("content"));
    }

}
