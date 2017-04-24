import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

public class BatalhaTest {
    @Test
    public void categoriaSaint1MaiorQueSaint2() throws Exception {
        // Arrange
        Saint shaina = new SilverSaint("Shaina", new Armadura(new Constelacao("Serpente"), Categoria.PRATA));
        Saint hyoga = new BronzeSaint("Hyoga", new Armadura(new Constelacao("Cisne"), Categoria.BRONZE));
        Batalha batalha = new Batalha(shaina, hyoga);
        // Act
        batalha.iniciar();
        // Assert
        assertEquals(100, shaina.getVida(), 0.01);
        assertEquals(90, hyoga.getVida(), 0.01);
    }
    
    @Test
    public void categoriasIguaisSaint2PerdeVida() throws Exception {
        // Arrange
        Saint aldebaran = new GoldSaint("Aldebaran", new Armadura(new Constelacao("Touro"), Categoria.OURO));
        Saint mascaraMorte = new GoldSaint("Máscara da Morte", new Armadura(new Constelacao("Câncer"), Categoria.OURO));
        Batalha batalha = new Batalha(aldebaran, mascaraMorte);
        // Act
        batalha.iniciar();
        // Assert
        assertEquals(100, aldebaran.getVida(), 0.01);
        assertEquals(90, mascaraMorte.getVida(), 0.01);
    }
    
    @Test
    public void categoriaSaint2MaiorSaint1PerdeVida() throws Exception {
        // Arrange
        Saint ikki = new BronzeSaint("Ikki", new Armadura(new Constelacao("Fênix"), Categoria.BRONZE));
        Saint mascaraMorte = new GoldSaint("Máscara da Morte", new Armadura(new Constelacao("Câncer"), Categoria.OURO));
        Batalha batalha = new Batalha(ikki, mascaraMorte);
        // Act
        batalha.iniciar();
        // Assert
        assertEquals(90, ikki.getVida(), 0.01);
        assertEquals(100, mascaraMorte.getVida(), 0.01);
    }
}