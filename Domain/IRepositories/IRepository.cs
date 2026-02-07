namespace Domain.IRepositories
{
    public interface IRepository
    {
        public Task<List<T>> GetAllAsync<T>() where T : class;

        public Task<T> GetByIdAsync<T>(int id) where T : class;

        public Task AddAsync<T>(T entity) where T : class;

        public Task UpdateAsync<T>(T entity) where T : class;

        public Task DeleteAsync<T>(int id) where T : class;


    }
}
