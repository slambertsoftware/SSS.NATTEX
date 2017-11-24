using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class LibertyPendingQuotationMemberGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PendingQuotationMemberGroupID { get; set; }
        public int PendingQuotationMemberSchemeID { get; set; }
        public int PendingQuotationID { get; set; }
        [Required]
        public string GroupSchemeName { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public string GroupCoverAmount { get; set; }

        [Required]
        public bool IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        [Required]
        public int CreateUserID { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public Nullable<int> RemoveUserID { get; set; }
    }
}
