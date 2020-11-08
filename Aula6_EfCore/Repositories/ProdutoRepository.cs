using Aula6_EfCore.Context;
using Aula6_EfCore.Domains;
using Aula6_EfCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula6_EfCore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _ctx;

        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }

        /// <summary>
        /// Lista todos os produtos cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de prodtos</returns>
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Busca um produto pelo Id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>Lista de produto</returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                //Quando não se tratar de chave primária -> return _ctx.Produtos.FirstOrDefault(c => c.Id == id);
                return _ctx.Produtos.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um produto pelo nome
        /// </summary>
        /// <param name="nome">Nome do produto</param>
        /// <returns>Retorna um produto</returns>
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um novo produto 
        /// </summary>
        /// <param name="p">Objeto do tipo produto</param>
        public void Adicionar(Produto p)
        {
            try
            {
                //Outras formas -> _ctx.Set<Produto>().Add(p);serve para *add, remove, update*
                //Ou esse -> _ctx.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                //Adiciona um objeto do tipo produto ao DbSet do context
                _ctx.Produtos.Add(p);
                //Salva alterações no context
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita um produto
        /// </summary>
        /// <param name="p">Produto que será editado</param>
        public void Editar(Produto p)
        {
            try
            {
                //Busca o produto pelo id
                Produto produtoTemp = BuscarPorId(p.Id);

                //Verifica se o pedido existe e se não existr, exibe a mensagem
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Caso exista, altera as propriedades do produto
                produtoTemp.Nome    = p.Nome;
                produtoTemp.Preco   = p.Preco;

                //Altera o produto no ctx e abaixo, salva o ctx
                _ctx.Produtos.Update(produtoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                //Busca o produto pelo id
                Produto produtoTemp = BuscarPorId(id);

                //Verifica se o pedido existe e se não existr, exibe a mensagem
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Remove um produto do DbSet
                _ctx.Produtos.Remove(produtoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
