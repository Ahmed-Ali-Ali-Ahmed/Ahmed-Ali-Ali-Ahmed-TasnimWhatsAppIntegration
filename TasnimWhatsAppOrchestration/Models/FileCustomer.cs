using System;
using System.Collections.Generic;

#nullable disable

namespace TasnimWhatsAppOrchestration.Models
{
    public partial class FileCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Telephone { get; set; }
        public int? Mobile { get; set; }
        public string Job { get; set; }
        public DateTime? DateofBirth { get; set; }
        public int? Gender { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Nationality { get; set; }
        public int? OfficialId { get; set; }
        public string OfficialNumber { get; set; }
        public DateTime? OfficialEndDate { get; set; }
        public int? Address { get; set; }
        public string Email { get; set; }
        public byte[] PersonalImage { get; set; }
        public string CardId { get; set; }
        public int? CareStpId { get; set; }
        public int? OrgId { get; set; }
        public int? IdentifyWayId { get; set; }
        public bool? IsMerge { get; set; }
        public int? NewId { get; set; }
        public bool? Directly { get; set; }
        public bool? Completed { get; set; }
        public int? MarketingPlaceId { get; set; }
        public int? MobileKey { get; set; }
        public bool? SmsTrue { get; set; }
        public Guid? InsertedUserId { get; set; }
        public int? MobileVerificationId { get; set; }
        public bool? SmsBulkExclude { get; set; }
        public bool? CallBulkExclude { get; set; }
        public bool? OpenViaApp { get; set; }
        public bool? File7usoomat { get; set; }
        public bool? OpenViaWhatsApp { get; set; }
    }
}
