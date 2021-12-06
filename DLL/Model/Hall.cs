using System;
using System.Collections.Generic;
namespace DLL.Model
{
    public class Hall
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int MaxSeats { get; set; }
        public List<Place> Places { get; set; } = new List<Place>();
    }
}
