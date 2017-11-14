using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class NewQuotation
    {
        public string QuotationNumber { get; set; }
        public string QuotationType { get; set; }
        public bool   IsExistingCustomer { get; set; }
        public string SelectedCustomer { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerContactNumber { get; set; }
        public string CustomerEmailAddress { get; set; }
        public string CustomerOtherInfo { get; set; }
        public string PricingModel { get; set; }
        public string QuotationPreparedBy { get; set; }
        public List<QuotationUploadDocument> QuotationDocuments { get; set; }
    }
}
