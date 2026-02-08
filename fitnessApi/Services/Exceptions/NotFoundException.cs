namespace fitnessApi.Services.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string entity, int id) 
            : base($"{entity} com ID {id} não encontrado.")
        {
        }
    }
}
