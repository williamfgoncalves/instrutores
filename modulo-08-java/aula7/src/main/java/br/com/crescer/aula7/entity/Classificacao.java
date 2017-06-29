/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.com.crescer.aula7.entity;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Set;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author carloshenrique
 */
@Entity
@Table(name = "CLASSIFICACAO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Classificacao.findAll", query = "SELECT c FROM Classificacao c")
    , @NamedQuery(name = "Classificacao.findByIdClassificacao", query = "SELECT c FROM Classificacao c WHERE c.idClassificacao = :idClassificacao")
    , @NamedQuery(name = "Classificacao.findByDsClassificacao", query = "SELECT c FROM Classificacao c WHERE c.dsClassificacao = :dsClassificacao")
    , @NamedQuery(name = "Classificacao.findByNrIdade", query = "SELECT c FROM Classificacao c WHERE c.nrIdade = :nrIdade")})
public class Classificacao implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "ID_CLASSIFICACAO")
    private BigDecimal idClassificacao;
    @Size(max = 255)
    @Column(name = "DS_CLASSIFICACAO")
    private String dsClassificacao;
    @Column(name = "NR_IDADE")
    private Long nrIdade;
    @OneToMany(mappedBy = "classificacaoIdClassificacao")
    private Set<Filme> filmeSet;

    public Classificacao() {
    }

    public Classificacao(BigDecimal idClassificacao) {
        this.idClassificacao = idClassificacao;
    }

    public BigDecimal getIdClassificacao() {
        return idClassificacao;
    }

    public void setIdClassificacao(BigDecimal idClassificacao) {
        this.idClassificacao = idClassificacao;
    }

    public String getDsClassificacao() {
        return dsClassificacao;
    }

    public void setDsClassificacao(String dsClassificacao) {
        this.dsClassificacao = dsClassificacao;
    }

    public Long getNrIdade() {
        return nrIdade;
    }

    public void setNrIdade(Long nrIdade) {
        this.nrIdade = nrIdade;
    }

    @XmlTransient
    public Set<Filme> getFilmeSet() {
        return filmeSet;
    }

    public void setFilmeSet(Set<Filme> filmeSet) {
        this.filmeSet = filmeSet;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idClassificacao != null ? idClassificacao.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Classificacao)) {
            return false;
        }
        Classificacao other = (Classificacao) object;
        if ((this.idClassificacao == null && other.idClassificacao != null) || (this.idClassificacao != null && !this.idClassificacao.equals(other.idClassificacao))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "br.com.crescer.aula7.entity.Classificacao[ idClassificacao=" + idClassificacao + " ]";
    }
    
}
