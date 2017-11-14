using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class QuotationDocumentDetail
    {
        QuotationHeaderItem QuotationHeader { get; set; }
        QuotationBodyItem   QuotationBody { get; set; }
        QuotationFooterItem QuotationFooter { get; set; }
    }
}
