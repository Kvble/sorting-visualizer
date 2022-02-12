
namespace SortingVisualizer.Models
{
    class Height
    {
        public Height() { }
        public Height(int id, int value)
        {
            this.Id = id;
            this.Value = value;
        }
        public int Id { get; set; }
        public int Value { get; set; }
    }
}
