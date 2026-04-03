namespace SortingVisualizer.Models
{
    internal class SortElement
    {
        public SortElement(int id, int value)
        {
            this.Id = id;
            this.Value = value;
        }
        public int Id { get; set; }
        public int Value { get; set; }
    }
}
