using AspNetCoreNHibernate.Models.ValueObjects;
using System;

namespace AspNetCoreNHibernate.Models
{
    public class Product
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Quantity { get; set; }
        public virtual double Price { get; set; }

        public virtual Audit Audit { get; set; }

        public virtual void AuditInsertion()
        {
            Audit = new Audit();
        }

        public virtual void AuditUpdate()
        {
            Audit.Updated = DateTime.Now;
        }
    }
}