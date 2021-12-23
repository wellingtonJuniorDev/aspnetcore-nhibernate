using AspNetCoreNHibernate.Repositories.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreNHibernate.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
    {
        protected readonly ISession _session;

        public BaseRepository(ISession session)
        {
            _session = session;
        }

        protected async Task ExecuteTransactionAsync(Func<Task> sessionTask)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await sessionTask();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await transaction?.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public async Task AddAsync(TEntity item)
        {
            await ExecuteTransactionAsync(async () => await _session.SaveAsync(item));
        }

        public IEnumerable<TEntity> FindAll()
        {
            return _session.Query<TEntity>().ToList();
        }

        public Task<TEntity> FindByIdAsync(long id)
        {
            return _session.GetAsync<TEntity>(id);
        }

        public async Task RemoveAsync(long id)
        {
            await ExecuteTransactionAsync(async () =>
            {
                var item = await _session.GetAsync<TEntity>(id);
                await _session.DeleteAsync(item);
            });
        }

        public async Task UpdateAsync(TEntity item)
        {
            await ExecuteTransactionAsync(async () => await _session.UpdateAsync(item));
        }
    }
}
