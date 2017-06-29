/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.com.crescer.aula7.entity;

import java.io.Serializable;
import java.math.BigInteger;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Embeddable;
import javax.validation.constraints.NotNull;

/**
 *
 * @author carloshenrique
 */
@Embeddable
public class ElencoAtorPK implements Serializable {

    @Basic(optional = false)
    @NotNull
    @Column(name = "ELENCO_ID_ELENCO")
    private BigInteger elencoIdElenco;
    @Basic(optional = false)
    @NotNull
    @Column(name = "ATORES_ID_ATOR")
    private BigInteger atoresIdAtor;

    public ElencoAtorPK() {
    }

    public ElencoAtorPK(BigInteger elencoIdElenco, BigInteger atoresIdAtor) {
        this.elencoIdElenco = elencoIdElenco;
        this.atoresIdAtor = atoresIdAtor;
    }

    public BigInteger getElencoIdElenco() {
        return elencoIdElenco;
    }

    public void setElencoIdElenco(BigInteger elencoIdElenco) {
        this.elencoIdElenco = elencoIdElenco;
    }

    public BigInteger getAtoresIdAtor() {
        return atoresIdAtor;
    }

    public void setAtoresIdAtor(BigInteger atoresIdAtor) {
        this.atoresIdAtor = atoresIdAtor;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (elencoIdElenco != null ? elencoIdElenco.hashCode() : 0);
        hash += (atoresIdAtor != null ? atoresIdAtor.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof ElencoAtorPK)) {
            return false;
        }
        ElencoAtorPK other = (ElencoAtorPK) object;
        if ((this.elencoIdElenco == null && other.elencoIdElenco != null) || (this.elencoIdElenco != null && !this.elencoIdElenco.equals(other.elencoIdElenco))) {
            return false;
        }
        if ((this.atoresIdAtor == null && other.atoresIdAtor != null) || (this.atoresIdAtor != null && !this.atoresIdAtor.equals(other.atoresIdAtor))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "br.com.crescer.aula7.entity.ElencoAtorPK[ elencoIdElenco=" + elencoIdElenco + ", atoresIdAtor=" + atoresIdAtor + " ]";
    }
    
}
