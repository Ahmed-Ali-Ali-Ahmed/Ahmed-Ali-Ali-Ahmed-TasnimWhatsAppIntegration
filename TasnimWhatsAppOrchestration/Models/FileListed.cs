using System;
using System.Collections.Generic;

#nullable disable

namespace TasnimWhatsAppOrchestration.Models
{
    public partial class FileListed
    {
        public int Id { get; set; }
        public int? FileCustemerId { get; set; }
        public int? EmpApprovedId { get; set; }
        public bool? IsListed { get; set; }
        public bool? IsApproved { get; set; }
        public string ListReason { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public string Notes { get; set; }
        public int? SubCod { get; set; }
        public int? EmpId { get; set; }
        public DateTime? ApproveDate { get; set; }
        public bool? IsAutoListed { get; set; }
        public int FileListedHistoryId { get; set; }
        public DateTime? ValidatedInDateTime { get; set; }

        public virtual OsSubCod SubCodNavigation { get; set; }
    }
}
