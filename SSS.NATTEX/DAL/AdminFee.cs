using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class AdminFee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminFeeID { get; set; }
        [Required, Display(Name = "Admin Fee")]
        public decimal Fee { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        [Required]
        public int CreateUserID { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public Nullable<int> RemoveUserID { get; set; }
        public DateTime? RemoveDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
