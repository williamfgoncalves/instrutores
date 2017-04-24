public class Golpear implements Movimento {
    
    private Saint golpeador, golpeado;
    
    public Golpear(Saint golpeador, Saint golpeado) {
        this.golpeador = golpeador;
        this.golpeado = golpeado;
    }
    
    public void executar() {
        Golpe golpe = this.golpeador.getProximoGolpe();
        int danoCalculado = golpe.getFatorDano();
        
        if (this.golpeador.getArmaduraVestida()) {
            danoCalculado *= 1 + this.golpeador.getArmadura().getCategoria().getValor();
        }
        
        this.golpeado.perderVida(danoCalculado);
    }
}