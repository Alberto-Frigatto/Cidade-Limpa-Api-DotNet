using AutoMapper;
using CidadeLimpa.Services;
using CidadeLimpa.ViewModels.In;
using CidadeLimpa.ViewModels.Output;
using Microsoft.AspNetCore.Mvc;
using CidadeLimpa.Models;
using Microsoft.AspNetCore.Authorization;

namespace CidadeLimpa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LixeiraController : ControllerBase
    {
        private readonly ILixeiraService _service;
        private readonly IMapper _mapper;

        public LixeiraController(ILixeiraService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<PaginationLixeiraViewModel>> GetAll([FromQuery] int page = 1)
        {
            var lixeiras = _service.ListarLixeiras(page);
            var viewModelList = _mapper.Map<IEnumerable<DisplayLixeiraViewModel>>(lixeiras);
            var paginacaoViewModel = new PaginationLixeiraViewModel
            {
                Lixeiras = viewModelList,
                CurrentPage = page
            };

            return Ok(paginacaoViewModel);
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<DisplayLixeiraViewModel> GetById(int id)
        {
            var lixeira = _service.ObterLixeiraPorId(id);

            if (lixeira == null)
                return NotFound();

            var viewModel = _mapper.Map<DisplayLixeiraViewModel>(lixeira);

            return Ok(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create([FromBody] CreateLixeiraViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var lixeira = _mapper.Map<LixeiraModel>(viewModel);
            _service.CriarLixeira(lixeira);

            return CreatedAtAction(nameof(GetAll), new { id = lixeira.Id }, viewModel);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Update(int id, [FromBody] UpdateLixeiraViewModel viewModel)
        {
            var lixeira = _service.ObterLixeiraPorId(id);

            if (lixeira == null)
                return NotFound();

            _mapper.Map(viewModel, lixeira);
            _service.AtualizarLixeira(lixeira);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            _service.ExcluirLixeira(id);

            return NoContent();
        }
    }
}
