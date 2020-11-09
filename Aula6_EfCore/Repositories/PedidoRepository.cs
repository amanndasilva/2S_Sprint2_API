using Aula6_EfCore.Context;
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
        private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }

        public Pedido Adicionar(List<PedidoItem> pedidosItens)
        {
            try
            {
                //Criação do obj do tipo Pedido, passando os valores
                Pedido pedido = new Pedido
                {
                    Status      = "Pedido efetuado",
                    OrderDate   = DateTime.Now
                };

                //Percorre a lista de pedidos itens e adiciona a lista de pedidosItens
                foreach (var item in pedidosItens)
                {
                    //Adiciona um pedidoitem a lista
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido    = pedido.Id, //Id do obj criado acima
                        IdProduto   = item.IdProduto, //Item da lista recebida como parâmetro
                        Quantidade  = item.Quantidade //Item da lista recebida como parâmetro
                    });
                }

                //Adiciona o pedido ao contexto
                _ctx.Pedidos.Add(pedido);
                //Salva as alterações do contexto no Banco
                _ctx.SaveChanges();

                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
