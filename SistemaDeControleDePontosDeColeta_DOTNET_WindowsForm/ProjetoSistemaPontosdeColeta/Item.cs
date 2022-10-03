using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSistemaPontosdeColeta
{
    internal class Item
    {
        private int id;
        private string nome;

        public Item(int id, string nome)
        {
            this.nome = nome;
            this.id = id;
        }

        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }
}
