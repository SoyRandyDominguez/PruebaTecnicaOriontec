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
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaRepository _EmpresaRepository;

        public EmpresaController(IEmpresaRepository EmpresaRepository)
        {
            _EmpresaRepository = EmpresaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Empresa>> GellAll()
        {
            var Empresas = await _EmpresaRepository.GetAllEmpresas();
            return Ok(Empresas);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Empresa>> GetById(int id)
        {
            var Empresa = await _EmpresaRepository.GetById(id);
            return Ok(Empresa);
        }
        [HttpPost]
        public async Task<ActionResult> AddEmpresa(Empresa entity)
        {
            await _EmpresaRepository.AddEmpresa(entity);
            return Ok(entity);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Empresa>> Update(Empresa entity, int id)
        {
            await _EmpresaRepository.UpdateEmpresa(entity, id);
            return Ok(entity);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _EmpresaRepository.RemoveEmpresa(id);
            return Ok();
        }
    }
}
