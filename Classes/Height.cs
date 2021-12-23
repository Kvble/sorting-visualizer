using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.Classes
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
