using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository _projetoRepository;

        public ProjetosController(ProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        // GET -> /api/projetos
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_projetoRepository.Listar());
        }

        // GET -> /api/projetos/{id}
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Projeto projeto = _projetoRepository.BuscarPorId(id);

            if (projeto == null)
            {
                return NotFound();
            }

            return Ok(projeto);
        }

        // POST -> /api/projetos
        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto)
        {
            _projetoRepository.Cadastrar(projeto);
            return StatusCode(201);
        }

        // PUT -> /api/projetos/{id}
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Projeto projeto)
        {
            if (_projetoRepository.BuscarPorId(id) == null)
            {
                return NotFound();
            }

            _projetoRepository.Atualizar(id, projeto);
            return NoContent();
        }

        // DELETE -> /api/projetos/{id}
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if (_projetoRepository.BuscarPorId(id) == null)
            {
                return NotFound();
            }

            _projetoRepository.Deletar(id);
            return NoContent();
        }
    }
}
