using System;

namespace CRUD
{
    public class Pessoas : Base
    {
        // Atributos:
        private Genero Genero {get; set;}
        private string Nome {get; set;}
        private int Ano {get; set;}
        private bool Excluido {get; set;}

        // Métodos:
        public Pessoas(int id, Genero genero, string nome, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Nome = nome;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Deletado: " + this.Excluido;
            return retorno;
        }

        public string retornarNome()
        {
            return this.Nome;
        }

        public int retornaID()
        {
            return this.Id;
        }

        public bool retornaExcluido(){
            return this.Excluido;
        }

        public void Exclui(){
            this.Excluido = true;
        }
    }
}