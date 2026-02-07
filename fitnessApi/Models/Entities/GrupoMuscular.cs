using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fitnessApi.Models.Entities
{
    public class GrupoMuscular
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("NOME_GRUPO_MUSCULAR")]
        public string? NomeGrupoMuscular { get; set; }

        [Column("DESCRICAO_GRUPO")]
        public string? DescricaoGrupo { get; set; }

        [Column("MUSCULOS")]
        [Required]
        [InverseProperty("GrupoMuscular")]
        public List<Musculos> Musculos { get; set; } = new List<Musculos>();

        public GrupoMuscular(int id, string? nomeGrupoMuscular, string? descricaoGrupo, List<Musculos> musculos)
        {
            Id = id;
            NomeGrupoMuscular = nomeGrupoMuscular;
            DescricaoGrupo = descricaoGrupo;
            Musculos = musculos;
        }

        public GrupoMuscular()
        {
        }
    }
}
