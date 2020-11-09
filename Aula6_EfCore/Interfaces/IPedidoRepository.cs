using Aula6_EfCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula6_EfCore.Interfaces
{
    public interface IPedidoRepository
    {
        List<Pedido> Listar();
        Pedido BuscarPorId();
        Pedido Adicionar(List<PedidoItem> pedidoItens);

    }
}
