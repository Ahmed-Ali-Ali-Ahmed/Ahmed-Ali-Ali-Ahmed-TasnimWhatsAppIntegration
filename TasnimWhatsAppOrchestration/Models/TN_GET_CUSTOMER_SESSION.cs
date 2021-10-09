using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasnimWhatsAppOrchestration.Models
{
   public class TN_GET_CUSTOMER_SESSION
    {
        [Key]
        public int FileCustomerId { get; set; }
        public DateTime EXPIRE_END_DATE { get; set; }
        public string MAT_STP_NM_NTV { get; set; }
      
    }
}
