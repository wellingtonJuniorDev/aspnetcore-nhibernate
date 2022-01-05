using AspNetCoreNHibernate.Models.ValueObjects;
using System;
using System.Collections;

namespace AspNetCoreNHibernate.Test.Comparators
{
    public class AuditComparator : IEqualityComparer
    {
        public bool Equals(object x, object y)
        {
            if (x is Audit && y is Audit)
            {
                if (x is null && y is null) return true;

                if (y is null || x is null) return false;

                return (x as Audit).Inserted.ToString().Equals((y as Audit).Inserted.ToString()) &&
                    (x as Audit).Updated.ToString().Equals((y as Audit).Updated.ToString());
            }
            else return x.Equals(y);
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
