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
    public class DireccionClienteRepository : BaseRepository, IDireccionClienteRepository
    {
        private readonly IDireccionClienteCommandText _commandText;

        public DireccionClienteRepository(IConfiguration configuration, IDireccionClienteCommandText commandText) : base(configuration)
        {
            _commandText = commandText;

        }
        public async Task<IEnumerable<DireccionCliente>> GetAllDireccionClientes()
        {

            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<DireccionCliente>(_commandText.GetDireccionClientes);
                return query;
            });

        }

        public async Task<IEnumerable<DireccionCliente>> GetById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<DireccionCliente>(_commandText.GetDireccionClienteById, new { Id = id });
                return query;
            });

        }

        public async Task AddDireccionCliente(DireccionCliente entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.AddDireccionCliente,
                    new { Direccion = entity.Direccion });
            });

        }
        public async Task UpdateDireccionCliente(DireccionCliente entity, int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.UpdateDireccionCliente,
                    new { Direccion = entity.Direccion, Id = id });
            });

        }

        public async Task RemoveDireccionCliente(int id)
        {

            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.RemoveDireccionCliente, new { Id = id });
            });

        }


    }
}
