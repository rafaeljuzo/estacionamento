using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estacionamento
{
    public class Marca
    {

        private int codMarca;
        private String descricao;
        private List<Modelo> listaModelo;

        public void setCodMarca(int codMarca)
        {
            this.codMarca = codMarca;
        }

        public int getCodMarca()
        {
            return codMarca;
        }

        public void setDescricao(String descricao)
        {
            this.descricao = descricao;
        }

        public String getDescricao()
        {
            return descricao;
        }

        public void setListaModelo(List<Modelo> listaModelo)
        {
            this.listaModelo = listaModelo;
        }

        public List<Modelo> getListaModelo()
        {
            return listaModelo;
        }

    }
}