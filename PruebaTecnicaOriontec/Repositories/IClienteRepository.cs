using PruebaTecnicaOriontec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaOriontec.Repositories
{
    public interface IClienteRepository
    {
        ValueTask<Cliente> GetById(int id);
        Task AddCliente(Cliente entity);
        Task UpdateCliente(Cliente entity, int id);
        Task RemoveCliente(int id);
        Task<IEnumerable<Cliente>> GetAllClientes();
    }
}
