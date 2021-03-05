using Dapper;
using Microsoft.Extensions.Configuration;
using PruebaTecnicaOriontec.Helpers;
using PruebaTecnicaOriontec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaOriontec.Repositories
{
    public class EmpresaRepository : BaseRepository, IEmpresaRepository
    {
        private readonly IEmpresaCommandText _commandText;

        public EmpresaRepository(IConfiguration configuration, IEmpresaCommandText commandText) : base(configuration)
        {
            _commandText = commandText;

        }
        public async Task<IEnumerable<Empresa>> GetAllEmpresas()
        {

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Empresa>(_commandText.GetEmpresas);
                return query;
            });

        }

        public async ValueTask<Empresa> GetById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Empresa>(_commandText.GetEmpresaById, new { Id = id });
                return query;
            });

        }

        public async Task AddEmpresa(Empresa entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.AddEmpresa,
                    new { RazonSocial = entity.RazonSocial });
            });

        }
        public async Task UpdateEmpresa(Empresa entity, int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.UpdateEmpresa,
                    new { RazonSocial = entity.RazonSocial, Id = id });
            });

        }

        public async Task RemoveEmpresa(int id)
        {

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.RemoveEmpresa, new { Id = id });
            });

        }


    }
}
