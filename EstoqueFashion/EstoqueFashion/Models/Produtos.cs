using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueFashion.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int Descricao { get; set; }
        public string Categoria { get; set; }
        public int Quantidade { get; set; }
        public double Custo { get; set; }
        public string Imagem { get; set; }

    }
}
