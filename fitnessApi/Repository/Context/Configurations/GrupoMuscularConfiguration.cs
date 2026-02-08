using fitnessApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fitnessApi.Repository.Context.Configurations
{
    public class GrupoMuscularConfiguration : IEntityTypeConfiguration<GrupoMuscular>
    {
        public void Configure(EntityTypeBuilder<GrupoMuscular> builder)
        {
            builder.HasData(
                new GrupoMuscular
                {
                    Id = 1,
                    NomeGrupoMuscular = "Peito",
                    DescricaoGrupo = "O grupo muscular do peito é composto por músculos como o peitoral maior e o peitoral menor, responsáveis por movimentos de adução, flexão e rotação do braço."
                },
                new GrupoMuscular
                {
                    Id = 2,
                    NomeGrupoMuscular = "Costas",
                    DescricaoGrupo = "O grupo muscular das costas inclui músculos como o latíssimo do dorso, trapézio e romboides, que desempenham um papel crucial na extensão, adução e rotação dos ombros."
                },
                new GrupoMuscular
                {
                    Id = 3,
                    NomeGrupoMuscular = "Pernas",
                    DescricaoGrupo = "O grupo muscular das pernas é composto por músculos como quadríceps, isquiotibiais, glúteos e panturrilhas, responsáveis por movimentos de extensão, flexão e estabilidade durante atividades como caminhar, correr e agachar."
                },
                new GrupoMuscular
                {
                    Id = 4,
                    NomeGrupoMuscular = "Ombros",
                    DescricaoGrupo = "O grupo muscular dos ombros inclui músculos como deltoides, trapézio e manguito rotador, que são essenciais para movimentos de elevação, rotação e estabilidade dos braços."
                },
                new GrupoMuscular
                {
                    Id = 5,
                    NomeGrupoMuscular = "Braços",
                    DescricaoGrupo = "O grupo muscular dos braços é composto por músculos como bíceps, tríceps e braquial, responsáveis por movimentos de flexão, extensão e rotação dos cotovelos."
                },
                new GrupoMuscular
                {
                    Id = 6,
                    NomeGrupoMuscular = "Abdômen",
                    DescricaoGrupo = "O grupo muscular do abdômen inclui músculos como reto abdominal, oblíquos e transverso do abdômen, que desempenham um papel crucial na flexão, rotação e estabilização do tronco."
                },
                new GrupoMuscular
                {
                    Id = 7,
                    NomeGrupoMuscular = "Glúteos",
                    DescricaoGrupo = "O grupo muscular dos glúteos é composto por músculos como glúteo máximo, médio e mínimo, responsáveis por movimentos de extensão, abdução e rotação do quadril, além de desempenharem um papel importante na estabilidade pélvica."
                },
                new GrupoMuscular
                {
                    Id = 8,
                    NomeGrupoMuscular = "Antebraços",
                    DescricaoGrupo = "O grupo muscular dos antebraços inclui músculos como flexores e extensores do punho, que são responsáveis por movimentos de flexão, extensão e rotação dos punhos e dedos."
                }
            );
        }
    }
}
