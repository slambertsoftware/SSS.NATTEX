using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.DAL
{
    public class AvbobPendingQuotationImportDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AvbobPendingQuotationImportDocumentID { get; set; }

        public int AvbobPendingQuotationID { get; set; }

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
        public bool IsActive { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? RemoveDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int CreateUserID { get; set; }

        public int? ModifyUserID { get; set; }

        public int? RemoveUserID { get; set; }

        public virtual AvbobPendingQuotation AvbobPendingQuotation { get; set; }
    }
}
