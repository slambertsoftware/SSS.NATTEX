using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class PolicyPremium
    {
        [Required]
        public int PolicyPremiumID { get; set; }
        public int PricingModelID { get; set; }
        [Required]
        public int SchemeID { get; set; }
        [Required]
        public decimal CoverAmount { get; set; }
        [Required]
        public int  StartAge { get; set; }
        [Required]
        public int  EndAge { get; set; }
        [Required]
        public decimal PremiumAmount { get; set; }

        public bool IsActive { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreateDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        [Required]
        public int CreateUserID { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public Nullable<int> RemoveUserID { get; set; }

        public virtual PricingModel PricingModel { get; set; }
        public virtual PolicyScheme PolicyScheme { get; set; }
    }
}
