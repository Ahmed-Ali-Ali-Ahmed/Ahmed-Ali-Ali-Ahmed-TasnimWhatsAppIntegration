using System;
using System.Collections.Generic;

#nullable disable

namespace TasnimWhatsAppOrchestration.Models
{
    public partial class OnlineRegistrationSource
    {
        public OnlineRegistrationSource()
        {
            OnlineRegistrationInfos = new HashSet<OnlineRegistrationInfo>();
        }

        public int Id { get; set; }
        public string SourceCode { get; set; }
        public string SourceName { get; set; }

        public virtual ICollection<OnlineRegistrationInfo> OnlineRegistrationInfos { get; set; }
    }
}
