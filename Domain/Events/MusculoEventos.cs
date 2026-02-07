namespace Domain.Events
{
    public class MusculoEventos
    {
        public string CriarMusculo(int id, string musculo)
        {
            return $"Musculo {musculo} criado com sucesso com o id {id}";

        }

        public string AtualizarMusculo(int id, string musculo)
        {
            return $"Musculo {musculo} atualizado com sucesso com o id {id}";
        }

        public string DeletarMusculo(int id, string musculo)
        {
            return $"Musculo {musculo} deletado com sucesso com o id {id}";
        }
    }
}
