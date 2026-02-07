using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitnessApi.Models.Entities
{
    public class Exercicios
    {
        [Column("ID")]
        [Key]
        public int Id { get; set; }

        [Column("NOME_EXERCICIO")]
        [Required]
        public string? NomeExercicio { get; set; }

        [Column("DESCRICAO_EXERCICIO")]
        [Required]
        public string? DescricaoExercicio { get; set; }

        [Column("MUSCULOS_ID")]
        [Required]
        [ForeignKey("MusculosId")]
        public int MusculosId { get; set; }

        [InverseProperty("Exercicios")]
        public Musculos Musculos { get; set; }

        public Exercicios(int id, string? nomeExercicio, string? descricaoExercicio, int musculosId)
        {
            Id = id;
            NomeExercicio = nomeExercicio;
            DescricaoExercicio = descricaoExercicio;
            MusculosId = musculosId;
        }

        public Exercicios()
        {
        }
    }
}
