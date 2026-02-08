using fitnessApi.Models.DTOs;
using fitnessApi.Models.Entities;
using fitnessApi.Services.GrupoMuscularService;
using Microsoft.AspNetCore.Mvc;

namespace fitnessApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GruposController : ControllerBase
    {
        private readonly IGrupoMuscularService _service;

        public GruposController(IGrupoMuscularService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os grupos musculares
        /// </summary>
        [HttpGet]
        public ActionResult<List<GrupoMuscularDto>> GetAll()
        {
            var grupos = _service.GetAll();
            var dtos = grupos.Select(g => new GrupoMuscularDto
            {
                Id = g.Id,
                Nome = g.NomeGrupoMuscular ?? string.Empty,
                Descricao = g.DescricaoGrupo ?? string.Empty
            }).ToList();
            
            return Ok(dtos);
        }

        /// <summary>
        /// Retorna um grupo muscular pelo ID
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<GrupoMuscularDto> GetById(int id)
        {
            var grupo = _service.GetById(id);
            var dto = new GrupoMuscularDto
            {
                Id = grupo.Id,
                Nome = grupo.NomeGrupoMuscular ?? string.Empty,
                Descricao = grupo.DescricaoGrupo ?? string.Empty
            };
            
            return Ok(dto);
        }

        /// <summary>
        /// Retorna o grupo muscular com todos os músculos
        /// </summary>
        [HttpGet("{id}/detalhes")]
        public ActionResult<GrupoMuscularDetalhesDto> GetWithMusculos(int id)
        {
            var grupo = _service.GetWithMusculos(id);
            var dto = new GrupoMuscularDetalhesDto
            {
                Id = grupo.Id,
                Nome = grupo.NomeGrupoMuscular ?? string.Empty,
                Descricao = grupo.DescricaoGrupo ?? string.Empty,
                Musculos = grupo.Musculos?.Select(m => new MusculoDto
                {
                    Id = m.Id,
                    Nome = m.NomeMusculo ?? string.Empty,
                    MovimentoPrincipal = m.MovimentoPrincipal ?? string.Empty,
                    Funcao = m.Funcao ?? string.Empty
                }).ToList() ?? new()
            };
            
            return Ok(dto);
        }

        /// <summary>
        /// Cria um novo grupo muscular
        /// </summary>
        [HttpPost]
        public ActionResult<GrupoMuscularDto> Add([FromBody] GrupoMuscularRequestDto request)
        {
            var entity = new GrupoMuscular
            {
                NomeGrupoMuscular = request.Nome,
                DescricaoGrupo = request.Descricao
            };
            
            var created = _service.Add(entity);
            
            var dto = new GrupoMuscularDto
            {
                Id = created.Id,
                Nome = created.NomeGrupoMuscular ?? string.Empty,
                Descricao = created.DescricaoGrupo ?? string.Empty
            };
            
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        /// <summary>
        /// Atualiza um grupo muscular existente
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult<GrupoMuscularDto> Update(int id, [FromBody] GrupoMuscularRequestDto request)
        {
            var entity = new GrupoMuscular
            {
                Id = id,
                NomeGrupoMuscular = request.Nome,
                DescricaoGrupo = request.Descricao
            };
            
            var updated = _service.Update(entity, id);
            
            var dto = new GrupoMuscularDto
            {
                Id = updated.Id,
                Nome = updated.NomeGrupoMuscular ?? string.Empty,
                Descricao = updated.DescricaoGrupo ?? string.Empty
            };
            
            return Ok(dto);
        }

        /// <summary>
        /// Remove um grupo muscular
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
