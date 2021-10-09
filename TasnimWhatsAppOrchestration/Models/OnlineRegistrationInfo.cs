using System;
using System.Collections.Generic;

#nullable disable

namespace TasnimWhatsAppOrchestration.Models
{
    public partial class OnlineRegistrationInfo
    {
        public int Id { get; set; }
        public int OnlineRegistrationSourceId { get; set; }
        public int FileCustomerId { get; set; }
        public bool FileCustomerNew { get; set; }
        public string FullName { get; set; }
        public int MobileKey { get; set; }
        public int MobileNumber { get; set; }
        public int GenderId { get; set; }
        public int CityStpId { get; set; }
        public int MatStpId { get; set; }
        public string Notes { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int? CsaId { get; set; }
        public DateTime? CancelDateTime { get; set; }
        public Guid? CancelUserId { get; set; }

        public virtual OnlineRegistrationSource OnlineRegistrationSource { get; set; }
    }
}
