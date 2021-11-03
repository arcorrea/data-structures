using System;

namespace DataStructure.Tests.Utils
{
    public class NullableKey : IComparable<int?>, IComparable
    {
        public int? Value { get; set; }

        public int CompareTo(int? other)
        {
            if (Value.HasValue)
            {
                if (other.HasValue)
                {
                    if (other == Value)
                        return 0;

                    if (Value < other)
                        return -1;

                    return 1;
                }

                return -1;
            }
            else 
            {
                return other.HasValue ? 1 : 0;
            }
        }

        public int CompareTo(object obj)
        {
            return CompareTo((int)obj);
        }
    }
}
