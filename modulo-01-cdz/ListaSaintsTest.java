import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import java.util.ArrayList;

public class ListaSaintsTest {

    @Test public void buscarSaintExistentePorNome() throws Exception {
        ListaSaints lista = new ListaSaints();
        Saint june = new Saint("June", new Armadura(new Constelacao("Camaleão"), Categoria.BRONZE));
        lista.adicionar(june);
        assertEquals(june, lista.buscarPorNome("June"));
    }

    @Test public void buscarSaintExistenteComRepeticaoDeNomes() throws Exception {
        ListaSaints lista = new ListaSaints();
        Saint june = new Saint("June", new Armadura(new Constelacao("Camaleão"), Categoria.BRONZE));
        Saint june2 = new SilverSaint("June", new Armadura(new Constelacao("Camaleão 2"), Categoria.PRATA));
        lista.adicionar(june2);
        lista.adicionar(june);
        assertEquals(june2, lista.buscarPorNome("June"));
    }

    @Test public void buscarSaintInexistente() throws Exception {
        ListaSaints lista = new ListaSaints();
        Saint june = new Saint("June", new Armadura(new Constelacao("Camaleão"), Categoria.BRONZE));
        Saint june2 = new SilverSaint("June", new Armadura(new Constelacao("Camaleão 2"), Categoria.PRATA));
        lista.adicionar(june2);
        lista.adicionar(june);
        assertNull(lista.buscarPorNome("San Junipero"));
    }

    @Test public void buscarSaintComListaVazia() {
        assertNull(new ListaSaints().buscarPorNome("Seiya"));
    }

    @Test
    public void buscarPorCategoriaListaVazia() {
        ListaSaints listaSaints = new ListaSaints();
        ArrayList<Saint> resultadoBusca = listaSaints.buscarPorCategoria(Categoria.BRONZE);
        assertEquals(new ArrayList<Saint>(), resultadoBusca);
    }

    @Test
    public void buscarPorCategoriaInexistente() throws Exception {
        ListaSaints listaSaints = new ListaSaints();
        Saint june = new Saint("June", new Armadura(new Constelacao("Camaleão"), Categoria.BRONZE));
        listaSaints.adicionar(june);
        ArrayList<Saint> resultadoBusca = listaSaints.buscarPorCategoria(Categoria.PRATA);
        assertEquals(new ArrayList<Saint>(), resultadoBusca);
    }

    @Test
    public void buscarPorCategoriaExistente() throws Exception {
        ListaSaints listaSaints = new ListaSaints();
        Saint june = new Saint("June", new Armadura(new Constelacao("Camaleão"), Categoria.BRONZE));
        Saint misty = new SilverSaint("Misty", new Armadura(new Constelacao("Lagarto"), Categoria.PRATA));
        listaSaints.adicionar(misty);
        listaSaints.adicionar(june);
        ArrayList<Saint> resultadoBusca = listaSaints.buscarPorCategoria(Categoria.BRONZE);
        assertEquals(june, resultadoBusca.get(0));
        assertEquals(1, resultadoBusca.size());
    }

    @Test
    public void buscarPorCategoriaComMaisDeUmExistenteNaCategoria() throws Exception {
        ListaSaints listaSaints = new ListaSaints();
        Saint june = new Saint("June", new Armadura(new Constelacao("Camaleão"), Categoria.BRONZE));
        Saint misty = new SilverSaint("Misty", new Armadura(new Constelacao("Lagarto"), Categoria.PRATA));
        Saint shun = new Saint("June", new Armadura(new Constelacao("Andrômeda"), Categoria.BRONZE));
        listaSaints.adicionar(shun);
        listaSaints.adicionar(misty);
        listaSaints.adicionar(june);
        ArrayList<Saint> resultadoBusca = listaSaints.buscarPorCategoria(Categoria.BRONZE);
        assertEquals(shun, resultadoBusca.get(0));
        assertEquals(june, resultadoBusca.get(1));
        assertEquals(2, resultadoBusca.size());
    }

}
