using System;
using System.Collections.Generic;

namespace EfCore.DbFirst.Domains
{
    public partial class Pedidos
    {
        public Pedidos()
        {
            PedidosItem = new HashSet<PedidosItem>();
        }

        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual ICollection<PedidosItem> PedidosItem { get; set; }
    }
}
