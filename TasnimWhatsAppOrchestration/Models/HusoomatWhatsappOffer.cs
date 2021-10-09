using System;
using System.Collections.Generic;

#nullable disable

namespace TasnimWhatsAppOrchestration.Models
{
    public partial class HusoomatWhatsappOffer
    {
        public string OfferName { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime InsertDateTime { get; set; }
        public Guid InsertUserId { get; set; }
        public bool WhatsappDisplay { get; set; }
        public int CityId { get; set; }
        public int Id { get; set; }
    }
}
