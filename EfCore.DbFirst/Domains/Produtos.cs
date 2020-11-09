using System;
using System.Collections.Generic;

namespace EfCore.DbFirst.Domains
{
    public partial class Produtos
    {
        public Produtos()
        {
            PedidosItem = new HashSet<PedidosItem>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        public virtual ICollection<PedidosItem> PedidosItem { get; set; }
    }
}
