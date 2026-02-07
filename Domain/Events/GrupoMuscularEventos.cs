namespace Domain.Events
{
    public class GrupoMuscularEventos
    {
        public string CriarGrupoMuscular(int id, string grupoMuscular)
        {
            return $"Grupo Muscular {grupoMuscular} criado com sucesso com o id {id}";
        }
        public string AtualizarGrupoMuscular(int id, string grupoMuscular)
        {
            return $"Grupo Muscular {grupoMuscular} atualizado com sucesso com o id {id}";
        }
        public string DeletarGrupoMuscular(int id, string grupoMuscular)
        {
            return $"Grupo Muscular {grupoMuscular} deletado com sucesso com o id {id}";
        }
    }
}
