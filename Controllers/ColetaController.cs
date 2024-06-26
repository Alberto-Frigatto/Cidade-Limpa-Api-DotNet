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
    public class ColetaController : ControllerBase
    {
        private readonly IColetaService _serviceColeta;
        private readonly ICaminhaoService _serviceCaminhao;
        private readonly ILixeiraService _serviceLixeira;
        private readonly IMapper _mapper;

        public ColetaController(IColetaService serviceColeta, ICaminhaoService serviceCaminhao, ILixeiraService serviceLixeira, IMapper mapper)
        {
            _serviceColeta = serviceColeta;
            _serviceCaminhao = serviceCaminhao;
            _serviceLixeira = serviceLixeira;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<PaginationColetaViewModel>> GetAll([FromQuery] int page = 1)
        {
            var coletas = _serviceColeta.ListarColetas(page);
            var viewModelList = _mapper.Map<IEnumerable<DisplayColetaViewModel>>(coletas);
            var paginacaoViewModel = new PaginationColetaViewModel
            {
                Coletas = viewModelList,
                CurrentPage = page
            };

            return Ok(paginacaoViewModel);
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<DisplayColetaViewModel> GetById(int id)
        {
            var coleta = _serviceColeta.ObterColetaPorId(id);

            if (coleta == null)
                return NotFound();

            var viewModel = _mapper.Map<DisplayColetaViewModel>(coleta);

            return Ok(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create([FromBody] InColetaViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var caminhao = _serviceCaminhao.ObterCaminhaoPorId(viewModel.IdCaminhao);

            if (caminhao == null)
                return NotFound();

            var lixeira = _serviceLixeira.ObterLixeiraPorId(viewModel.IdLixeira);

            if (lixeira == null)
                return NotFound();

            var coleta = new ColetaModel()
            {
                IdCaminhao = caminhao.Id,
                IdLixeira = lixeira.Id,
                DataColeta = DateTime.Now.ToString("dd/MM/yyyy")
            };

            _serviceColeta.CriarColeta(coleta);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            _serviceColeta.ExcluirColeta(id);

            return NoContent();
        }
    }
}
