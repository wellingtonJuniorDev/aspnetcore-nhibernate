using AspNetCoreNHibernate.Models;
using AspNetCoreNHibernate.Test.Infra;
using Bogus;
using FluentNHibernate.Testing;
using Xunit;

namespace AspNetCoreNHibernate.Test.Mappings
{
    public class CategoryTest
    {
        private readonly Faker _faker;

        public CategoryTest()
        {
            _faker = new Faker("pt_BR");
        }

        [Fact]
        [Trait("IntegrationTest", nameof(Category))]
        public void VerifyMapping()
        {
            using var session = SessionFactory.Build().OpenSession();
            new PersistenceSpecification<Category>(session)
                .CheckProperty(c => c.Name, _faker.Name.JobArea())
                .VerifyTheMappings();
        }
    }
}
