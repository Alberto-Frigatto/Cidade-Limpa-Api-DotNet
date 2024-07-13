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
    public class CaminhaoController : ControllerBase
    {
        private readonly ICaminhaoService _serviceCaminhao;
        private readonly IRotaService _serviceRota;
        private readonly IMapper _mapper;

        public CaminhaoController(ICaminhaoService serviceCaminhao, IRotaService serviceRota, IMapper mapper)
        {
            _serviceCaminhao = serviceCaminhao;
            _serviceRota = serviceRota;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<PaginationCaminhaoViewModel>> GetAll([FromQuery] int page = 1)
        {
            var caminhoes = _serviceCaminhao.ListarCaminhoes(page);
            var viewModelList = _mapper.Map<IEnumerable<DisplayCaminhaoViewModel>>(caminhoes);
            var paginacaoViewModel = new PaginationCaminhaoViewModel
            {
                Caminhoes = viewModelList,
                CurrentPage = page
            };

            return Ok(paginacaoViewModel);
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<DisplayCaminhaoViewModel> GetById(int id)
        {
            var caminhao = _serviceCaminhao.ObterCaminhaoPorId(id);

            if (caminhao == null)
                return NotFound();

            var viewModel = _mapper.Map<DisplayCaminhaoViewModel>(caminhao);

            return Ok(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create([FromBody] InCaminhaoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rota = _serviceRota.ObterRotaPorId(viewModel.IdRota);

            if (rota == null)
                return NotFound();

            var caminhao = _mapper.Map<CaminhaoModel>(viewModel);

            _serviceCaminhao.CriarCaminhao(caminhao);

            return CreatedAtAction(nameof(GetAll), new { id = caminhao.Id }, viewModel);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Update(int id, [FromBody] InCaminhaoViewModel viewModel)
        {
            var caminhao = _serviceCaminhao.ObterCaminhaoPorId(id);
            
            if (caminhao == null)
                return NotFound();

            var rota = _serviceRota.ObterRotaPorId(viewModel.IdRota);

            if (rota == null)
                return NotFound();

            _mapper.Map(viewModel, caminhao);
            _serviceCaminhao.AtualizarCaminhao(caminhao);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            _serviceCaminhao.ExcluirCaminhao(id);

            return NoContent();
        }

    }
}
