using PruebaTecnicaOriontec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaOriontec.Repositories
{
    public interface IEmpresaRepository
    {
        ValueTask<Empresa> GetById(int id);
        Task AddEmpresa(Empresa entity);
        Task UpdateEmpresa(Empresa entity, int id);
        Task RemoveEmpresa(int id);
        Task<IEnumerable<Empresa>> GetAllEmpresas();
    }
}
