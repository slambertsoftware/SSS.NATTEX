using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class AvbobPendingQuotationMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AvbobPendingQuotationMemberID { get; set; }

        public int AvbobPendingQuotationID { get; set; }

        public string PolicyNumber { get; set; }

        public string Initial { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string IDNumber { get; set; }

        public int Age { get; set; }

        [DataType("Date")]
        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Relation { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressCode { get; set; }

        public string EnrollmentDate { get; set; }

        public string Beneficiary { get; set; }

        public string BeneficiaryIDNumber { get; set; }

        public string CoverAmount { get; set; }

        public bool IsMemberSelected { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? RemoveDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int CreateUserID { get; set; }

        public int? ModifyUserID { get; set; }

        public int? RemoveUserID { get; set; }

        public virtual AvbobPendingQuotation AvbobPendingQuotation { get; set; }
    }
}
