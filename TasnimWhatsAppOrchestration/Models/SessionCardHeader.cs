using System;
using System.Collections.Generic;

#nullable disable

namespace TasnimWhatsAppOrchestration.Models
{
    public partial class SessionCardHeader
    {
        public int Id { get; set; }
        public int? OrgStpId { get; set; }
        public int? MatCatId { get; set; }
        public int? MatStpId { get; set; }
        public int? DmnDtlId { get; set; }
        public int? SchDuration { get; set; }
        public bool? IsFreeConsultancy { get; set; }
        public int? SessionCardTypeId { get; set; }
        public int? SpecialistAvgWorkMinutes { get; set; }
        public int? HelperAvgWorkMinutes { get; set; }
        public int? DaysExpiration { get; set; }
        public int? DaysExpirationEachTime { get; set; }
        public bool? AllowDiscount { get; set; }
        public bool? Multiple { get; set; }
        public bool? NoMaterialsUsed { get; set; }
        public bool? NoAssetsUsed { get; set; }
        public DateTime? LastEditDate { get; set; }

        public virtual SessionCardType SessionCardType { get; set; }
    }
}
