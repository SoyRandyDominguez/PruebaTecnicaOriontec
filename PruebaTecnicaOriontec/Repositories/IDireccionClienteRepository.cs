using PruebaTecnicaOriontec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaOriontec.Repositories
{
    public interface IDireccionClienteRepository
    {
        ValueTask<DireccionCliente> GetById(int id);
        Task AddDireccionCliente(DireccionCliente entity);
        Task UpdateDireccionCliente(DireccionCliente entity, int id);
        Task RemoveDireccionCliente(int id);
        Task<IEnumerable<DireccionCliente>> GetAllDireccionClientes();
    }
}
