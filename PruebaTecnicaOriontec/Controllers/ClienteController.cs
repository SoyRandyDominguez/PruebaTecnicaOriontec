using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaOriontec.Models;
using PruebaTecnicaOriontec.Repositories;

namespace PruebaTecnicaOriontec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _ClienteRepository;

        public ClienteController(IClienteRepository ClienteRepository)
        {
            _ClienteRepository = ClienteRepository;
        }
            
        [HttpGet]
        public async Task<ActionResult<Cliente>> GellAll()
        {
            var Clientes = await _ClienteRepository.GetAllClientes();
            return Ok(Clientes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var Cliente = await _ClienteRepository.GetById(id);
            return Ok(Cliente);
        }
        [HttpPost]
        public async Task<ActionResult> AddCliente(Cliente entity)
        {
            await _ClienteRepository.AddCliente(entity);
            return Ok(entity);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> Update(Cliente entity, int id)
        {
            await _ClienteRepository.UpdateCliente(entity, id);
            return Ok(entity);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _ClienteRepository.RemoveCliente(id);
            return Ok();
        }
    }
}
