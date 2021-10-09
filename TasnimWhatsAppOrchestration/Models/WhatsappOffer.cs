using System;
using System.Collections.Generic;

#nullable disable

namespace TasnimWhatsAppOrchestration.Models
{
    public partial class WhatsappOffer
    {
        public int Id { get; set; }
        public string OfferName { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime InsertedDateTime { get; set; }
        public Guid InsertedUserId { get; set; }
        public bool WhatsappDisplay { get; set; }
    }
}
