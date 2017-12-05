using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class DataImportItem
    {
        public string LineNr { get; set; }
        public string Date { get; set; }
        public string PolicyNumber { get; set; }
        public string Initial { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public string CoverAmount { get; set; }
        public string Birthdate { get; set; }
        public string EnrollmentDate { get; set; }
        public string Relation { get; set; }
        public string Gender { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressCode{ get; set; }
        public string Beneficiary { get; set; }
        public string BeneficiaryIDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age{ get; set; }
        public bool IsHeadersItem { get; set; }
        public bool IsPolicyScheduleDataItem { get; set; }
        public bool IsPolicyScheduleSummaryItem { get; set; }
    }
}
