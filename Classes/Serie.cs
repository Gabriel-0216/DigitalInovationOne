using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series
{
    public class Serie:EntidadeBase
    {
        private Genero genero;
        private string Titulo;
        private string Descricao;
        private int Ano;
        private bool Excluido;
        public Serie(int Id, Genero genero, string Titulo, string Descricao, int Ano)
        {
            this.Id = Id;
            this.genero = genero;
            this.Titulo = Titulo;
            this.Descricao = Descricao;
            this.Ano = Ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            return "\nGênero da série.......: " + this.genero +
                   "\nTítulo da série.......: " + this.Titulo +
                   "\nDescrição da série....: " + this.Descricao +
                   "\nAno de início da série: " + this.Ano;


            }

        public int retornaId()
        {
            return this.Id;
        }
        public String retornaTitulo()
        {
            return this.Titulo;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        }
    }


