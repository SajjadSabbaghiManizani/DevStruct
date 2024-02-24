using Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using static Persistence.EFCore.Repositories.GenericUnitOfWork;

namespace Persistence.EFCore.Repositories
{
    public class GenericUnitOfWork : IGenericUnitOfWork
    {
        private readonly DbContext _context;

        public GenericUnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context);
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
