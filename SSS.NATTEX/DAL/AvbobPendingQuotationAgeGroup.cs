using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class AvbobPendingQuotationAgeGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AvbobPendingQuotationAgeGroupID { get; set; }
        [Required]
        public int StartAge { get; set; }
        [Required]
        public int EndAge { get; set; }
        [Required]
        public string AgeGroup { get; set; }
        public string Description { get; set; }
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
