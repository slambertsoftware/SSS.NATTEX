﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class AvbobPendingQuotationPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AvbobPendingQuotationPlanID { get; set; }
        public int AvbobPendingQuotationAgeGroupID { get; set; }
        [Required]
        public string PlanName { get; set; }
        public string PlanDescription { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int CreateUserID { get; set; }
        public DateTime? CreateDate { get; set; }
        public Nullable<int> RemoveUserID { get; set; }
        public DateTime? RemoveDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public virtual AvbobPendingQuotationAgeGroup AvbobPendingQuotationAgeGroup { get; set; }
    }
}
