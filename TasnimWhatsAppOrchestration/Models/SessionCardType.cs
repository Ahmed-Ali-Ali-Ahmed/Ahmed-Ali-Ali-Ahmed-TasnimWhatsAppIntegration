using System;
using System.Collections.Generic;

#nullable disable

namespace TasnimWhatsAppOrchestration.Models
{
    public partial class SessionCardType
    {
        public SessionCardType()
        {
            SessionCardHeaders = new HashSet<SessionCardHeader>();
        }

        public int Id { get; set; }
        public string TypNmNtv { get; set; }
        public string TypNmFrn { get; set; }

        public virtual ICollection<SessionCardHeader> SessionCardHeaders { get; set; }
    }
}
