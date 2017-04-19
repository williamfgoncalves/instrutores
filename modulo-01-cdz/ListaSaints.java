import java.util.ArrayList;

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
        ArrayList<Saint> subLista = new ArrayList<Saint>();
        //
        for (Saint saint : this.saints) {
            if (saint.getArmadura().getCategoria().equals(categoria)) {
                subLista.add(saint);
            }
        }
        return subLista;
    }
    
}
