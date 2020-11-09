using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aula6_EfCore.Domains
{
    public class Pedido : BaseDomain
    {
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        //Relacionamento com a tabela PedidoItem 1 -- N
        public List<PedidoItem> PedidosItens { get; set; }
    }
}
