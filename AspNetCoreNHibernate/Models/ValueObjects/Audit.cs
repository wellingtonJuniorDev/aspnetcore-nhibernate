using System;

namespace AspNetCoreNHibernate.Models.ValueObjects
{
    public class Audit
    {
        public Audit()
        {
            Inserted = DateTime.Now;
        }

        public DateTime Inserted { get; set; }
        public DateTime? Updated { get; set; }
    }
}
