using fitnessApi.Models.DTOs;
using fitnessApi.Services.ExercicioService;
using Microsoft.AspNetCore.Mvc;

namespace fitnessApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciciosController : ControllerBase
    {
        private readonly IExercicioService _service;

        public ExerciciosController(IExercicioService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os exercícios
        /// </summary>
        [HttpGet]
        public ActionResult<List<ExercicioDto>> GetAll()
        {
            var exercicios = _service.GetAll();
            var dtos = exercicios.Select(e => new ExercicioDto
            {
                Id = e.Id,
                Nome = e.NomeExercicio ?? string.Empty,
                Descricao = e.DescricaoExercicio ?? string.Empty
            }).ToList();
            
            return Ok(dtos);
        }

        /// <summary>
        /// Retorna um exercício pelo ID
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<ExercicioDto> GetById(int id)
        {
            var exercicio = _service.GetById(id);
            var dto = new ExercicioDto
            {
                Id = exercicio.Id,
                Nome = exercicio.NomeExercicio ?? string.Empty,
                Descricao = exercicio.DescricaoExercicio ?? string.Empty
            };
            
            return Ok(dto);
        }

        /// <summary>
        /// Retorna o exercício com o músculo e o grupo muscular
        /// </summary>
        [HttpGet("{id}/detalhes")]
        public ActionResult<ExercicioDetalhesDto> GetWithMusculoAndGrupo(int id)
        {
            var exercicio = _service.GetWithMusculoAndGrupo(id);
            var dto = new ExercicioDetalhesDto
            {
                Id = exercicio.Id,
                Nome = exercicio.NomeExercicio ?? string.Empty,
                Descricao = exercicio.DescricaoExercicio ?? string.Empty,
                Musculo = exercicio.Musculos?.NomeMusculo ?? string.Empty,
                GrupoMuscular = exercicio.Musculos?.GrupoMuscular?.NomeGrupoMuscular ?? string.Empty
            };
            
            return Ok(dto);
        }
    }
}