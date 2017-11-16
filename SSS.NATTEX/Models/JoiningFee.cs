﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class JoiningFee
    {
        public int ID { get; set; }
        public decimal Fee { get; set; }
        public int NumMonthInstallments { get; set; }
        public string Description{ get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime RemoveDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int CreateUserID { get; set; }
        public int ModifyUserID { get; set; }
        public int RemoveUserID { get; set; }
    }
}
