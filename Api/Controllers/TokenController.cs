using Domain.Entity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenUsuarioService _tokenUsuarioService;

        public TokenController(ITokenUsuarioService tokenUsuarioService)
        {
            _tokenUsuarioService = tokenUsuarioService;
        }

        [HttpPost]
        public string Gerar([FromBody] Usuario usuario)
            => _tokenUsuarioService.Gerar(usuario);        
    }
}