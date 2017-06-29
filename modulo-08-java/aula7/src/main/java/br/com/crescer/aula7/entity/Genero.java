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
@Table(name = "GENERO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Genero.findAll", query = "SELECT g FROM Genero g")
    , @NamedQuery(name = "Genero.findByIdGenero", query = "SELECT g FROM Genero g WHERE g.idGenero = :idGenero")
    , @NamedQuery(name = "Genero.findByDsGenero", query = "SELECT g FROM Genero g WHERE g.dsGenero = :dsGenero")})
public class Genero implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "ID_GENERO")
    private BigDecimal idGenero;
    @Size(max = 255)
    @Column(name = "DS_GENERO")
    private String dsGenero;
    @OneToMany(mappedBy = "generoIdGenero")
    private Set<Filme> filmeSet;

    public Genero() {
    }

    public Genero(BigDecimal idGenero) {
        this.idGenero = idGenero;
    }

    public BigDecimal getIdGenero() {
        return idGenero;
    }

    public void setIdGenero(BigDecimal idGenero) {
        this.idGenero = idGenero;
    }

    public String getDsGenero() {
        return dsGenero;
    }

    public void setDsGenero(String dsGenero) {
        this.dsGenero = dsGenero;
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
        hash += (idGenero != null ? idGenero.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Genero)) {
            return false;
        }
        Genero other = (Genero) object;
        if ((this.idGenero == null && other.idGenero != null) || (this.idGenero != null && !this.idGenero.equals(other.idGenero))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "br.com.crescer.aula7.entity.Genero[ idGenero=" + idGenero + " ]";
    }
    
}
