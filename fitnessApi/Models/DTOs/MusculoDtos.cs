namespace fitnessApi.Models.DTOs
{
    /// <summary>
    /// DTO básico para listagem de músculos
    /// </summary>
    public class MusculoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string MovimentoPrincipal { get; set; } = string.Empty;
        public string Funcao { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO detalhado com grupo e exercícios
    /// </summary>
    public class MusculoDetalhesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string MovimentoPrincipal { get; set; } = string.Empty;
        public string Funcao { get; set; } = string.Empty;
        public string TipoTecido { get; set; } = string.Empty;
        public string FibraMuscular { get; set; } = string.Empty;
        public string GrupoMuscular { get; set; } = string.Empty;
        public List<ExercicioDto> Exercicios { get; set; } = new();
    }

    /// <summary>
    /// DTO para criar/atualizar músculo
    /// </summary>
    public class MusculoRequestDto
    {
        public string Nome { get; set; } = string.Empty;
        public string MovimentoPrincipal { get; set; } = string.Empty;
        public string Funcao { get; set; } = string.Empty;
        public string TipoTecido { get; set; } = string.Empty;
        public string FibraMuscular { get; set; } = string.Empty;
        public int GrupoMuscularId { get; set; }
    }
}
