using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class LibertyPendingQuotationMemberGroupMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibertyPendingQuotationMemberGroupMemberID { get; set; }
        public int LibertyPendingQuotationMemberGroupID { get; set; }
        public int LibertyPendingQuotationID { get; set; }

        public string Initial { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string IDNumber { get; set; }
        [Required]
        public int Age { get; set; }
        public decimal Premium { get; set; }
        public string Scheme { get; set; }
        public string CoverAmount { get; set; }
        public bool IsMemberSelected { get; set; }

        [Required]
        public bool IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        [Required]
        public int CreateUserID { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public Nullable<int> RemoveUserID { get; set; }
        public virtual LibertyPendingQuotationMemberGroup PendingQuotationMemberGroup { get; set; }
    }
}
