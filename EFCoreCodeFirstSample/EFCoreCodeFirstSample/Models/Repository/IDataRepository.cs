namespace EFCoreCodeFirstSample.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        Task<List<TEntity>> Get(long id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(long id);
    }
}
