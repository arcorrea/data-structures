namespace DataStructure.Common
{
    public class SingleLinkedEntry<T>
    {
        public T Value { get; set; }
        public SingleLinkedEntry<T>? Next { get; set; }

        public SingleLinkedEntry(T value, SingleLinkedEntry<T>? next)
        {
            Value = value;
            Next = next;
        }
    }
}
