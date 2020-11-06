using Aula6_EfCore.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula6_EfCore.Context
{
    public class PedidoContext : DbContext
    {
        //Lista um conjunto de pedidos
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidosItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-D5U2PUB\SQLEXPRESS;Initial Catalog=Db_Senai_Pedidos;Persist Security Info=True;User ID=sa;Password=sa132");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
