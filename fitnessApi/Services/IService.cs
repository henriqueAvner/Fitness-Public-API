namespace fitnessApi.Services
{
    public interface IService<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity, int id);
        void Delete(int id);
    }
}
