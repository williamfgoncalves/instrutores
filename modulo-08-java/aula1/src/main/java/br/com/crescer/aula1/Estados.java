package br.com.crescer.aula1;

/**
 * @author carloshenrique
 */
public enum Estados {

    AC("Acre"),
    AL("Alagoas"),
    ES("EspíritoSanto"),
    AP("Amapá"),
    BA("Bahia"),
    CE("Ceará"),
    DF("DistritoFederal"),
    GO("Goiás"),
    MA("Maranhão"),
    SC("SantaCatarina"),
    MG("MinasGerais"),
    MT("MatoGrosso"),
    MS("MatoGrossodoSul"),
    PA("Pará"),
    RS("RioGrandedoSul"),
    PE("Pernambuco"),
    PI("Piauí"),
    AM("Amazonas"),
    PR("Paraná"),
    RJ("RiodeJaneiro"),
    RN("RioGrandedoNorte"),
    PB("Paraíba"),
    RO("Rondônia"),
    RR("Roraima"),
    SE("Sergipe"),
    SP("SãoPaulo"),
    TO("Tocantins");

    private final String nome;

    private Estados(String nome) {
        this.nome = nome;
    }

    public String getNome() {
        return nome;
    }
}
