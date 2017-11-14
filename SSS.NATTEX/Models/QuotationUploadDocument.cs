using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.NATTEX.Models
{
    public class QuotationUploadDocument
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string CopyToFilePath { get; set; }
        public string FileDescription { get; set; }
        public string FileExtension { get; set; }
        public bool   IsFileSelected { get; set; }
    }
}
