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
    public class DireccionClienteController : ControllerBase
    {
        private readonly IDireccionClienteRepository _DireccionClienteRepository;

        public DireccionClienteController(IDireccionClienteRepository DireccionClienteRepository)
        {
            _DireccionClienteRepository = DireccionClienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<DireccionCliente>> GellAll()
        {
            var DireccionClientes = await _DireccionClienteRepository.GetAllDireccionClientes();
            return Ok(DireccionClientes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DireccionCliente>> GetById(int id)
        {
            var DireccionCliente = await _DireccionClienteRepository.GetById(id);
            return Ok(DireccionCliente);
        }
        [HttpPost]
        public async Task<ActionResult> AddDireccionCliente(DireccionCliente entity)
        {
            await _DireccionClienteRepository.AddDireccionCliente(entity);
            return Ok(entity);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<DireccionCliente>> Update(DireccionCliente entity, int id)
        {
            await _DireccionClienteRepository.UpdateDireccionCliente(entity, id);
            return Ok(entity);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _DireccionClienteRepository.RemoveDireccionCliente(id);
            return Ok();
        }
    }
}
