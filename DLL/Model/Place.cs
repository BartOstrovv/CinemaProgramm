using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Model
{
    public class Place
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public double Price { get; set; }
        public int Number { get; set; }
        public Hall Hall { get; set; }
        public Ticket Ticket { get; set; }
    }
}
