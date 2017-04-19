import java.util.ArrayList;
import java.util.stream.Collectors;

public class ListaSaints {
    private ArrayList<Saint> saints = new ArrayList<Saint>();
    
    public void adicionar(Saint saint) {
        this.saints.add(saint);
    }
    
    public Saint get(int indice) {
        return this.saints.get(indice);
    }
    
    public ArrayList<Saint> todos() {
        return this.saints;
    }
    
    public void remover(Saint saint) {
        this.saints.remove(saint);
    }
    
    public Saint buscarPorNome(String nome) {
        // C#: foreach (Saint saint in this.saints) { }
        // Python: for saint in saints:
        // JavaScript: for (let saint of saints) { }
        /*for (Saint saint : this.saints) {
            if (saint.getNome().equals(nome)) {
                return saint;
            }
        }
        return null;*/
        return this.saints.stream()
            .filter(s -> s.getNome().equals(nome))
            .findFirst()
            .orElse(null);
    }
    
    public ArrayList<Saint> buscarPorCategoria(Categoria categoria) {
        return (ArrayList<Saint>)this.saints.stream()
            .filter(s -> s.getArmadura().getCategoria().equals(categoria))
            .collect(Collectors.toList());
    }
    
    public ArrayList<Saint> buscarPorStatus(Status status) {
        return (ArrayList<Saint>)this.saints.stream()
            .filter(s -> s.getStatus().equals(status))
            .collect(Collectors.toList());
    }
    
    public Saint getSaintMaiorVida() {
        
        if (saints.isEmpty()) {
            return null;
        }
        
        Saint maiorVida = this.saints.get(0);
        for (int i = 1; i < this.saints.size(); i++) {
            Saint saint = this.saints.get(i);
            boolean encontreiMaior = saint.getVida() > maiorVida.getVida();
            if (encontreiMaior) {
                maiorVida = saint;
            }
        }
        
        return maiorVida;
    }
    
    public Saint getSaintMenorVida() {
        
        if (saints.isEmpty()) {
            return null;
        }
        
        Saint menorVida = this.saints.get(0);
        for (int i = 1; i < this.saints.size(); i++) {
            Saint saint = this.saints.get(i);
            boolean encontreiMenor = saint.getVida() < menorVida.getVida();
            if (encontreiMenor) {
                menorVida = saint;
            }
        }
        
        return menorVida;
    }
    
}
