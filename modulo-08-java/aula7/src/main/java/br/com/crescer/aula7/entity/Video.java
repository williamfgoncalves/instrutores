/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.com.crescer.aula7.entity;

import java.io.Serializable;
import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.Date;
import java.util.Set;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author carloshenrique
 */
@Entity
@Table(name = "VIDEO")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Video.findAll", query = "SELECT v FROM Video v")
    , @NamedQuery(name = "Video.findById", query = "SELECT v FROM Video v WHERE v.id = :id")
    , @NamedQuery(name = "Video.findByValor", query = "SELECT v FROM Video v WHERE v.valor = :valor")
    , @NamedQuery(name = "Video.findByDuracao", query = "SELECT v FROM Video v WHERE v.duracao = :duracao")
    , @NamedQuery(name = "Video.findByIdGenero", query = "SELECT v FROM Video v WHERE v.idGenero = :idGenero")
    , @NamedQuery(name = "Video.findByNome", query = "SELECT v FROM Video v WHERE v.nome = :nome")
    , @NamedQuery(name = "Video.findByQuantidadeEstoque", query = "SELECT v FROM Video v WHERE v.quantidadeEstoque = :quantidadeEstoque")
    , @NamedQuery(name = "Video.findByDataLancamento", query = "SELECT v FROM Video v WHERE v.dataLancamento = :dataLancamento")})
public class Video implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @NotNull
    @Column(name = "ID")
    private Long id;
    // @Max(value=?)  @Min(value=?)//if you know range of your decimal fields consider using these annotations to enforce field validation
    @Basic(optional = false)
    @NotNull
    @Column(name = "VALOR")
    private BigDecimal valor;
    @Size(max = 50)
    @Column(name = "DURACAO")
    private String duracao;
    @Column(name = "ID_GENERO")
    private Long idGenero;
    @Size(max = 50)
    @Column(name = "NOME")
    private String nome;
    @Column(name = "QUANTIDADE_ESTOQUE")
    private BigInteger quantidadeEstoque;
    @Column(name = "DATA_LANCAMENTO")
    @Temporal(TemporalType.TIMESTAMP)
    private Date dataLancamento;
    @OneToMany(mappedBy = "idVideo")
    private Set<Locacao> locacaoSet;

    public Video() {
    }

    public Video(Long id) {
        this.id = id;
    }

    public Video(Long id, BigDecimal valor) {
        this.id = id;
        this.valor = valor;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public BigDecimal getValor() {
        return valor;
    }

    public void setValor(BigDecimal valor) {
        this.valor = valor;
    }

    public String getDuracao() {
        return duracao;
    }

    public void setDuracao(String duracao) {
        this.duracao = duracao;
    }

    public Long getIdGenero() {
        return idGenero;
    }

    public void setIdGenero(Long idGenero) {
        this.idGenero = idGenero;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public BigInteger getQuantidadeEstoque() {
        return quantidadeEstoque;
    }

    public void setQuantidadeEstoque(BigInteger quantidadeEstoque) {
        this.quantidadeEstoque = quantidadeEstoque;
    }

    public Date getDataLancamento() {
        return dataLancamento;
    }

    public void setDataLancamento(Date dataLancamento) {
        this.dataLancamento = dataLancamento;
    }

    @XmlTransient
    public Set<Locacao> getLocacaoSet() {
        return locacaoSet;
    }

    public void setLocacaoSet(Set<Locacao> locacaoSet) {
        this.locacaoSet = locacaoSet;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (id != null ? id.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Video)) {
            return false;
        }
        Video other = (Video) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "br.com.crescer.aula7.entity.Video[ id=" + id + " ]";
    }
    
}
