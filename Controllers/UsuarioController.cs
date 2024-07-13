using AutoMapper;
using CidadeLimpa.Models;
using CidadeLimpa.Services;
using CidadeLimpa.ViewModels.In;
using Microsoft.AspNetCore.Mvc;

namespace CidadeLimpa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Create([FromBody] InUsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = _service.ObterUsuarioPorEmail(viewModel.Email);
            if (usuario != null)
                return Conflict("O usuário já existe");

            var newUsuario = _mapper.Map<UsuarioModel>(viewModel);
            _service.CriarUsuario(newUsuario);

            return NoContent();
        }
    }
}
