using System;
using System.Collections.Generic;

#nullable disable

namespace TasnimWhatsAppOrchestration.Models
{
    public partial class FileListedHistory
    {
        public FileListedHistory()
        {
            FileListeds = new HashSet<FileListed>();
        }

        public int Id { get; set; }
        public int FileCustomerId { get; set; }
        public bool BlackList { get; set; }
        public int SubCodId { get; set; }
        public bool Approved { get; set; }
        public DateTime InDateTime { get; set; }
        public DateTime? ManualDateFrom { get; set; }
        public DateTime? ManualDateTo { get; set; }
        public int? EmpId { get; set; }
        public int? ApprovedEmpId { get; set; }
        public DateTime? ApprovedDateTime { get; set; }
        public string ListReason { get; set; }
        public string Notes { get; set; }
        public int? FileListedReasonId { get; set; }
        public bool AutoListed { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<FileListed> FileListeds { get; set; }
    }
}
