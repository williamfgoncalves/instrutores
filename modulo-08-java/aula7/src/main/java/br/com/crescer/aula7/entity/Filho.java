/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.com.crescer.aula7.entity;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author carloshenrique
 */
@Entity
@Table(name = "FILHO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Filho.findAll", query = "SELECT f FROM Filho f")
    , @NamedQuery(name = "Filho.findByIdFilho", query = "SELECT f FROM Filho f WHERE f.idFilho = :idFilho")
    , @NamedQuery(name = "Filho.findByNmFilho", query = "SELECT f FROM Filho f WHERE f.nmFilho = :nmFilho")})
public class Filho implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "ID_FILHO")
    private Integer idFilho;
    @Size(max = 60)
    @Column(name = "NM_FILHO")
    private String nmFilho;
    @JoinColumn(name = "ID_PESSOA", referencedColumnName = "ID")
    @ManyToOne
    private Pessoa idPessoa;

    public Filho() {
    }

    public Filho(Integer idFilho) {
        this.idFilho = idFilho;
    }

    public Integer getIdFilho() {
        return idFilho;
    }

    public void setIdFilho(Integer idFilho) {
        this.idFilho = idFilho;
    }

    public String getNmFilho() {
        return nmFilho;
    }

    public void setNmFilho(String nmFilho) {
        this.nmFilho = nmFilho;
    }

    public Pessoa getIdPessoa() {
        return idPessoa;
    }

    public void setIdPessoa(Pessoa idPessoa) {
        this.idPessoa = idPessoa;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (idFilho != null ? idFilho.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Filho)) {
            return false;
        }
        Filho other = (Filho) object;
        if ((this.idFilho == null && other.idFilho != null) || (this.idFilho != null && !this.idFilho.equals(other.idFilho))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "br.com.crescer.aula7.entity.Filho[ idFilho=" + idFilho + " ]";
    }
    
}
