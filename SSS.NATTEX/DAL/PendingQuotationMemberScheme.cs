using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class PendingQuotationMemberScheme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PendingQuotationMemberSchemeID { get; set; }
        public int PendingQuotationID { get; set; }
        public string SchemeName { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int CreateUserID { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public Nullable<int> RemoveUserID { get; set; }
        public virtual PendingQuotation PendingQuotation { get; set; }
    }
}
