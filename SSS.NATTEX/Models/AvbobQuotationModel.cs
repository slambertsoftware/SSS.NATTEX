using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Xps.Packaging;

namespace SSS.NATTEX.Models
{
    public class AvbobQuotationModel
    {
        public int QuotationID { get; set; }
        public XpsDocument QuotationXPSDocument { get; set; }
    }
}
