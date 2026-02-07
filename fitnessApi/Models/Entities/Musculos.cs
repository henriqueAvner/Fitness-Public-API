using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitnessApi.Models.Entities
{
    public class Musculos
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        [Column("NOME_MUSCULO")]
        [Required]
        public string? NomeMusculo { get; set; }

        [Column("MOVIMENTO_PRINCIPAL")]
        [Required]
        public string? MovimentoPrincipal { get; set; }

        [Column("FUNCAO")]
        [Required]
        public string? Funcao { get; set; }

        [Column("TIPO_TECIDO")]
        [Required]
        public string? TipoTecido { get; set; }

        [ForeignKey("GrupoMuscularId")]
        [Column("GRUPO_MUSCULAR_ID")]
        [Required]
        public int GrupoMuscularId { get; set; }

       
        [Required]
        [InverseProperty("Musculos")]
        public GrupoMuscular GrupoMuscular { get; set; }

        [Column("FIBRA_MUSCULAR")]
        [Required]
        public string? FibraMuscular { get; set; }

        [Column("EXERCICIOS")]
        public List<Exercicios> Exercicios { get; set; } = new List<Exercicios>();

        public Musculos(int id, string? nomeMusculo, string? movimentoPrincipal, string? funcao, string? tipoTecido, int grupoMuscularId, string? fibraMuscular, List<Exercicios> exercicios)
        {
            Id = id;
            NomeMusculo = nomeMusculo;
            MovimentoPrincipal = movimentoPrincipal;
            Funcao = funcao;
            TipoTecido = tipoTecido;
            GrupoMuscularId = grupoMuscularId;
            FibraMuscular = fibraMuscular;
            Exercicios = exercicios;
        }

        public Musculos() {}
    }
}