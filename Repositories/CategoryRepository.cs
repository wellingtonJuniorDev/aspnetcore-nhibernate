using AspNetCoreNHibernate.Models;
using AspNetCoreNHibernate.Repositories.Interfaces;
using NHibernate;

namespace AspNetCoreNHibernate.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ISession session) : base(session)
        {
        }
    }
}
