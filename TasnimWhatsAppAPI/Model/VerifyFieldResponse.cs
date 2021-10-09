using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasnimWhatsAppAPI.Model
{
    public class VerifyFieldResponse
    {

        public VerifyFieldResponse()
        {


        }


        public int ActionId { get; set; }

        public string MessageText { get; set; }

        public string OtherFieldId { get; set; }
    }
}
