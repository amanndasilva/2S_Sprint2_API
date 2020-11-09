using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aula6_EfCore.Domains
{
    /// <summary>
    /// Define a classe Produto
    /// </summary>
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }
        public float Preco { get; set; }

        //Relacionamento com a tabela PedidoItem 1 -- N
        public List<PedidoItem> PedidosItens { get; set; }
    }
}
