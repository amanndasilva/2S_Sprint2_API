using API_Pets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pets.Interfaces
{
    interface IClinicas
    {
        List<Clinicas> ListarTodos();
        Clinicas BuscarPorID(int id);
        Clinicas Cadastrar(Clinicas c);
        Clinicas Alterar(int id, Clinicas c);
        void Remover(int id);
    }
}
