using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public int SessionID { get; set; }
        public Session Session { get; set; }
        public int PlaceID { get; set; }
        public Place Place { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }

        public Employee Employee { get; set; }
    }
}
