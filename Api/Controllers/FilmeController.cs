
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Api.Filters;
using Domain.Entity;
using System;

namespace Api.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("[controller]")]
    [ServiceFilter(typeof(AuthActionFilter))]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet("{id}")]
        public ActionResult<Filme> PegarCadastro(int id) 
            => Ok(_filmeService.PegarPorId(id));

        [HttpGet]
        public ActionResult<Filme> PegarTodos() 
            => Ok(_filmeService.PegarTodos());

        [HttpPost]
        public ActionResult<Filme> Adicionar([FromBody] Filme filme) 
        {
            try
            {
                Filme response = _filmeService.Adicionar(filme);                
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult<int> Atualizar([FromBody] Filme filme) 
        {
            try
            {
                int response = _filmeService.Atualizar(filme);                
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> Remover(int id) 
        {
            try
            {
                bool response = _filmeService.Remover(id);                
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
