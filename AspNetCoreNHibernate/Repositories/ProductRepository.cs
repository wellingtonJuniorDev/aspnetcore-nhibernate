using AspNetCoreNHibernate.Models;
using AspNetCoreNHibernate.Repositories.Interfaces;
using NHibernate;

namespace AspNetCoreNHibernate.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ISession session) : base(session) { }
    }
}