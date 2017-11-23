using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class PendingQuotationDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PendingQuotationDocumentID { get; set; }
        public int PendingQuotationID { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string CopyToFilePath { get; set; }
        public string FileDescription { get; set; }
        public string FileExtension { get; set; }
        public bool IsFileSelected { get; set; }

        [Required]
        public bool IsActive { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreateDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        [Required]
        public int CreateUserID { get; set; }
        public Nullable<int> ModifyUserID { get; set; }
        public Nullable<int> RemoveUserID { get; set; }
        public virtual PendingQuotation PendingQuotation { get; set; }
    }
}
