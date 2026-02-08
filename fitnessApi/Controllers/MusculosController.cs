using fitnessApi.Models.DTOs;
using fitnessApi.Models.Entities;
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

        /// <summary>
        /// Cria um novo músculo
        /// </summary>
        [HttpPost]
        public ActionResult<MusculoDto> Add([FromBody] MusculoRequestDto request)
        {
            var entity = new Musculos
            {
                NomeMusculo = request.Nome,
                MovimentoPrincipal = request.MovimentoPrincipal,
                Funcao = request.Funcao,
                TipoTecido = request.TipoTecido,
                FibraMuscular = request.FibraMuscular,
                GrupoMuscularId = request.GrupoMuscularId
            };
            
            var created = _service.Add(entity);
            
            var dto = new MusculoDto
            {
                Id = created.Id,
                Nome = created.NomeMusculo ?? string.Empty,
                MovimentoPrincipal = created.MovimentoPrincipal ?? string.Empty,
                Funcao = created.Funcao ?? string.Empty
            };
            
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        /// <summary>
        /// Atualiza um músculo existente
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult<MusculoDto> Update(int id, [FromBody] MusculoRequestDto request)
        {
            var entity = new Musculos
            {
                Id = id,
                NomeMusculo = request.Nome,
                MovimentoPrincipal = request.MovimentoPrincipal,
                Funcao = request.Funcao,
                TipoTecido = request.TipoTecido,
                FibraMuscular = request.FibraMuscular,
                GrupoMuscularId = request.GrupoMuscularId
            };
            
            var updated = _service.Update(entity, id);
            
            var dto = new MusculoDto
            {
                Id = updated.Id,
                Nome = updated.NomeMusculo ?? string.Empty,
                MovimentoPrincipal = updated.MovimentoPrincipal ?? string.Empty,
                Funcao = updated.Funcao ?? string.Empty
            };
            
            return Ok(dto);
        }

        /// <summary>
        /// Remove um músculo
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
