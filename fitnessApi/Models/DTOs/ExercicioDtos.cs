namespace fitnessApi.Models.DTOs
{
    /// <summary>
    /// DTO básico para listagem de exercícios
    /// </summary>
    public class ExercicioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO detalhado com músculo e grupo muscular
    /// </summary>
    public class ExercicioDetalhesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Musculo { get; set; } = string.Empty;
        public string GrupoMuscular { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO para criar/atualizar exercício
    /// </summary>
    public class ExercicioRequestDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int MusculoId { get; set; }
    }
}
