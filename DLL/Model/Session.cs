using System;
using System.Collections.Generic;

namespace DLL.Model
{
    public class Session
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public Film Film { get; set; }
        public Hall Hall { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
