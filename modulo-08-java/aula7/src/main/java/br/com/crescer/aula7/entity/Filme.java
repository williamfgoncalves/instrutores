/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.com.crescer.aula7.entity;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author carloshenrique
 */
@Entity
@Table(name = "FILME")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Filme.findAll", query = "SELECT f FROM Filme f")
    , @NamedQuery(name = "Filme.findByIdFilme", query = "SELECT f FROM Filme f WHERE f.idFilme = :idFilme")
    , @NamedQuery(name = "Filme.findByNmDiretor", query = "SELECT f FROM Filme f WHERE f.nmDiretor = :nmDiretor")
    , @NamedQuery(name = "Filme.findByDtLancamento", query = "SELECT f FROM Filme f WHERE f.dtLancamento = :dtLancamento")
    , @NamedQuery(name = "Filme.findByDsTitulo", query = "SELECT f FROM Filme f WHERE f.dsTitulo = :dsTitulo")})
public class Filme implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "ID_FILME")
    private BigDecimal idFilme;
    @Size(max = 255)
    @Column(name = "NM_DIRETOR")
    private String nmDiretor;
    @Column(name = "DT_LANCAMENTO")
    @Temporal(TemporalType.TIMESTAMP)
    private Date dtLancamento;
    @Size(max = 255)
    @Column(name = "DS_TITULO")
    private String dsTitulo;
    @JoinColumn(name = "CLASSIFICACAO_ID_CLASSIFICACAO", referencedColumnName = "ID_CLASSIFICACAO")
    @ManyToOne
    private Classificacao classificacaoIdClassificacao;
    @JoinColumn(name = "ELENCO_ID_ELENCO", referencedColumnName = "ID_ELENCO")
    @ManyToOne
    private Elenco elencoIdElenco;
    @JoinColumn(name = "GENERO_ID_GENERO", referencedColumnName = "ID_GENERO")
    @ManyToOne
    private Genero generoIdGenero;
    @JoinColumn(name = "IDIOMA_ID_IDIOMA", referencedColumnName = "ID_IDIOMA")
    @ManyToOne
    private Idioma idiomaIdIdioma;

    public Filme() {
    }

    public Filme(BigDecimal idFilme) {
        this.idFilme = idFilme;
    }

    public BigDecimal getIdFilme() {
        return idFilme;
    }

    public void setIdFilme(BigDecimal idFilme) {
        this.idFilme = idFilme;
    }

    public String getNmDiretor() {
        return nmDiretor;
    }

    public void setNmDiretor(String nmDiretor) {
        this.nmDiretor = nmDiretor;
    }

    public Date getDtLancamento() {
        return dtLancamento;
    }

    public void setDtLancamento(Date dtLancamento) {
        this.dtLancamento = dtLancamento;
    }

    public String getDsTitulo() {
        return dsTitulo;
    }

    public void setDsTitulo(String dsTitulo) {
        this.dsTitulo = dsTitulo;
    }

    public Classificacao getClassificacaoIdClassificacao() {
        return classificacaoIdClassificacao;
    }

    public void setClassificacaoIdClassificacao(Classificacao classificacaoIdClassificacao) {
        this.classificacaoIdClassificacao = classificacaoIdClassificacao;
    }

    public Elenco getElencoIdElenco() {
        return elencoIdElenco;
    }

    public void setElencoIdElenco(Elenco elencoIdElenco) {
        this.elencoIdElenco = elencoIdElenco;
    }

    public Genero getGeneroIdGenero() {
        return generoIdGenero;
    }

    public void setGeneroIdGenero(Genero generoIdGenero) {
        this.generoIdGenero = generoIdGenero;
    }

    public Idioma getIdiomaIdIdioma() {
        return idiomaIdIdioma;
    }

    public void setIdiomaIdIdioma(Idioma idiomaIdIdioma) {
        this.idiomaIdIdioma = idiomaIdIdioma;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idFilme != null ? idFilme.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Filme)) {
            return false;
        }
        Filme other = (Filme) object;
        if ((this.idFilme == null && other.idFilme != null) || (this.idFilme != null && !this.idFilme.equals(other.idFilme))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "br.com.crescer.aula7.entity.Filme[ idFilme=" + idFilme + " ]";
    }
    
}
