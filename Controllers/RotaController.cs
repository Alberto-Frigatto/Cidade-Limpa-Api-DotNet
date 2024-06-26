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
    public class RotaController : ControllerBase
    {
        private readonly IRotaService _serviceRota;
        private readonly IPontoColetaService _servicePontoColeta;
        private readonly IMapper _mapper;

        public RotaController(IRotaService serviceRota, IPontoColetaService servicePontoColeta, IMapper mapper)
        {
            _serviceRota = serviceRota;
            _servicePontoColeta = servicePontoColeta;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<PaginationRotaViewModel>> GetAll([FromQuery] int page = 1)
        {
            var rotas = _serviceRota.ListarRotas(page);
            var viewModelList = _mapper.Map<IEnumerable<DisplayRotaViewModel>>(rotas);
            var paginacaoViewModel = new PaginationRotaViewModel
            {
                Rotas = viewModelList,
                CurrentPage = page
            };

            return Ok(paginacaoViewModel);
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<DisplayRotaViewModel> GetById(int id)
        {
            var rota = _serviceRota.ObterRotaPorId(id);

            if (rota == null)
                return NotFound();

            var viewModel = _mapper.Map<DisplayRotaViewModel>(rota);

            return Ok(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create([FromBody] InRotaViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rota = new RotaModel() 
            { 
                HorarioInicio = viewModel.HorarioInicio,
                HorarioFim = viewModel.HorarioFim,
            };

            _serviceRota.CriarRota(rota);

            foreach (string ponto in viewModel.ListaPontosColeta)
            {
                var pontoColeta = new PontoColetaModel()
                {
                    Ponto = ponto,
                    IdRota = rota.Id
                };

                _servicePontoColeta.CriarPontoColeta(pontoColeta);
            }

            return CreatedAtAction(nameof(GetAll), new { id = rota.Id }, viewModel);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Update(int id, [FromBody] InRotaViewModel viewModel)
        {
            var rota = _serviceRota.ObterRotaPorId(id);

            if (rota == null)
                return NotFound();

            foreach (PontoColetaModel pontoColeta in rota.ListaPontosColeta)
            {
                _servicePontoColeta.ExcluirPontoColeta(pontoColeta.Id);
            }
            
            rota.HorarioInicio = viewModel.HorarioInicio;
            rota.HorarioFim = viewModel.HorarioFim;

            foreach (string ponto in viewModel.ListaPontosColeta)
            {
                var pontoColeta = new PontoColetaModel()
                {
                    Ponto = ponto,
                    IdRota = rota.Id
                };

                _servicePontoColeta.CriarPontoColeta(pontoColeta);
            }

            _serviceRota.AtualizarRota(rota);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var rota = _serviceRota.ObterRotaPorId(id);
            if (rota != null)
            {
                foreach (PontoColetaModel pontoColeta in rota.ListaPontosColeta)
                {
                    _servicePontoColeta.ExcluirPontoColeta(pontoColeta.Id);
                }
                _serviceRota.ExcluirRota(id);
            }

            return NoContent();
        }
    }
}
