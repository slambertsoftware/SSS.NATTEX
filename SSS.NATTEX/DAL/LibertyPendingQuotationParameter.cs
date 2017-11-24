using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class LibertyPendingQuotationParameter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibertyPendingQuotationParameterID { get; set; }
        [Required]
        public int QuotationValidDays { get; set; }
        [Required]
        public int NumMonthlyJoiningFeeInstallments { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int CreateUserID { get; set; }
        public DateTime? CreateDate { get; set; }
        public Nullable<int> RemoveUserID { get; set; }
        public DateTime? RemoveDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
    }
}
