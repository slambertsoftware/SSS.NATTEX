using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class ProspectiveMember : IEquatable<ProspectiveMember>
    {
        public int ID { get; set; }
        public string Initial { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public int Age { get; set; }
        public decimal Premium { get; set; }
        public string Scheme { get; set; }
        public string CoverAmount { get; set; }
        public bool IsMemberSelected { get; set; }
        public override string ToString() { return IDNumber; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ProspectiveMember objAsPart = obj as ProspectiveMember;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public override int GetHashCode()
        {
            return ID;
        }

        public bool Equals(ProspectiveMember other)
        {
            if (other == null) return false;
            return (this.IDNumber.Equals(other.IDNumber));
        }
    }
}
