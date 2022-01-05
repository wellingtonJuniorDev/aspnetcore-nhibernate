using AspNetCoreNHibernate.Models;
using AspNetCoreNHibernate.Models.ValueObjects;
using AspNetCoreNHibernate.Test.Comparators;
using AspNetCoreNHibernate.Test.Infra;
using Bogus;
using FluentNHibernate.Testing;
using Xunit;

namespace AspNetCoreNHibernate.Test.Mappings
{
    public class ProductTest
    {
        private readonly Faker _faker;

        public ProductTest()
        {
            _faker = new Faker("pt_BR");
        }

        [Fact]
        [Trait("IntegrationTest", nameof(Product))]
        public void VerifyMapping()
        {
            using var session = SessionFactory.Build().OpenSession();
            new PersistenceSpecification<Product>(session, new EntityComparator())
                .CheckProperty(c => c.Name, _faker.Name.JobTitle())
                .CheckProperty(c => c.Quantity, _faker.Random.Number(1, 50000))
                .CheckProperty(c => c.Price, _faker.Random.Double(0.1, 999999.99))
                .CheckProperty(c => c.Audit, new Faker<Audit>().Generate(), new AuditComparator())
                .CheckReference(c => c.Category, GenerateCategory()) // Relationships
                .VerifyTheMappings();
        }

        private Category GenerateCategory()
        {
            return new Faker<Category>("pt_BR")
                .RuleFor(c => c.Id, faker => faker.Random.Long(min: 0))
                .RuleFor(c => c.Name, faker => faker.Name.JobTitle())
                .Generate();
        }
    }
}
