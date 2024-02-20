namespace Persistence.EFCore.Repositories
{
    public class GenericUnitOfWork<TRepo, TEntity> : IDisposable
    where TRepo : GenericRepository<TEntity>
    where TEntity : class
    {
     
        public Dictionary<Type, TRepo> repositories = new Dictionary<Type, TRepo>();
        public void Dispose()
        {
        }
        public TRepo Repository()
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)];
            }
            TRepo repo = (TRepo)Activator.CreateInstance(
                typeof(TRepo),
                new object[] { });
            repositories.Add(typeof(TEntity), repo);
            return repo;
        }

    }
}
