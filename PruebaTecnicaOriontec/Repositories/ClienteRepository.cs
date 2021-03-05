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
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        private readonly IClienteCommandText _commandText;

        public ClienteRepository(IConfiguration configuration, IClienteCommandText commandText) : base(configuration)
        {
            _commandText = commandText;

        }
        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Cliente>(_commandText.GetClientes);
                return query;
            });

        }

        public async ValueTask<Cliente> GetById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Cliente>(_commandText.GetClienteById, new { Id = id });
                return query;
            });

        }

        public async Task AddCliente(Cliente entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.AddCliente,
                    new { Nombre = entity.Nombre });
            });

        }
        public async Task UpdateCliente(Cliente entity, int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.UpdateCliente,
                    new { Nombre = entity.Nombre, EmpresaId = entity.EmpresaId, Id = id });
            });

        }

        public async Task RemoveCliente(int id)
        {

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.RemoveCliente, new { Id = id });
            });

        }


    }
}
