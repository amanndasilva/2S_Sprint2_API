using EfCore.DbFirst.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.DbFirst.Repositories
{
    public class ProdutoRepository
    {
        private readonly PedidoContext _ctx;

        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
            //_ctx.Pedidos.First;
        }
    }
}
