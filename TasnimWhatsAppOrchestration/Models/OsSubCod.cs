using System;
using System.Collections.Generic;

#nullable disable

namespace TasnimWhatsAppOrchestration.Models
{
    public partial class OsSubCod
    {
        public OsSubCod()
        {
            FileListeds = new HashSet<FileListed>();
        }

        public int SubCodId { get; set; }
        public int? OrgStpId { get; set; }
        public int? MstrId { get; set; }
        public int SubCod { get; set; }
        public string SubNmNtv { get; set; }
        public string SubNmFrn { get; set; }
        public int? ActCodId { get; set; }

        public virtual ICollection<FileListed> FileListeds { get; set; }
    }
}
