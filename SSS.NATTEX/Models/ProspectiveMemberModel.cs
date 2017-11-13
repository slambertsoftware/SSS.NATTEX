using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class ProspectiveMember
    {
        public string Initial { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public int Age { get; set; }
        public decimal Premium { get; set; }
        public string Scheme { get; set; }
        public bool IsMemberSelected { get; set; } 
        public override string ToString() { return IDNumber; }
    }
}
