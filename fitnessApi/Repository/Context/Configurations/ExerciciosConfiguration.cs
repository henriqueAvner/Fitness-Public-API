using fitnessApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fitnessApi.Repository.Context.Configurations
{
    public class ExerciciosConfiguration : IEntityTypeConfiguration<Exercicios>
    {
        public void Configure(EntityTypeBuilder<Exercicios> builder)
        {
            builder.HasData(
                // ========== PEITORAL MAIOR (MusculosId = 1) ==========
                new { 
                    Id = 1, 
                    NomeExercicio = "Supino Reto com Barra", 
                    DescricaoExercicio = "Deite-se em um banco plano com os pés apoiados no chão. Segure a barra com as mãos afastadas um pouco além da largura dos ombros, com pegada pronada. Desça a barra de forma controlada até tocar o peitoral, mantendo os cotovelos em ângulo de aproximadamente 45 graus em relação ao corpo. Empurre a barra de volta à posição inicial, estendendo completamente os braços. Mantenha as escápulas retraídas e o core ativado durante todo o movimento.", 
                    MusculosId = 1 
                },
                new { 
                    Id = 2, 
                    NomeExercicio = "Crucifixo com Halteres", 
                    DescricaoExercicio = "Deite-se em um banco plano segurando um halter em cada mão, com os braços estendidos acima do peito e as palmas das mãos voltadas uma para a outra (pegada neutra). Com uma ligeira flexão nos cotovelos, abra os braços lateralmente em um movimento de arco controlado até sentir um alongamento no peitoral. Retorne à posição inicial contraindo o peitoral, como se estivesse abraçando algo. Evite estender ou flexionar excessivamente os cotovelos durante o movimento e mantenha o controle na fase excêntrica.", 
                    MusculosId = 1 
                },

                // ========== PEITORAL MENOR (MusculosId = 2) ==========
                new { 
                    Id = 3, 
                    NomeExercicio = "Flexão de Braço Inclinada", 
                    DescricaoExercicio = "Posicione as mãos em uma superfície elevada (banco ou step) com os braços estendidos na largura dos ombros. Mantenha o corpo em linha reta dos pés à cabeça, com o core ativado. Desça o corpo de forma controlada, flexionando os cotovelos até o peito quase tocar a superfície. Empurre o corpo de volta à posição inicial. A inclinação reduz a carga e permite maior ênfase na porção superior do peitoral e no peitoral menor.", 
                    MusculosId = 2 
                },
                new { 
                    Id = 4, 
                    NomeExercicio = "Mergulho nas Paralelas (Foco Peitoral)", 
                    DescricaoExercicio = "Apoie-se nas barras paralelas com os braços estendidos e o corpo suspenso. Incline o tronco ligeiramente para frente (cerca de 30 graus) e mantenha os cotovelos levemente afastados do corpo. Desça de forma controlada flexionando os cotovelos até sentir alongamento no peitoral. Empurre o corpo de volta à posição inicial contraindo o peitoral. A inclinação do tronco e a abertura dos cotovelos enfatizam o trabalho do peitoral em relação ao tríceps.", 
                    MusculosId = 2 
                },

                // ========== TRAPÉZIO (MusculosId = 3) ==========
                new { 
                    Id = 5, 
                    NomeExercicio = "Encolhimento de Ombros com Barra", 
                    DescricaoExercicio = "Fique em pé segurando uma barra com as mãos na largura dos ombros e pegada pronada, com os braços estendidos à frente do corpo. Mantenha a coluna ereta e os ombros relaxados na posição inicial. Eleve os ombros em direção às orelhas contraindo o trapézio, sem dobrar os cotovelos. Mantenha a contração no topo por 1-2 segundos e depois desça os ombros de forma controlada. Evite rolar os ombros; o movimento deve ser vertical.", 
                    MusculosId = 3 
                },
                new { 
                    Id = 6, 
                    NomeExercicio = "Remada Alta com Barra", 
                    DescricaoExercicio = "Fique em pé segurando uma barra com pegada pronada, mãos afastadas na largura dos ombros ou ligeiramente mais próximas. Mantenha a coluna ereta e o core ativado. Puxe a barra verticalmente em direção ao queixo, elevando os cotovelos acima da linha dos ombros. Os cotovelos devem liderar o movimento, mantendo-se sempre acima das mãos. Desça a barra de forma controlada até a posição inicial. Este exercício trabalha principalmente as fibras superiores do trapézio e os deltoides.", 
                    MusculosId = 3 
                },

                // ========== GRANDE DORSAL (MusculosId = 4) ==========
                new { 
                    Id = 7, 
                    NomeExercicio = "Barra Fixa (Pegada Pronada)", 
                    DescricaoExercicio = "Segure a barra com pegada pronada (palmas voltadas para frente) e as mãos afastadas um pouco além da largura dos ombros. Pendure-se com os braços completamente estendidos. Puxe o corpo para cima contraindo as costas até o queixo ultrapassar a barra ou o peito tocar a barra. Foque em puxar os cotovelos para baixo e para trás, contraindo as escápulas. Desça de forma controlada até a posição inicial. Se necessário, use assistência ou peso adicional conforme seu nível.", 
                    MusculosId = 4 
                },
                new { 
                    Id = 8, 
                    NomeExercicio = "Remada Curvada com Barra", 
                    DescricaoExercicio = "Fique em pé segurando uma barra com pegada pronada, mãos afastadas além da largura dos ombros. Incline o tronco para frente mantendo as costas retas e os joelhos levemente flexionados, até o tronco ficar em ângulo de aproximadamente 45 graus. Deixe a barra pendurada com os braços estendidos. Puxe a barra em direção à parte inferior do abdômen, contraindo as escápulas e mantendo os cotovelos próximos ao corpo. Desça a barra de forma controlada. Evite arredondar as costas ou usar impulso do corpo.", 
                    MusculosId = 4 
                },

                // ========== ROMBOIDES (MusculosId = 5) ==========
                new { 
                    Id = 9, 
                    NomeExercicio = "Remada Sentada com Polia", 
                    DescricaoExercicio = "Sente-se no aparelho de remada baixa com os pés apoiados na plataforma e joelhos levemente flexionados. Segure o puxador triangular ou a barra reta com as mãos. Mantenha a coluna ereta e o peito para fora. Puxe o puxador em direção ao abdômen, focando em retrair as escápulas (aproximá-las da coluna). Mantenha os cotovelos próximos ao corpo e aperte as escápulas no final do movimento. Retorne de forma controlada, permitindo que as escápulas se afastem novamente.", 
                    MusculosId = 5 
                },
                new { 
                    Id = 10, 
                    NomeExercicio = "Crucifixo Inverso com Halteres", 
                    DescricaoExercicio = "Deite-se de bruços em um banco inclinado ou fique em pé inclinando o tronco para frente. Segure um halter em cada mão com os braços pendurados e palmas voltadas uma para a outra. Mantenha uma ligeira flexão nos cotovelos. Eleve os braços lateralmente em movimento de arco até a altura dos ombros, focando em contrair as escápulas. Mantenha a contração no topo e desça de forma controlada. Este exercício trabalha intensamente os romboides e a porção posterior do deltoide.", 
                    MusculosId = 5 
                },

                // ========== QUADRÍCEPS FEMORAL (MusculosId = 6) ==========
                new { 
                    Id = 11, 
                    NomeExercicio = "Agachamento Livre com Barra", 
                    DescricaoExercicio = "Posicione a barra nas costas, apoiada no trapézio (não no pescoço). Fique em pé com os pés afastados na largura dos ombros ou ligeiramente mais, com os dedos levemente voltados para fora. Mantenha o peito para cima e o core ativado. Inicie o movimento empurrando os quadris para trás e flexionando os joelhos, descendo até as coxas ficarem paralelas ao solo ou abaixo (profundidade completa). Mantenha os joelhos alinhados com a ponta dos pés. Empurre o chão com os pés para retornar à posição inicial, mantendo a coluna neutra durante todo o movimento.", 
                    MusculosId = 6 
                },
                new { 
                    Id = 12, 
                    NomeExercicio = "Leg Press 45°", 
                    DescricaoExercicio = "Sente-se no aparelho de leg press com as costas e a cabeça bem apoiadas no encosto. Posicione os pés na plataforma afastados na largura dos ombros, com os calcanhares alinhados. Destrave o aparelho e desça a plataforma de forma controlada, flexionando os joelhos até formar um ângulo de aproximadamente 90 graus. Empurre a plataforma de volta estendendo as pernas, mas sem travar completamente os joelhos no topo. Mantenha os glúteos e as costas sempre em contato com o banco.", 
                    MusculosId = 6 
                },

                // ========== ISQUIOTIBIAIS (MusculosId = 7) ==========
                new { 
                    Id = 13, 
                    NomeExercicio = "Flexão de Pernas na Máquina (Mesa Flexora)", 
                    DescricaoExercicio = "Deite-se de bruços na máquina flexora com os joelhos alinhados com o eixo de rotação do aparelho. Posicione os calcanhares sob o rolo acolchoado. Segure nas alças laterais e mantenha o quadril em contato com o banco. Flexione os joelhos trazendo os calcanhares em direção aos glúteos, contraindo os isquiotibiais. Mantenha a contração no topo por 1 segundo e desça de forma controlada. Evite arquear excessivamente a lombar durante o movimento.", 
                    MusculosId = 7 
                },
                new { 
                    Id = 14, 
                    NomeExercicio = "Stiff com Barra (Levantamento Terra Romeno)", 
                    DescricaoExercicio = "Fique em pé segurando uma barra com pegada pronada, mãos na largura dos ombros, com a barra apoiada na frente das coxas. Mantenha os joelhos levemente flexionados (semiflexionados) e travados nesta posição. Incline o tronco para frente empurrando o quadril para trás, mantendo a coluna neutra (reta) durante todo o movimento. Desça a barra deslizando-a próxima às pernas até sentir alongamento nos isquiotibiais. Retorne à posição inicial contraindo os isquiotibiais e glúteos, empurrando o quadril para frente. Mantenha o core ativado.", 
                    MusculosId = 7 
                },

                // ========== GASTROCNÊMIO (MusculosId = 8) ==========
                new { 
                    Id = 15, 
                    NomeExercicio = "Elevação de Panturrilha em Pé", 
                    DescricaoExercicio = "Posicione-se em uma máquina de panturrilha em pé ou com uma barra nas costas, com a parte anterior dos pés (metatarsos) apoiados em um step ou plataforma elevada e os calcanhares suspensos. Mantenha as pernas estendidas (joelhos levemente flexionados). Desça os calcanhares o máximo possível para alongar a panturrilha. Em seguida, eleve os calcanhares o mais alto possível contraindo os gastrocnêmios, ficando na ponta dos pés. Mantenha a contração no topo por 1 segundo e desça de forma controlada.", 
                    MusculosId = 8 
                },
                new { 
                    Id = 16, 
                    NomeExercicio = "Elevação de Panturrilha no Leg Press", 
                    DescricaoExercicio = "Sente-se no leg press e posicione apenas a parte anterior dos pés (metatarsos) na borda inferior da plataforma, deixando os calcanhares livres para moverem-se. Estenda as pernas quase completamente e destrave o aparelho. Deixe os calcanhares descerem em direção ao corpo para alongar as panturrilhas. Empurre a plataforma com a parte anterior dos pés, elevando os calcanhares o máximo possível. Mantenha a contração e retorne de forma controlada. Este exercício permite usar cargas mais pesadas.", 
                    MusculosId = 8 
                },

                // ========== SÓLEO (MusculosId = 9) ==========
                new { 
                    Id = 17, 
                    NomeExercicio = "Elevação de Panturrilha Sentado", 
                    DescricaoExercicio = "Sente-se na máquina de panturrilha sentado com os pés apoiados na plataforma e os joelhos sob as almofadas. Ajuste a almofada para que fique apoiada confortavelmente sobre as coxas. Destrave o aparelho e deixe os calcanhares descerem o máximo possível para alongar o sóleo. Eleve os calcanhares pressionando a parte anterior dos pés contra a plataforma, contraindo intensamente o sóleo. O movimento deve ser controlado tanto na subida quanto na descida.", 
                    MusculosId = 9 
                },
                new { 
                    Id = 18, 
                    NomeExercicio = "Elevação de Panturrilha Unilateral", 
                    DescricaoExercicio = "Fique em pé próximo a uma parede ou suporte para equilíbrio. Posicione a parte anterior de um pé em um step ou superfície elevada com o calcanhar suspenso. Mantenha o joelho dessa perna levemente flexionado (o que enfatiza o sóleo). A outra perna pode ficar relaxada ou cruzada atrás. Desça o calcanhar o máximo possível e depois eleve-o contraindo o sóleo. Faça o movimento completo e controlado. Execute todas as repetições de um lado antes de trocar.", 
                    MusculosId = 9 
                },

                // ========== DELTOIDE (MusculosId = 10) ==========
                new { 
                    Id = 19, 
                    NomeExercicio = "Desenvolvimento com Barra (Military Press)", 
                    DescricaoExercicio = "Fique em pé ou sentado com a barra apoiada na altura dos ombros, pegada pronada com as mãos afastadas um pouco além da largura dos ombros. Mantenha o core ativado e a coluna ereta. Empurre a barra verticalmente acima da cabeça até a extensão completa dos braços, mantendo a barra alinhada sobre a cabeça e os ombros. Desça a barra de forma controlada até a posição inicial (altura do queixo/clavícula). Evite arquear excessivamente a lombar.", 
                    MusculosId = 10 
                },
                new { 
                    Id = 20, 
                    NomeExercicio = "Elevação Lateral com Halteres", 
                    DescricaoExercicio = "Fique em pé segurando um halter em cada mão ao lado do corpo, com as palmas voltadas para dentro. Mantenha os cotovelos levemente flexionados e travados nesta posição. Eleve os braços lateralmente em um movimento de arco até os halteres ficarem na altura dos ombros (ou ligeiramente abaixo). Os cotovelos devem estar no mesmo nível ou ligeiramente acima dos punhos. Mantenha a contração por 1 segundo e desça de forma controlada. Evite usar impulso ou balançar o corpo.", 
                    MusculosId = 10 
                },

                // ========== MANGUITO ROTADOR - SUPRAESPINAL (MusculosId = 11) ==========
                new { 
                    Id = 21, 
                    NomeExercicio = "Abdução com Elástico (Posição Neutra)", 
                    DescricaoExercicio = "Fique em pé com uma faixa elástica presa sob o pé ou em um ponto baixo. Segure a outra extremidade com a mão do mesmo lado. Mantenha o braço ao lado do corpo com o cotovelo levemente flexionado. Afaste o braço lateralmente até aproximadamente 30-45 graus (não mais alto que isso para focar no supraespinal). Execute o movimento de forma lenta e controlada, tanto na subida quanto na descida. Use carga leve e foque no controle.", 
                    MusculosId = 11 
                },
                new { 
                    Id = 22, 
                    NomeExercicio = "Scaption (Elevação no Plano Escapular)", 
                    DescricaoExercicio = "Fique em pé segurando halteres leves ao lado do corpo. Posicione os braços cerca de 30 graus à frente do corpo (plano escapular). Mantenha os polegares apontados para cima e os cotovelos quase totalmente estendidos. Eleve os braços simultaneamente neste plano diagonal até aproximadamente a altura dos ombros. Desça de forma controlada. Este exercício é específico para o supraespinal e deve ser feito com carga leve e execução perfeita.", 
                    MusculosId = 11 
                },

                // ========== MANGUITO ROTADOR - INFRAESPINAL (MusculosId = 12) ==========
                new { 
                    Id = 23, 
                    NomeExercicio = "Rotação Externa com Elástico", 
                    DescricaoExercicio = "Fique em pé lateralmente a uma faixa elástica presa na altura da cintura. Segure a ponta do elástico com a mão mais distante da fixação. Mantenha o cotovelo flexionado a 90 graus e colado ao tronco. Partindo da posição com a mão próxima ao umbigo, gire externamente o antebraço afastando a mão do corpo, mantendo o cotovelo fixo no tronco. Retorne de forma controlada. O movimento deve ocorrer apenas no ombro.", 
                    MusculosId = 12 
                },
                new { 
                    Id = 24, 
                    NomeExercicio = "Rotação Externa Deitado com Halter", 
                    DescricaoExercicio = "Deite-se lateralmente em um banco com o braço de cima segurando um halter leve. Mantenha o cotovelo flexionado a 90 graus e apoiado ao longo do tronco. O antebraço deve começar apontando para baixo. Gire externamente o ombro elevando o halter em um arco até o antebraço ficar próximo da vertical. Mantenha o cotovelo sempre em contato com o tronco. Desça de forma controlada. Use peso leve e movimento controlado.", 
                    MusculosId = 12 
                },

                // ========== MANGUITO ROTADOR - REDONDO MENOR (MusculosId = 13) ==========
                new { 
                    Id = 25, 
                    NomeExercicio = "Rotação Externa em Pé com Halteres", 
                    DescricaoExercicio = "Fique em pé segurando halteres leves com os braços ao lado do corpo. Flexione os cotovelos a 90 graus mantendo-os fixos junto ao tronco. As palmas devem estar voltadas para dentro inicialmente. Gire os antebraços para fora (rotação externa), afastando as mãos do corpo enquanto os cotovelos permanecem fixos. Retorne à posição inicial de forma controlada. O movimento é pequeno e isolado no ombro.", 
                    MusculosId = 13 
                },
                new { 
                    Id = 26, 
                    NomeExercicio = "Face Pull (Puxada Facial)", 
                    DescricaoExercicio = "Posicione-se em frente a uma polia alta com uma corda ou puxador de corda anexado. Segure as extremidades da corda com pegada neutra. Dê alguns passos para trás para criar tensão. Puxe a corda em direção ao rosto, abrindo as mãos lateralmente e mantendo os cotovelos elevados acima da linha dos ombros. Foque em contrair as escápulas e girar externamente os ombros. Retorne de forma controlada. Este exercício trabalha o redondo menor, infraespinal e porção posterior do deltoide.", 
                    MusculosId = 13 
                },

                // ========== MANGUITO ROTADOR - SUBESCAPULAR (MusculosId = 14) ==========
                new { 
                    Id = 27, 
                    NomeExercicio = "Rotação Interna com Elástico", 
                    DescricaoExercicio = "Fique em pé lateralmente a uma faixa elástica presa na altura da cintura. Segure a extremidade do elástico com a mão mais próxima da fixação. Mantenha o cotovelo flexionado a 90 graus e colado ao tronco. Partindo da posição com a mão afastada do corpo, gire internamente o ombro trazendo a mão em direção ao umbigo. Mantenha o cotovelo fixo no tronco. Retorne de forma controlada.", 
                    MusculosId = 14 
                },
                new { 
                    Id = 28, 
                    NomeExercicio = "Rotação Interna Deitado com Halter", 
                    DescricaoExercicio = "Deite-se lateralmente em um banco com o braço de baixo segurando um halter leve. Flexione o cotovelo a 90 graus e posicione o antebraço apontando para frente. Gire internamente o ombro elevando o halter em direção ao abdômen. O cotovelo permanece apoiado no banco. Desça de forma controlada. Este exercício isola o subescapular. Use peso leve e movimento preciso.", 
                    MusculosId = 14 
                },

                // ========== BÍCEPS BRAQUIAL (MusculosId = 15) ==========
                new { 
                    Id = 29, 
                    NomeExercicio = "Rosca Direta com Barra", 
                    DescricaoExercicio = "Fique em pé segurando uma barra com pegada supinada (palmas para cima), mãos na largura dos ombros. Mantenha os cotovelos fixos ao lado do corpo e os braços estendidos. Flexione os cotovelos levantando a barra em direção aos ombros, contraindo o bíceps. Evite balançar o corpo ou mover os cotovelos para frente. Desça a barra de forma controlada até a extensão completa. Mantenha o core ativado para evitar compensação da lombar.", 
                    MusculosId = 15 
                },
                new { 
                    Id = 30, 
                    NomeExercicio = "Rosca Alternada com Halteres", 
                    DescricaoExercicio = "Fique em pé ou sentado segurando um halter em cada mão ao lado do corpo com as palmas voltadas para dentro. Mantenha os cotovelos fixos ao lado do tronco. Flexione um cotovelo de cada vez, girando o antebraço (supinação) à medida que o halter sobe. No topo, a palma deve estar voltada para o ombro. Contraia o bíceps e desça de forma controlada enquanto inicia o movimento com o outro braço. Alterne os lados de forma contínua.", 
                    MusculosId = 15 
                },

                // ========== TRÍCEPS BRAQUIAL (MusculosId = 16) ==========
                new { 
                    Id = 31, 
                    NomeExercicio = "Tríceps Testa (Skull Crusher)", 
                    DescricaoExercicio = "Deite-se em um banco plano segurando uma barra ou halteres com os braços estendidos acima do peito, pegada pronada. Mantenha os cotovelos fixos apontando para cima e para frente. Flexione apenas os cotovelos, descendo a barra em direção à testa ou parte superior da cabeça de forma controlada. Estenda os cotovelos contraindo o tríceps para retornar à posição inicial. Os ombros permanecem estáticos; apenas os antebraços se movem.", 
                    MusculosId = 16 
                },
                new { 
                    Id = 32, 
                    NomeExercicio = "Tríceps na Polia Alta (Pulley)", 
                    DescricaoExercicio = "Fique em frente a uma polia alta com uma barra reta ou corda anexada. Segure o puxador com pegada pronada, mãos próximas. Mantenha os cotovelos fixos ao lado do corpo e flexionados a aproximadamente 90 graus. Empurre o puxador para baixo estendendo completamente os cotovelos, contraindo o tríceps. Mantenha a contração por 1 segundo e retorne de forma controlada. Os cotovelos não devem se mover; apenas os antebraços realizam o movimento.", 
                    MusculosId = 16 
                },

                // ========== BRAQUIAL (MusculosId = 17) ==========
                new { 
                    Id = 33, 
                    NomeExercicio = "Rosca Martelo com Halteres", 
                    DescricaoExercicio = "Fique em pé ou sentado segurando um halter em cada mão ao lado do corpo com pegada neutra (palmas voltadas uma para a outra). Mantenha os cotovelos fixos ao lado do tronco. Flexione os cotovelos simultaneamente ou alternadamente, levantando os halteres em direção aos ombros sem girar os punhos (mantendo a pegada neutra). Contraia no topo e desça de forma controlada. Esta variação enfatiza o braquial e o braquiorradial.", 
                    MusculosId = 17 
                },
                new { 
                    Id = 34, 
                    NomeExercicio = "Rosca Inversa com Barra", 
                    DescricaoExercicio = "Fique em pé segurando uma barra com pegada pronada (palmas para baixo), mãos na largura dos ombros. Mantenha os cotovelos fixos ao lado do corpo. Flexione os cotovelos levantando a barra em direção aos ombros, mantendo a pegada pronada durante todo o movimento. Contraia o bíceps e o braquial no topo e desça de forma controlada. A pegada pronada aumenta o recrutamento do braquial e do braquiorradial.", 
                    MusculosId = 17 
                },

                // ========== RETO ABDOMINAL (MusculosId = 18) ==========
                new { 
                    Id = 35, 
                    NomeExercicio = "Abdominal Supra (Crunch)", 
                    DescricaoExercicio = "Deite-se de costas com os joelhos flexionados e pés apoiados no chão. Coloque as mãos atrás da cabeça ou cruzadas sobre o peito. Contraia o abdômen e eleve a cabeça e os ombros do chão, enrolando o tronco superior em direção à pelve. O movimento vem da contração abdominal, não da tração do pescoço. Mantenha a contração no topo por 1 segundo e desça de forma controlada. A lombar permanece em contato com o solo.", 
                    MusculosId = 18 
                },
                new { 
                    Id = 36, 
                    NomeExercicio = "Elevação de Pernas Suspensa", 
                    DescricaoExercicio = "Pendure-se em uma barra fixa com os braços estendidos e o corpo totalmente suspenso. Mantenha as pernas juntas e estendidas (ou levemente flexionadas se for iniciante). Contraia o abdômen e eleve as pernas à frente até ficarem paralelas ao solo ou mais alto. Foque em utilizar o abdômen para curvar a pelve e elevar as pernas, não apenas os flexores do quadril. Desça as pernas de forma controlada sem balançar o corpo.", 
                    MusculosId = 18 
                },

                // ========== OBLÍQUO EXTERNO (MusculosId = 19) ==========
                new { 
                    Id = 37, 
                    NomeExercicio = "Abdominal Oblíquo (Crunch Lateral)", 
                    DescricaoExercicio = "Deite-se de costas com os joelhos flexionados. Coloque as mãos atrás da cabeça. Contraia o abdômen e eleve o tronco rotacionando-o para um lado, levando o cotovelo em direção ao joelho oposto. O movimento deve vir da rotação do tronco, contraindo o oblíquo. Retorne ao centro e repita para o outro lado. Alterne os lados ou complete todas as repetições de um lado antes de trocar.", 
                    MusculosId = 19 
                },
                new { 
                    Id = 38, 
                    NomeExercicio = "Prancha Lateral (Side Plank)", 
                    DescricaoExercicio = "Deite-se lateralmente apoiando o corpo no antebraço e na lateral do pé. Eleve o quadril do chão até o corpo formar uma linha reta dos pés à cabeça. Mantenha o core contraído e o corpo alinhado, evitando que o quadril caia. Mantenha a posição isométrica pelo tempo determinado. Esta posição trabalha intensamente o oblíquo do lado que está apoiado no chão. Repita do outro lado.", 
                    MusculosId = 19 
                },

                // ========== OBLÍQUO INTERNO (MusculosId = 20) ==========
                new { 
                    Id = 39, 
                    NomeExercicio = "Bicicleta no Ar", 
                    DescricaoExercicio = "Deite-se de costas com as mãos atrás da cabeça e as pernas elevadas com os joelhos flexionados a 90 graus. Eleve os ombros do chão mantendo o core ativado. Execute um movimento de pedalar, estendendo uma perna enquanto a outra se aproxima do peito. Simultaneamente, gire o tronco levando o cotovelo oposto em direção ao joelho que está vindo. Alterne os lados de forma contínua e controlada, mantendo sempre o abdômen contraído.", 
                    MusculosId = 20 
                },
                new { 
                    Id = 40, 
                    NomeExercicio = "Rotação de Tronco na Polia (Woodchop)", 
                    DescricaoExercicio = "Posicione-se lateralmente a uma polia alta com os pés afastados. Segure a alça ou corda com ambas as mãos. Com os braços estendidos, puxe o cabo diagonalmente através do corpo, rotacionando o tronco desde a posição alta e lateral até a posição baixa e oposta. O movimento deve vir da rotação do tronco, não apenas dos braços. Mantenha o core ativado e retorne de forma controlada. Complete as repetições de um lado antes de trocar.", 
                    MusculosId = 20 
                },

                // ========== TRANSVERSO DO ABDOME (MusculosId = 21) ==========
                new { 
                    Id = 41, 
                    NomeExercicio = "Prancha (Plank)", 
                    DescricaoExercicio = "Deite-se de bruços e apoie-se nos antebraços e dedos dos pés. Mantenha os cotovelos diretamente sob os ombros. Eleve o corpo do chão mantendo uma linha reta dos pés à cabeça. Contraia intensamente o core, puxando o umbigo em direção à coluna. Evite arquear ou elevar excessivamente o quadril. Mantenha a posição isométrica, respirando normalmente. Este exercício é fundamental para a ativação do transverso do abdome.", 
                    MusculosId = 21 
                },
                new { 
                    Id = 42, 
                    NomeExercicio = "Vacuum Abdominal", 
                    DescricaoExercicio = "Posicione-se de quatro apoios ou em pé. Expire todo o ar dos pulmões e, em seguida, puxe o umbigo fortemente em direção à coluna vertebral, como se estivesse tentando encostar o umbigo nas costas. Mantenha esta contração profunda do transverso por 10-30 segundos enquanto respira superficialmente pelo nariz. Relaxe e repita. Este exercício trabalha especificamente o transverso do abdome, o principal estabilizador da coluna.", 
                    MusculosId = 21 
                },

                // ========== GLÚTEO MÁXIMO (MusculosId = 22) ==========
                new { 
                    Id = 43, 
                    NomeExercicio = "Agachamento Profundo", 
                    DescricaoExercicio = "Posicione a barra nas costas ou use halteres. Fique em pé com os pés afastados na largura dos ombros ou um pouco além. Desça empurrando o quadril para trás e flexionando os joelhos até as coxas ficarem abaixo do paralelo ao solo. Quanto maior a profundidade (respeitando sua mobilidade), maior a ativação dos glúteos. Mantenha o peito para cima e os joelhos alinhados com os pés. Empurre o chão com os calcanhares para subir, contraindo os glúteos no topo.", 
                    MusculosId = 22 
                },
                new { 
                    Id = 44, 
                    NomeExercicio = "Hip Thrust (Elevação Pélvica com Carga)", 
                    DescricaoExercicio = "Sente-se no chão com as costas apoiadas em um banco. Posicione uma barra com carga sobre o quadril (use uma almofada para conforto). Apoie os pés no chão afastados na largura dos quadris, com os joelhos flexionados. Empurre os quadris para cima contraindo intensamente os glúteos até o corpo formar uma linha reta dos joelhos aos ombros. Mantenha a contração no topo por 1-2 segundos e desça de forma controlada. Este é um dos melhores exercícios para isolamento do glúteo máximo.", 
                    MusculosId = 22 
                },

                // ========== GLÚTEO MÉDIO (MusculosId = 23) ==========
                new { 
                    Id = 45, 
                    NomeExercicio = "Abdução de Quadril Lateral (Deitado)", 
                    DescricaoExercicio = "Deite-se lateralmente com o corpo alinhado. Mantenha a perna de baixo flexionada para estabilidade e a perna de cima estendida. Eleve a perna de cima lateralmente mantendo-a alinhada com o corpo (não rotacione o quadril ou leve a perna para frente). Contraia o glúteo médio no topo do movimento e desça de forma controlada. Pode-se usar caneleiras ou faixa elástica para resistência. Complete todas as repetições de um lado antes de trocar.", 
                    MusculosId = 23 
                },
                new { 
                    Id = 46, 
                    NomeExercicio = "Caminhada Lateral com Faixa Elástica", 
                    DescricaoExercicio = "Posicione uma faixa elástica ao redor das coxas, acima dos joelhos. Fique em pé com os pés afastados na largura dos quadris e joelhos levemente flexionados (posição de meia agachamento). Mantenha o tronco ereto e o core ativado. Dê passos laterais mantendo tensão constante na faixa, afastando e aproximando os pés sem deixar a tensão diminuir. O movimento deve ser controlado, contraindo o glúteo médio a cada passo. Execute passos em uma direção e depois retorne.", 
                    MusculosId = 23 
                },

                // ========== GLÚTEO MÍNIMO (MusculosId = 24) ==========
                new { 
                    Id = 47, 
                    NomeExercicio = "Abdução de Quadril na Máquina", 
                    DescricaoExercicio = "Sente-se na máquina de abdução de quadril com as costas apoiadas e as coxas posicionadas nos apoios almofadados. Mantenha os pés apoiados. Empurre os apoios lateralmente afastando as pernas o máximo possível, contraindo os glúteos. Mantenha a contração no final do movimento por 1 segundo e retorne de forma controlada. Evite usar impulso ou tirar as costas do encosto.", 
                    MusculosId = 24 
                },
                new { 
                    Id = 48, 
                    NomeExercicio = "Clamshell (Concha)", 
                    DescricaoExercicio = "Deite-se lateralmente com os quadris e joelhos flexionados a aproximadamente 90 graus. Mantenha os pés juntos. Mantenha a pelve estável e abra o joelho de cima (abdução externa) afastando-o do joelho de baixo, como se estivesse abrindo uma concha. Contraia o glúteo médio e mínimo no topo do movimento. Desça de forma controlada mantendo os pés juntos. Pode-se usar faixa elástica ao redor dos joelhos para resistência adicional. Complete todas as repetições antes de trocar de lado.", 
                    MusculosId = 24 
                },

                // ========== FLEXOR RADIAL DO CARPO (MusculosId = 25) ==========
                new { 
                    Id = 49, 
                    NomeExercicio = "Rosca de Punho com Barra (Palmas para Cima)", 
                    DescricaoExercicio = "Sente-se em um banco e apoie os antebraços nas coxas com as palmas das mãos voltadas para cima, segurando uma barra. Deixe os punhos pendurados além dos joelhos. Flexione os punhos levantando a barra o máximo possível contraindo os flexores do antebraço. Mantenha os antebraços totalmente apoiados. Desça a barra de forma controlada até alongar completamente os punhos. Execute o movimento de forma lenta e controlada.", 
                    MusculosId = 25 
                },
                new { 
                    Id = 50, 
                    NomeExercicio = "Rosca de Punho Unilateral com Halter", 
                    DescricaoExercicio = "Sente-se e apoie um antebraço na coxa com a palma voltada para cima, segurando um halter. Deixe o punho pendurado além do joelho. Flexione o punho levantando o halter contraindo os flexores. Mantenha o antebraço imóvel. Desça de forma controlada. Complete todas as repetições de um lado antes de trocar. O trabalho unilateral permite maior foco e amplitude de movimento.", 
                    MusculosId = 25 
                },

                // ========== FLEXOR ULNAR DO CARPO (MusculosId = 26) ==========
                new { 
                    Id = 51, 
                    NomeExercicio = "Desvio Ulnar com Halter", 
                    DescricaoExercicio = "Fique em pé segurando um halter com uma mão em posição vertical (como se segurasse um martelo). Mantenha o antebraço ao lado do corpo ou apoiado em uma superfície. Mova o punho lateralmente em direção ao dedo mínimo (desvio ulnar), contraindo o flexor ulnar do carpo. Retorne à posição neutra de forma controlada. Este é um movimento de pequena amplitude mas muito específico.", 
                    MusculosId = 26 
                },
                new { 
                    Id = 52, 
                    NomeExercicio = "Rosca de Punho Pronada (Ênfase Ulnar)", 
                    DescricaoExercicio = "Sente-se e apoie os antebraços nas coxas com as palmas voltadas para baixo, segurando uma barra. Deixe os punhos pendurados além dos joelhos. Estenda os punhos levantando a barra dorsalmente. Este movimento trabalha os extensores principalmente, mas ao retornar à posição inicial com controle, há trabalho excêntrico e isométrico dos flexores, incluindo o flexor ulnar do carpo.", 
                    MusculosId = 26 
                },

                // ========== FLEXOR SUPERFICIAL DOS DEDOS (MusculosId = 27) ==========
                new { 
                    Id = 53, 
                    NomeExercicio = "Preensão com Bola ou Hand Grip", 
                    DescricaoExercicio = "Segure uma bola de apertar ou hand grip na mão. Aperte o objeto o mais forte possível contraindo todos os músculos flexores dos dedos e do antebraço. Mantenha a contração máxima por 3-5 segundos e depois relaxe completamente. Repita pelo número desejado de repetições. Este exercício trabalha todos os flexores dos dedos, incluindo o flexor superficial.", 
                    MusculosId = 27 
                },
                new { 
                    Id = 54, 
                    NomeExercicio = "Flexão de Dedos com Barra", 
                    DescricaoExercicio = "Segure uma barra com os dedos abertos (não com pegada completa) deixando a barra rolar até a ponta dos dedos. Em seguida, enrole os dedos trazendo a barra de volta à palma da mão, fechando o punho completamente. Este movimento isola a flexão dos dedos e trabalha intensamente o flexor superficial e profundo dos dedos. Execute de forma lenta e controlada.", 
                    MusculosId = 27 
                },

                // ========== FLEXOR PROFUNDO DOS DEDOS (MusculosId = 28) ==========
                new { 
                    Id = 55, 
                    NomeExercicio = "Dead Hang (Suspensão na Barra)", 
                    DescricaoExercicio = "Pendure-se em uma barra fixa com pegada pronada ou supinada. Relaxe o corpo completamente deixando todo o peso pendurado, mas mantendo a pegada firme. Este exercício isométrico trabalha intensamente todos os flexores dos dedos, do punho e do antebraço, especialmente o flexor profundo dos dedos. Mantenha a posição pelo tempo determinado. Aumente progressivamente o tempo de suspensão.", 
                    MusculosId = 28 
                },
                new { 
                    Id = 56, 
                    NomeExercicio = "Farmers Walk (Caminhada do Fazendeiro)", 
                    DescricaoExercicio = "Segure um peso pesado em cada mão (halteres, kettlebells ou barras) ao lado do corpo com pegada firme. Mantenha o tronco ereto, ombros para trás e core ativado. Caminhe para frente mantendo a pegada firme durante todo o percurso. Este exercício trabalha a força de preensão e todos os músculos do antebraço, principalmente os flexores profundos dos dedos que mantêm a pegada firme sob carga.", 
                    MusculosId = 28 
                },

                // ========== EXTENSOR RADIAL LONGO DO CARPO (MusculosId = 29) ==========
                new { 
                    Id = 57, 
                    NomeExercicio = "Extensão de Punho com Barra", 
                    DescricaoExercicio = "Sente-se e apoie os antebraços nas coxas com as palmas voltadas para baixo, segurando uma barra. Deixe os punhos pendurados além dos joelhos. Estenda os punhos levantando a barra dorsalmente (para cima) o máximo possível, contraindo os extensores do antebraço. Mantenha os antebraços totalmente apoiados. Desça a barra de forma controlada. Este exercício trabalha todos os extensores do punho.", 
                    MusculosId = 29 
                },
                new { 
                    Id = 58, 
                    NomeExercicio = "Desvio Radial com Halter", 
                    DescricaoExercicio = "Fique em pé segurando um halter verticalmente (posição de martelo). Mantenha o antebraço estabilizado. Mova o punho lateralmente em direção ao polegar (desvio radial), contraindo o extensor radial longo do carpo. Retorne à posição neutra controladamente. O movimento é pequeno mas específico para os extensores radiais.", 
                    MusculosId = 29 
                },

                // ========== EXTENSOR RADIAL CURTO DO CARPO (MusculosId = 30) ==========
                new { 
                    Id = 59, 
                    NomeExercicio = "Extensão de Punho Unilateral com Halter", 
                    DescricaoExercicio = "Sente-se e apoie um antebraço na coxa com a palma voltada para baixo, segurando um halter. Deixe o punho pendurado além do joelho. Estenda o punho levantando o halter dorsalmente, contraindo os extensores. Mantenha o antebraço imóvel. Desça de forma controlada. O trabalho unilateral permite maior amplitude e foco nos extensores radiais.", 
                    MusculosId = 30 
                },
                new { 
                    Id = 60, 
                    NomeExercicio = "Rosca de Punho Invertida na Polia", 
                    DescricaoExercicio = "Fique em frente a uma polia baixa. Segure uma barra reta com pegada pronada (palmas para baixo). Mantenha os cotovelos próximos ao corpo e os antebraços paralelos ao solo. Estenda os punhos dorsalmente contraindo os extensores do antebraço. Retorne à posição inicial controladamente. A polia mantém tensão constante durante todo o movimento.", 
                    MusculosId = 30 
                },

                // ========== EXTENSOR ULNAR DO CARPO (MusculosId = 31) ==========
                new { 
                    Id = 61, 
                    NomeExercicio = "Extensão de Punho com Pegada Fechada", 
                    DescricaoExercicio = "Sente-se e apoie os antebraços nas coxas com as palmas voltadas para baixo, segurando uma barra com pegada fechada (mãos próximas). Deixe os punhos pendurados além dos joelhos. Estenda os punhos levantando a barra dorsalmente. A pegada fechada enfatiza mais o extensor ulnar do carpo. Desça de forma controlada.", 
                    MusculosId = 31 
                },
                new { 
                    Id = 62, 
                    NomeExercicio = "Extensão de Punho com Desvio Ulnar", 
                    DescricaoExercicio = "Segure um halter em posição vertical. Apoie o antebraço em uma superfície com o punho livre. Estenda o punho dorsalmente e simultaneamente desvie em direção ulnar (lado do dedo mínimo). Este movimento combinado isola o extensor ulnar do carpo. Execute de forma lenta e controlada com peso moderado.", 
                    MusculosId = 31 
                },

                // ========== EXTENSOR DOS DEDOS (MusculosId = 32) ==========
                new { 
                    Id = 63, 
                    NomeExercicio = "Extensão de Dedos com Elástico", 
                    DescricaoExercicio = "Coloque um elástico ao redor dos cinco dedos de uma mão com os dedos unidos. Abra os dedos contra a resistência do elástico, estendendo-os e afastando-os o máximo possível. Mantenha a extensão por 1 segundo e retorne controladamente. Este exercício trabalha especificamente o extensor dos dedos e é excelente para equilíbrio muscular e prevenção de lesões.", 
                    MusculosId = 32 
                },
                new { 
                    Id = 64, 
                    NomeExercicio = "Extensão de Dedos na Mesa", 
                    DescricaoExercicio = "Apoie a mão espalmada sobre uma mesa ou superfície plana. Mantenha a palma em contato com a superfície. Eleve apenas os dedos, estendendo-os o máximo possível enquanto a palma permanece apoiada. Mantenha a extensão por 2-3 segundos e relaxe. Este exercício isométrico trabalha o extensor dos dedos sem necessidade de equipamento.", 
                    MusculosId = 32 
                },

                // ========== PRONADOR REDONDO (MusculosId = 33) ==========
                new { 
                    Id = 65, 
                    NomeExercicio = "Pronação com Halter", 
                    DescricaoExercicio = "Sente-se e apoie o antebraço na coxa ou em um banco. Segure um halter com a mão em posição neutra (polegar para cima). Gire o antebraço internamente (pronação) até a palma ficar voltada para baixo. Contraia o pronador redondo durante o movimento. Retorne à posição neutra de forma controlada. O cotovelo deve permanecer fixo e apenas o antebraço gira.", 
                    MusculosId = 33 
                },
                new { 
                    Id = 66, 
                    NomeExercicio = "Pronação com Bastão (Peso em uma Extremidade)", 
                    DescricaoExercicio = "Segure um bastão ou cabo de vassoura com peso fixado em apenas uma extremidade. Mantenha o antebraço em posição neutra horizontalmente. Gire o antebraço para dentro (pronação) controlando o peso que tenta girar o bastão. Este exercício cria resistência excêntrica e concêntrica para o pronador redondo. Execute de forma muito controlada.", 
                    MusculosId = 33 
                },

                // ========== SUPINADOR (MusculosId = 34) ==========
                new { 
                    Id = 67, 
                    NomeExercicio = "Supinação com Halter", 
                    DescricaoExercicio = "Sente-se e apoie o antebraço na coxa ou em um banco. Segure um halter com a mão em posição pronada (palma para baixo). Gire o antebraço externamente (supinação) até a palma ficar voltada para cima. Contraia o supinador e o bíceps durante o movimento. Retorne à posição pronada de forma controlada. O cotovelo permanece fixo.", 
                    MusculosId = 34 
                },
                new { 
                    Id = 68, 
                    NomeExercicio = "Supinação com Bastão (Peso em uma Extremidade)", 
                    DescricaoExercicio = "Segure um bastão com peso fixado em apenas uma extremidade. Mantenha o antebraço pronado horizontalmente. Gire o antebraço para fora (supinação) controlando o peso. Este exercício trabalha intensamente o supinador e o bíceps. A resistência do peso em desequilíbrio aumenta o desafio. Execute de forma lenta e controlada.", 
                    MusculosId = 34 
                }
            );
        }
    }
}
