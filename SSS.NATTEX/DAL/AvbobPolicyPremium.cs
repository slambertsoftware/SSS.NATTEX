using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class AvbobPolicyPremium
    {
        [Required]
        public int AvbobPolicyPremiumID { get; set; }
        public int AvbobAgeGroupID { get; set; }
        public int AvbobPlanID { get; set; }
        [Required]
        public decimal MemberCover { get; set; }
        [Required]
        public decimal SpouseCover { get; set; }
        [Required]
        public decimal Child14To21YearsCover { get; set; }
        [Required]
        public decimal Child6To13YearsCover { get; set; }
        [Required]
        public decimal Child1To5YearsCover { get; set; }
        [Required]
        public decimal ChildStillBornTo11MonthsCover { get; set; }

        [Required]
        public decimal ExtendedChildUpTo18YearsCover { get; set; }
        [Required]
        public int StartAge { get; set; }
        [Required]
        public int EndAge { get; set; }

        [Required]
        public decimal MonthlyMemberPremium { get; set; }

        [Required]
        public decimal MonthlyExtendedChildRiskPremium { get; set; }

        [Required]
        public decimal MonthlyMemberCommissionPercentage { get; set; }
        [Required]
        public decimal MonthlyMemberCommission { get; set; }

        [Required]
        public decimal TotalMonthlyMemberPremium { get; set; }

        [Required]
        public decimal CompanyMemberPremium { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int CreateUserID { get; set; }
        public DateTime? CreateDate { get; set; }
        public Nullable<int> RemoveUserID { get; set; }
        public DateTime? RemoveDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public Nullable<int> ModifyUserID { get; set; }

        public virtual AvbobAgeGroup AgeGroup { get; set; }
        public virtual AvbobPlan Plan { get; set; }
    }
}
