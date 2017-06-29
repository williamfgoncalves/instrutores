/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.com.crescer.aula7.entity;

import java.io.Serializable;
import java.math.BigInteger;
import javax.persistence.EmbeddedId;
import javax.persistence.Entity;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author carloshenrique
 */
@Entity
@Table(name = "ELENCO_ATOR")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "ElencoAtor.findAll", query = "SELECT e FROM ElencoAtor e")
    , @NamedQuery(name = "ElencoAtor.findByElencoIdElenco", query = "SELECT e FROM ElencoAtor e WHERE e.elencoAtorPK.elencoIdElenco = :elencoIdElenco")
    , @NamedQuery(name = "ElencoAtor.findByAtoresIdAtor", query = "SELECT e FROM ElencoAtor e WHERE e.elencoAtorPK.atoresIdAtor = :atoresIdAtor")})
public class ElencoAtor implements Serializable {

    private static final long serialVersionUID = 1L;
    @EmbeddedId
    protected ElencoAtorPK elencoAtorPK;
    @JoinColumn(name = "ELENCO_ID_ELENCO", referencedColumnName = "ID_ELENCO", insertable = false, updatable = false)
    @ManyToOne(optional = false)
    private Elenco elenco;

    public ElencoAtor() {
    }

    public ElencoAtor(ElencoAtorPK elencoAtorPK) {
        this.elencoAtorPK = elencoAtorPK;
    }

    public ElencoAtor(BigInteger elencoIdElenco, BigInteger atoresIdAtor) {
        this.elencoAtorPK = new ElencoAtorPK(elencoIdElenco, atoresIdAtor);
    }

    public ElencoAtorPK getElencoAtorPK() {
        return elencoAtorPK;
    }

    public void setElencoAtorPK(ElencoAtorPK elencoAtorPK) {
        this.elencoAtorPK = elencoAtorPK;
    }

    public Elenco getElenco() {
        return elenco;
    }

    public void setElenco(Elenco elenco) {
        this.elenco = elenco;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (elencoAtorPK != null ? elencoAtorPK.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof ElencoAtor)) {
            return false;
        }
        ElencoAtor other = (ElencoAtor) object;
        if ((this.elencoAtorPK == null && other.elencoAtorPK != null) || (this.elencoAtorPK != null && !this.elencoAtorPK.equals(other.elencoAtorPK))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "br.com.crescer.aula7.entity.ElencoAtor[ elencoAtorPK=" + elencoAtorPK + " ]";
    }
    
}
