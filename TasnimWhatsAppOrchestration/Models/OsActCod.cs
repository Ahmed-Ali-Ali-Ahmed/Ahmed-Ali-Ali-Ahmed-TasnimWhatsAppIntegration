using System;
using System.Collections.Generic;

#nullable disable

namespace TasnimWhatsAppOrchestration.Models
{
    public partial class OsActCod
    {
        public OsActCod()
        {
            InverseActMn = new HashSet<OsActCod>();
            OsSubCods = new HashSet<OsSubCod>();
        }

        public int ActCodId { get; set; }
        public int? OrgStpId { get; set; }
        public int ActCod { get; set; }
        public string ActNmNtv { get; set; }
        public string ActNmFrn { get; set; }
        public int? ActType { get; set; }
        public int? ActMnId { get; set; }
        public int? CurrStpId { get; set; }
        public int? DmnDtlId { get; set; }
        public decimal? ActOpnCurrDblnc { get; set; }
        public decimal? ActOpnCurrCblnc { get; set; }
        public decimal? ActOpnDblnc { get; set; }
        public decimal? ActOpnCblnc { get; set; }
        public string ActFullCod { get; set; }
        public int? ExpenseCategory { get; set; }
        public DateTime? LastEditDate { get; set; }

        public virtual OsActCod ActMn { get; set; }
        public virtual ICollection<OsActCod> InverseActMn { get; set; }
        public virtual ICollection<OsSubCod> OsSubCods { get; set; }
    }
}
