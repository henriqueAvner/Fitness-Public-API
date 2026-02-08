using fitnessApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fitnessApi.Repository.Context.Configurations
{
    public class MusculosConfiguration : IEntityTypeConfiguration<Musculos>
    {
        public void Configure(EntityTypeBuilder<Musculos> builder)
        {
            builder.HasMany(e => e.Exercicios)
                .WithOne(m => m.Musculos)
                .HasForeignKey(e => e.MusculosId);

            builder.HasOne(g => g.GrupoMuscular)
                .WithMany(m => m.Musculos)
                .HasForeignKey(g => g.GrupoMuscularId);

            builder.HasData(
                // ========== PEITO (GrupoMuscularId = 1) ==========
                new { 
                    Id = 1, 
                    NomeMusculo = "Peitoral Maior", 
                    MovimentoPrincipal = "Adução horizontal, flexão e rotação interna do ombro", 
                    Funcao = "Adução do braço, Rotação medial do úmero, Flexão do braço, Extensão do braço", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 1, 
                    FibraMuscular = "Tipo II (força e potência)" 
                },
                new { 
                    Id = 2, 
                    NomeMusculo = "Peitoral Menor", 
                    MovimentoPrincipal = "Depressão e protração da escápula", 
                    Funcao = "Abdução e depressão da escápula, Rotação inferior da escápula, Auxiliar na respiração", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 1, 
                    FibraMuscular = "Tipo I (estabilização)" 
                },

                // ========== COSTAS (GrupoMuscularId = 2) ==========
                new { 
                    Id = 3, 
                    NomeMusculo = "Trapézio", 
                    MovimentoPrincipal = "Elevação, retração e rotação da escápula", 
                    Funcao = "Elevação da escápula, Retração da escápula, Depressão da escápula, Rotação superior da escápula, Extensão e rotação da cabeça/pescoço", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 2, 
                    FibraMuscular = "Tipo I (postura e estabilização)" 
                },
                new { 
                    Id = 4, 
                    NomeMusculo = "Grande Dorsal (Latíssimo do Dorso)", 
                    MovimentoPrincipal = "Extensão, adução e rotação interna do ombro", 
                    Funcao = "Extensão do braço, Adução do braço, Rotação medial do úmero, Auxiliar na respiração", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 2, 
                    FibraMuscular = "Tipo II (força)" 
                },
                new { 
                    Id = 5, 
                    NomeMusculo = "Romboides (Maior e Menor)", 
                    MovimentoPrincipal = "Retração e elevação da escápula", 
                    Funcao = "Retração da escápula, Elevação da escápula, Rotação inferior da escápula", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 2, 
                    FibraMuscular = "Tipo I (estabilização postural)" 
                },

                // ========== PERNAS (GrupoMuscularId = 3) ==========
                new { 
                    Id = 6, 
                    NomeMusculo = "Quadríceps Femoral", 
                    MovimentoPrincipal = "Extensão do joelho, flexão do quadril", 
                    Funcao = "Extensão do joelho, Flexão do quadril", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 3, 
                    FibraMuscular = "Tipo II (força e potência)" 
                },
                new { 
                    Id = 7, 
                    NomeMusculo = "Isquiotibiais", 
                    MovimentoPrincipal = "Flexão do joelho, extensão do quadril", 
                    Funcao = "Flexão do joelho, Extensão do quadril, Rotação medial e lateral da perna", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 3, 
                    FibraMuscular = "Tipo I e II (misto)" 
                },
                new { 
                    Id = 8, 
                    NomeMusculo = "Gastrocnêmio", 
                    MovimentoPrincipal = "Flexão plantar, flexão do joelho", 
                    Funcao = "Flexão plantar do tornozelo, Flexão do joelho", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 3, 
                    FibraMuscular = "Tipo II (explosão)" 
                },
                new { 
                    Id = 9, 
                    NomeMusculo = "Sóleo", 
                    MovimentoPrincipal = "Flexão plantar", 
                    Funcao = "Flexão plantar do tornozelo", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 3, 
                    FibraMuscular = "Tipo I (resistência e postura)" 
                },

                // ========== OMBROS (GrupoMuscularId = 4) ==========
                new { 
                    Id = 10, 
                    NomeMusculo = "Deltoide", 
                    MovimentoPrincipal = "Abdução, flexão e extensão do ombro", 
                    Funcao = "Abdução do braço, Flexão e rotação medial, Extensão e rotação lateral", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 4, 
                    FibraMuscular = "Tipo II (força)" 
                },
                new { 
                    Id = 11, 
                    NomeMusculo = "Manguito Rotador - Supraespinal", 
                    MovimentoPrincipal = "Abdução inicial e estabilização", 
                    Funcao = "Abdução do ombro (primeiros 15-30°), Estabilização da articulação glenoumeral", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 4, 
                    FibraMuscular = "Tipo I (estabilização)" 
                },
                new { 
                    Id = 12, 
                    NomeMusculo = "Manguito Rotador - Infraespinal", 
                    MovimentoPrincipal = "Rotação externa e estabilização", 
                    Funcao = "Rotação lateral do braço, Estabilização da articulação glenoumeral", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 4, 
                    FibraMuscular = "Tipo I (estabilização)" 
                },
                new { 
                    Id = 13, 
                    NomeMusculo = "Manguito Rotador - Redondo Menor", 
                    MovimentoPrincipal = "Rotação externa e estabilização", 
                    Funcao = "Rotação lateral do braço, Adução do braço, Estabilização da articulação glenoumeral", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 4, 
                    FibraMuscular = "Tipo I (estabilização)" 
                },
                new { 
                    Id = 14, 
                    NomeMusculo = "Manguito Rotador - Subescapular", 
                    MovimentoPrincipal = "Rotação interna e estabilização", 
                    Funcao = "Rotação medial do braço, Adução do braço, Estabilização da articulação glenoumeral", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 4, 
                    FibraMuscular = "Tipo I (estabilização)" 
                },

                // ========== BRAÇOS (GrupoMuscularId = 5) ==========
                new { 
                    Id = 15, 
                    NomeMusculo = "Bíceps Braquial", 
                    MovimentoPrincipal = "Flexão do cotovelo, supinação", 
                    Funcao = "Flexão do cotovelo, Supinação do antebraço, Flexão do ombro (auxiliar)", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 5, 
                    FibraMuscular = "Tipo II (força)" 
                },
                new { 
                    Id = 16, 
                    NomeMusculo = "Tríceps Braquial", 
                    MovimentoPrincipal = "Extensão do cotovelo", 
                    Funcao = "Extensão do cotovelo, Extensão e adução do ombro (cabeça longa)", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 5, 
                    FibraMuscular = "Tipo II (força)" 
                },
                new { 
                    Id = 17, 
                    NomeMusculo = "Braquial", 
                    MovimentoPrincipal = "Flexão do cotovelo", 
                    Funcao = "Flexão do cotovelo (principal flexor)", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 5, 
                    FibraMuscular = "Tipo II (força)" 
                },

                // ========== ABDÔMEN (GrupoMuscularId = 6) ==========
                new { 
                    Id = 18, 
                    NomeMusculo = "Reto Abdominal", 
                    MovimentoPrincipal = "Flexão do tronco", 
                    Funcao = "Flexão do tronco, Compressão das vísceras abdominais, Expiração forçada", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 6, 
                    FibraMuscular = "Tipo I e II (misto)" 
                },
                new { 
                    Id = 19, 
                    NomeMusculo = "Oblíquo Externo", 
                    MovimentoPrincipal = "Flexão, rotação e inclinação lateral", 
                    Funcao = "Flexão do tronco, Flexão lateral ipsilateral, Rotação contralateral, Compressão abdominal", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 6, 
                    FibraMuscular = "Tipo I (postura)" 
                },
                new { 
                    Id = 20, 
                    NomeMusculo = "Oblíquo Interno", 
                    MovimentoPrincipal = "Flexão, rotação e inclinação lateral", 
                    Funcao = "Flexão do tronco, Flexão lateral ipsilateral, Rotação ipsilateral, Compressão abdominal", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 6, 
                    FibraMuscular = "Tipo I (postura)" 
                },
                new { 
                    Id = 21, 
                    NomeMusculo = "Transverso do Abdome", 
                    MovimentoPrincipal = "Estabilização do core, compressão abdominal", 
                    Funcao = "Compressão abdominal (principal), Estabilização da coluna lombar, Expiração forçada, Aumento da pressão intra-abdominal", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 6, 
                    FibraMuscular = "Tipo I (estabilização)" 
                },

                // ========== GLÚTEOS (GrupoMuscularId = 7) ==========
                new { 
                    Id = 22, 
                    NomeMusculo = "Glúteo Máximo", 
                    MovimentoPrincipal = "Extensão e rotação externa do quadril", 
                    Funcao = "Extensão do quadril (principal), Rotação lateral da coxa, Estabilização da pelve", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 7, 
                    FibraMuscular = "Tipo II (força e potência)" 
                },
                new { 
                    Id = 23, 
                    NomeMusculo = "Glúteo Médio", 
                    MovimentoPrincipal = "Abdução e estabilização pélvica", 
                    Funcao = "Abdução da coxa, Rotação medial da coxa (fibras anteriores), Estabilização da pelve durante a marcha", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 7, 
                    FibraMuscular = "Tipo I (estabilização)" 
                },
                new { 
                    Id = 24, 
                    NomeMusculo = "Glúteo Mínimo", 
                    MovimentoPrincipal = "Abdução e rotação interna do quadril", 
                    Funcao = "Abdução da coxa, Rotação medial da coxa, Estabilização da pelve", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 7, 
                    FibraMuscular = "Tipo I (estabilização)" 
                },

                // ========== ANTEBRAÇOS (GrupoMuscularId = 8) ==========
                new { 
                    Id = 25, 
                    NomeMusculo = "Flexor Radial do Carpo", 
                    MovimentoPrincipal = "Flexão e desvio radial do punho", 
                    Funcao = "Flexão do punho, Abdução da mão (desvio radial)", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 8, 
                    FibraMuscular = "Tipo I (resistência)" 
                },
                new { 
                    Id = 26, 
                    NomeMusculo = "Flexor Ulnar do Carpo", 
                    MovimentoPrincipal = "Flexão e desvio ulnar do punho", 
                    Funcao = "Flexão do punho, Adução da mão (desvio ulnar)", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 8, 
                    FibraMuscular = "Tipo I (resistência)" 
                },
                new { 
                    Id = 27, 
                    NomeMusculo = "Flexor Superficial dos Dedos", 
                    MovimentoPrincipal = "Flexão dos dedos e punho", 
                    Funcao = "Flexão das articulações interfalângicas proximais, Flexão do punho", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 8, 
                    FibraMuscular = "Tipo I (resistência)" 
                },
                new { 
                    Id = 28, 
                    NomeMusculo = "Flexor Profundo dos Dedos", 
                    MovimentoPrincipal = "Flexão distal dos dedos", 
                    Funcao = "Flexão das articulações interfalângicas distais", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 8, 
                    FibraMuscular = "Tipo I (resistência)" 
                },
                new { 
                    Id = 29, 
                    NomeMusculo = "Extensor Radial Longo do Carpo", 
                    MovimentoPrincipal = "Extensão e desvio radial do punho", 
                    Funcao = "Extensão do punho, Abdução da mão (desvio radial)", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 8, 
                    FibraMuscular = "Tipo I (resistência)" 
                },
                new { 
                    Id = 30, 
                    NomeMusculo = "Extensor Radial Curto do Carpo", 
                    MovimentoPrincipal = "Extensão do punho", 
                    Funcao = "Extensão do punho, Abdução da mão", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 8, 
                    FibraMuscular = "Tipo I (resistência)" 
                },
                new { 
                    Id = 31, 
                    NomeMusculo = "Extensor Ulnar do Carpo", 
                    MovimentoPrincipal = "Extensão e desvio ulnar do punho", 
                    Funcao = "Extensão do punho, Adução da mão (desvio ulnar)", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 8, 
                    FibraMuscular = "Tipo I (resistência)" 
                },
                new { 
                    Id = 32, 
                    NomeMusculo = "Extensor dos Dedos", 
                    MovimentoPrincipal = "Extensão dos dedos e punho", 
                    Funcao = "Extensão das articulações metacarpofalângicas, Extensão do punho", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 8, 
                    FibraMuscular = "Tipo I (resistência)" 
                },
                new { 
                    Id = 33, 
                    NomeMusculo = "Pronador Redondo", 
                    MovimentoPrincipal = "Pronação do antebraço", 
                    Funcao = "Pronação do antebraço, Flexão do cotovelo (auxiliar)", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 8, 
                    FibraMuscular = "Tipo I (resistência)" 
                },
                new { 
                    Id = 34, 
                    NomeMusculo = "Supinador", 
                    MovimentoPrincipal = "Supinação do antebraço", 
                    Funcao = "Supinação do antebraço", 
                    TipoTecido = "Muscular estriado esquelético", 
                    GrupoMuscularId = 8, 
                    FibraMuscular = "Tipo I (resistência)" 
                }
            );
        }
    }
}
