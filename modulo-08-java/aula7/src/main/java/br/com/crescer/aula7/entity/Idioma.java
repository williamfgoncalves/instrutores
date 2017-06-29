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
@Table(name = "IDIOMA")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Idioma.findAll", query = "SELECT i FROM Idioma i")
    , @NamedQuery(name = "Idioma.findByIdIdioma", query = "SELECT i FROM Idioma i WHERE i.idIdioma = :idIdioma")
    , @NamedQuery(name = "Idioma.findByNmIdioma", query = "SELECT i FROM Idioma i WHERE i.nmIdioma = :nmIdioma")})
public class Idioma implements Serializable {

    private static final long serialVersionUID = 1L;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "ID_IDIOMA")
    private BigDecimal idIdioma;
    @Size(max = 255)
    @Column(name = "NM_IDIOMA")
    private String nmIdioma;
    @OneToMany(mappedBy = "idiomaIdIdioma")
    private Set<Filme> filmeSet;

    public Idioma() {
    }

    public Idioma(BigDecimal idIdioma) {
        this.idIdioma = idIdioma;
    }

    public BigDecimal getIdIdioma() {
        return idIdioma;
    }

    public void setIdIdioma(BigDecimal idIdioma) {
        this.idIdioma = idIdioma;
    }

    public String getNmIdioma() {
        return nmIdioma;
    }

    public void setNmIdioma(String nmIdioma) {
        this.nmIdioma = nmIdioma;
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
        hash += (idIdioma != null ? idIdioma.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Idioma)) {
            return false;
        }
        Idioma other = (Idioma) object;
        if ((this.idIdioma == null && other.idIdioma != null) || (this.idIdioma != null && !this.idIdioma.equals(other.idIdioma))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "br.com.crescer.aula7.entity.Idioma[ idIdioma=" + idIdioma + " ]";
    }
    
}
