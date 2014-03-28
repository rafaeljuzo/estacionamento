using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estacionamento
{
    public class Modelo
    {

        private int codModelo;
        private Marca marca;
        private String descricao;

        public void setCodModelo(int codModelo)
        {
            this.codModelo = codModelo;
        }

        public int getCodModelo()
        {
            return codModelo;
        }

        public void setMarca(Marca marca)
        {
            this.marca = marca;
        }

        public Marca getMarca()
        {
            return marca;
        }

        public void setDescricao(String descricao)
        {
            this.descricao = descricao;
        }

        public String getDescricao()
        {
            return descricao;
        }
    }
}