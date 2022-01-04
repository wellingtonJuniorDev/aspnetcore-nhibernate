using AspNetCoreNHibernate.Models;
using AspNetCoreNHibernate.Repositories.Interfaces;
using NHibernate;

namespace AspNetCoreNHibernate.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ISession session) : base(session)
        {
        }
    }
}
