using fitnessApi.Models.DTOs;
using fitnessApi.Services.MusculoService;
using Microsoft.AspNetCore.Mvc;

namespace fitnessApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusculosController : ControllerBase
    {
        private readonly IMusculoService _service;

        public MusculosController(IMusculoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os músculos
        /// </summary>
        [HttpGet]
        public ActionResult<List<MusculoDto>> GetAll()
        {
            var musculos = _service.GetAll();
            var dtos = musculos.Select(m => new MusculoDto
            {
                Id = m.Id,
                Nome = m.NomeMusculo ?? string.Empty,
                MovimentoPrincipal = m.MovimentoPrincipal ?? string.Empty,
                Funcao = m.Funcao ?? string.Empty
            }).ToList();
            
            return Ok(dtos);
        }

        /// <summary>
        /// Retorna um músculo pelo ID
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<MusculoDto> GetById(int id)
        {
            var musculo = _service.GetById(id);
            var dto = new MusculoDto
            {
                Id = musculo.Id,
                Nome = musculo.NomeMusculo ?? string.Empty,
                MovimentoPrincipal = musculo.MovimentoPrincipal ?? string.Empty,
                Funcao = musculo.Funcao ?? string.Empty
            };
            
            return Ok(dto);
        }

        /// <summary>
        /// Retorna o músculo com o grupo e todos os exercícios
        /// </summary>
        [HttpGet("{id}/detalhes")]
        public ActionResult<MusculoDetalhesDto> GetWithGrupoAndExercicios(int id)
        {
            var musculo = _service.GetWithGrupoAndExercicios(id);
            var dto = new MusculoDetalhesDto
            {
                Id = musculo.Id,
                Nome = musculo.NomeMusculo ?? string.Empty,
                MovimentoPrincipal = musculo.MovimentoPrincipal ?? string.Empty,
                Funcao = musculo.Funcao ?? string.Empty,
                TipoTecido = musculo.TipoTecido ?? string.Empty,
                FibraMuscular = musculo.FibraMuscular ?? string.Empty,
                GrupoMuscular = musculo.GrupoMuscular?.NomeGrupoMuscular ?? string.Empty,
                Exercicios = musculo.Exercicios?.Select(e => new ExercicioDto
                {
                    Id = e.Id,
                    Nome = e.NomeExercicio ?? string.Empty,
                    Descricao = e.DescricaoExercicio ?? string.Empty
                }).ToList() ?? new()
            };
            
            return Ok(dto);
        }
    }
}
