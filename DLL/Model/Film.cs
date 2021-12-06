using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Model
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; } 
        public double Duration { get; set; }
        public double Price { get; set; }

        public List<Session> Sessions { get; set; } = new List<Session>();
    }
}
