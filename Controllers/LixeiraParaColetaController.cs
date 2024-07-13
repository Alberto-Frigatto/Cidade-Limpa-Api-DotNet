using AutoMapper;
using CidadeLimpa.Models;
using CidadeLimpa.Services;
using CidadeLimpa.ViewModels.In;
using CidadeLimpa.ViewModels.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CidadeLimpa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LixeiraParaColetaController : ControllerBase
    {
        private readonly ILixeiraParaColetaService _lixeiraParaColetaService;
        private readonly ILixeiraService _lixeiraService;
        private readonly IMapper _mapper;

        public LixeiraParaColetaController(ILixeiraParaColetaService service, IMapper mapper, ILixeiraService lixeiraService)
        {
            _lixeiraParaColetaService = service;
            _mapper = mapper;
            _lixeiraService = lixeiraService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<PaginationLixeiraParaColetaViewModel>> GetAll([FromQuery] int page = 1)
        {
            var lixeirasParaColeta = _lixeiraParaColetaService.ListarLixeirasParaColeta(page);
            var viewModelList = _mapper.Map<IEnumerable<DisplayLixeiraParaColetaViewModel>>(lixeirasParaColeta);
            var paginacaoViewModel = new PaginationLixeiraParaColetaViewModel
            {
                LixeirasParaColeta = viewModelList,
                CurrentPage = page
            };

            return Ok(paginacaoViewModel);
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<DisplayLixeiraParaColetaViewModel> GetById(int id)
        {
            var lixeiraParaColeta = _lixeiraParaColetaService.ObterLixeiraParaColetaPorId(id);

            if (lixeiraParaColeta == null)
                return NotFound();

            var viewModel = _mapper.Map<DisplayLixeiraParaColetaViewModel>(lixeiraParaColeta);

            return Ok(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create([FromBody] CreateLixeiraParaColetaViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var lixeira = _lixeiraService.ObterLixeiraPorId(viewModel.IdLixeira);

            if (lixeira == null)
                return NotFound();

            var lixeiraParaColeta = new LixeiraParaColetaModel()
            {
                Ativo = true,
                DataSolicitacao = DateTime.Now,
                DataLimite = DateTime.Now.AddDays(3),
                IdLixeira = lixeira.Id
            };

            _lixeiraParaColetaService.CriarLixeiraParaColeta(lixeiraParaColeta);

            return CreatedAtAction(nameof(GetAll), new { id = lixeiraParaColeta.Id }, viewModel);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Update(int id, [FromBody] UpdateLixeiraParaColetaViewModel viewModel)
        {
            var lixeiraParaColeta = _lixeiraParaColetaService.ObterLixeiraParaColetaPorId(id);

            if (lixeiraParaColeta == null)
                return NotFound();

            _mapper.Map(viewModel, lixeiraParaColeta);
            _lixeiraParaColetaService.AtualizarLixeiraParaColeta(lixeiraParaColeta);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            _lixeiraParaColetaService.ExcluirLixeiraParaColeta(id);

            return NoContent();
        }
    }
}
