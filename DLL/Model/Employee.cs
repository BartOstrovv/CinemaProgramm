using System;
using System.Collections.Generic;

namespace DLL.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Salary { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime StartWork { get; set; }

        public int LoginDataID { get; set; }
        public LoginData UserInfo { get; set; }
        public string Role { get; set; }

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
