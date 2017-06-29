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
import javax.persistence.CascadeType;
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
@Table(name = "ELENCO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Elenco.findAll", query = "SELECT e FROM Elenco e")
    , @NamedQuery(name = "Elenco.findByIdElenco", query = "SELECT e FROM Elenco e WHERE e.idElenco = :idElenco")
    , @NamedQuery(name = "Elenco.findByDsElenco", query = "SELECT e FROM Elenco e WHERE e.dsElenco = :dsElenco")})
public class Elenco implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "ID_ELENCO")
    private BigDecimal idElenco;
    @Size(max = 255)
    @Column(name = "DS_ELENCO")
    private String dsElenco;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "elenco")
    private Set<ElencoAtor> elencoAtorSet;
    @OneToMany(mappedBy = "elencoIdElenco")
    private Set<Filme> filmeSet;

    public Elenco() {
    }

    public Elenco(BigDecimal idElenco) {
        this.idElenco = idElenco;
    }

    public BigDecimal getIdElenco() {
        return idElenco;
    }

    public void setIdElenco(BigDecimal idElenco) {
        this.idElenco = idElenco;
    }

    public String getDsElenco() {
        return dsElenco;
    }

    public void setDsElenco(String dsElenco) {
        this.dsElenco = dsElenco;
    }

    @XmlTransient
    public Set<ElencoAtor> getElencoAtorSet() {
        return elencoAtorSet;
    }

    public void setElencoAtorSet(Set<ElencoAtor> elencoAtorSet) {
        this.elencoAtorSet = elencoAtorSet;
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
        hash += (idElenco != null ? idElenco.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Elenco)) {
            return false;
        }
        Elenco other = (Elenco) object;
        if ((this.idElenco == null && other.idElenco != null) || (this.idElenco != null && !this.idElenco.equals(other.idElenco))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "br.com.crescer.aula7.entity.Elenco[ idElenco=" + idElenco + " ]";
    }
    
}
