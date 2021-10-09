using System;
using System.Collections.Generic;

#nullable disable

namespace TasnimWhatsAppOrchestration.Models
{
    public partial class FileCustomerMobile
    {
        public int Id { get; set; }
        public int FileCustomerId { get; set; }
        public int Mobile { get; set; }
        public int MobileKey { get; set; }
        public DateTime InsertedDateTime { get; set; }
        public Guid InsertedUserId { get; set; }
        public bool Active { get; set; }
    }
}
