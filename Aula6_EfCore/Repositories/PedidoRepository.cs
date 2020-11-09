using Aula6_EfCore.Domains;
using Aula6_EfCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula6_EfCore.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoRepository()
        {
            _pedidoRepository = new PedidoRepository();
        }

        public Pedido Adicionar(List<PedidoItem> pedidoItens)
        {
            try
            {
                Pedido pedido = new Pedido
                {
                    Id = Guid.NewGuid()
                }
            }
            catch (Exception ex)
            {

            }
        }

        public Pedido BuscarPorId()
        {
            throw new NotImplementedException();
        }

        public List<Pedido> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
