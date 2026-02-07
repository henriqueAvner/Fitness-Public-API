namespace Domain.Events
{
    public class ExercicioEventos
    {
        public string CriarExercicio(int id, string nomeExercicio)
        {
            return $"Exercicio {nomeExercicio} criado com sucesso com o id {id}";
        }
        public string AtualizarExercicio(int id, string nomeExercicio)
        {
            return $"Exercicio {nomeExercicio} atualizado com sucesso com o id {id}";
        }
        public string DeletarExercicio(int id, string nomeExercicio)
        {
            return $"Exercicio {nomeExercicio} deletado com sucesso com o id {id}";
        }
    }
}
