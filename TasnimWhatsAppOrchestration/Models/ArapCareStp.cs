using System;
using System.Collections.Generic;

#nullable disable

namespace TasnimWhatsAppOrchestration.Models
{
    public partial class ArapCareStp
    {
        public int CareStpId { get; set; }
        public int? OrgId { get; set; }
        public int? CatStpId { get; set; }
        public int? CareStpCod { get; set; }
        public string CareStpNmNtv { get; set; }
        public string CareStpNmFrn { get; set; }
        public string CareStpTrdNmNtv { get; set; }
        public string CareStpTrdNmFrn { get; set; }
        public int? DmtDtlCod { get; set; }
        public bool? CareStpStat { get; set; }
        public int? CurrStpId { get; set; }
        public string CareStpStrtDt { get; set; }
        public string CareStpLstTrxDt { get; set; }
        public string CareStpHltDt { get; set; }
        public decimal? CareStpCurrDamt { get; set; }
        public decimal? CareStpCurrCamt { get; set; }
        public decimal? CareStpDamt { get; set; }
        public decimal? CareStpCamt { get; set; }
        public int? RgnHdrId { get; set; }
        public int? CareStpPaymentTerm { get; set; }
        public decimal? CareStpCrLmt { get; set; }
        public int? CareStpCrDue { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string TaxNum { get; set; }
        public int? ApprovalStat { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string ApprovalBy { get; set; }
        public DateTime? CheckerDate { get; set; }
        public string CheckerBy { get; set; }
        public string ReSendRessionRmk { get; set; }
        public string CareStpRmk { get; set; }
        public string CareStpRmkDate { get; set; }
        public bool? CareStpStatementInd { get; set; }
        public decimal? CareStpStatementPer { get; set; }
        public decimal? ProfitMarginPer { get; set; }
        public DateTime? LastEditDate { get; set; }
    }
}
