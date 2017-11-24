using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class LibertyPendingQuotationDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibertyPendingQuotationDocumentID { get; set; }
        public int LibertyPendingQuotationID { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FilePath { get; set; }
        [Required]
        public string CopyToFilePath { get; set; }
        [Required]
        public string FileDescription { get; set; }
        [Required]
        public string FileExtension { get; set; }
        [Required]
        public bool   IsFileSelected { get; set; }

        [Required]
        public bool IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        [Required]
        public int CreateUserID { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public Nullable<int> RemoveUserID { get; set; }
        public virtual LibertyPendingQuotation PendingQuotation { get; set; }
    }
}
