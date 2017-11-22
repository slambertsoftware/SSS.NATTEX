using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class MonthlyInstallmmentPeriod
    {
        public int ID { get; set; }
        public int YearPeriod { get; set; }
        public int MonthPeriod { get; set; }
        public int DayPeriod { get; set; }
        public string ItemName{ get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime RemoveDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int CreateUserID { get; set; }
        public int ModifyUserID { get; set; }
        public int RemoveUserID { get; set; }
    }
}
