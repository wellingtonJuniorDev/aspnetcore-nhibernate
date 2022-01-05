
using AspNetCoreNHibernate.Models;
using System.Collections;

namespace AspNetCoreNHibernate.Test.Comparators
{
    public class EntityComparator : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            var compare = x as BaseEntity;
            var compareTo = y as BaseEntity;

            if (ReferenceEquals(compare, compareTo)) return true;
            if (compareTo is null) return false;

            return compare.Id.Equals(compareTo.Id);
        }

        public int GetHashCode(object obj)
        {
            return (GetType().GetHashCode() * 907) + (obj as BaseEntity).Id.GetHashCode();
        }
    }
}
