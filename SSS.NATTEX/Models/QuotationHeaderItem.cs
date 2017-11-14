using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class QuotationHeaderItem
    {
        public Customer QuotationCustomer { get; set; }
        public string QuotationHeading { get; set; }
        public string QuotationNumber { get; set; }
        public string QuotationCreateDate { get; set; }
        public string QuotationExpiryDate { get; set; }
        public string QuotationPreparedBy { get; set; }
        public string QuotationValidDays { get; set; }
    }
}
