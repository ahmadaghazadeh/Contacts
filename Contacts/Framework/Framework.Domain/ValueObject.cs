namespace Framework.Domain
{
    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, right) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;


            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents(), new ListOfPropertyComparer());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public static bool operator ==(ValueObject one, ValueObject two)
        {
            return EqualOperator(one, two);
        }

        public static bool operator !=(ValueObject one, ValueObject two)
        {
            return NotEqualOperator(one, two);
        }
    }

    public class ListOfPropertyComparer : IEqualityComparer<object>
    {

        public bool Equals(object x, object y)
        {
            if ((x == null && y == null) || x.Equals(y))

                if (x is IEnumerable<object>)
            {
                return ((IEnumerable<object>)x).SequenceEqual((IEnumerable<object>)y, new ListOfPropertyComparer());
            }
            if ((x == null&&y==null) || x.Equals(y))
                return true;
            else
                return false;
        }
        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }
    }
}
