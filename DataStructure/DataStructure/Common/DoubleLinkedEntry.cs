namespace DataStructure.Common
{
    public class DoubleLinkedEntry<T>
    {
        public T Value { get; set; }
        public DoubleLinkedEntry<T>? Next { get; set; }
        public DoubleLinkedEntry<T>? Previous { get; set; }

        public DoubleLinkedEntry(T value)
        {
            Value = value;
        }
    }
}
