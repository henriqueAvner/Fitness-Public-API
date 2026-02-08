namespace fitnessApi.Models.DTOs
{
    /// <summary>
    /// DTO básico para listagem de grupos musculares
    /// </summary>
    public class GrupoMuscularDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO detalhado com músculos
    /// </summary>
    public class GrupoMuscularDetalhesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public List<MusculoDto> Musculos { get; set; } = new();
    }

    /// <summary>
    /// DTO para criar/atualizar grupo muscular
    /// </summary>
    public class GrupoMuscularRequestDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}
