import java.util.Optional;

public class Filho extends Pai {
    
    {
        System.out.println("Oi");
    }
    
    public Filho(String versao1, int numero) {
    }
    
    public Filho(int versao2) {
        this("Valor padrão", versao2);
    }
    
    public Filho() {
    }
    
    public void deveExistirNaSubClasse() {
        {
            int a = 10;
        }
        // não consigo acessar
        // System.out.println(a);
    }

    public void deveExitirSoNaFilho() {
    }

    public void imprime() {
        super.imprime();
        System.out.println("Filho");
    }
}









