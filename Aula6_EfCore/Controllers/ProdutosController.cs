﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula6_EfCore.Domains;
using Aula6_EfCore.Interfaces;
using Aula6_EfCore.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aula6_EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repositório
                var produto = _produtoRepository.Listar();

                //Verifica se eles existem, caso existam, retorna NoContent (Sem Conteúdo)
                if (produto.Count == 0)
                    return NoContent();

                //Caso exista, retorna um Ok e os produtos
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro, retorna um BadRequest e a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //Busca o produto pelo Id
                var produto = _produtoRepository.BuscarPorId(id);

                //Verifica se ele existe, caso não axista, retorna NotFound (Não Encontrado)
                if (produto == null)
                    return NotFound();

                //Caso exista, retorna um Ok com os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro, retorna um BadRequest e a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            try
            {
                //Adiciona um produto
                _produtoRepository.Adicionar(produto);

                //Retorna com os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro, retorna um BadRequest e a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                _produtoRepository.Editar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro, retorna um BadRequest e a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _produtoRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro, retorna um BadRequest e a mensagem de erro
                return BadRequest(ex.Message);
            }
        }
    }
}
