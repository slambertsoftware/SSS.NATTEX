using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class LoginMessage
    {
        public string Message { get; set; }
        public string LoginStatus { get; set; }
        public string UserName { get; set; }
        public string UserRole{ get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
}
