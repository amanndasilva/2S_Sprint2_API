using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Pets.Domains;
using API_Pets.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        //Abre o repositório
        ClinicasRepository repo = new ClinicasRepository();

        // GET: api/<PetsController>
        [HttpGet]
        public List<Clinicas> Get()
        {
            return repo.ListarTodos();
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public Clinicas Get(int id)
        {
            return repo.BuscarPorID(id);
        }

        // POST api/<PetsController>
        [HttpPost]
        public Clinicas Post([FromBody] Clinicas c)
        {
            return repo.Cadastrar(c);
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public Clinicas Put(int id, [FromBody] Clinicas c)
        {
            return repo.Alterar(id, c);
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Remover(id);
        }
    }
}
