using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasnimWhatsAppOrchestration.Helper
{
   public class TansimWhatsAppException : Exception
    {

        public TansimWhatsAppException()
        
        {

        }


        public TansimWhatsAppException(string Message)
            :base(Message)
        {
           

        }

        public TansimWhatsAppException(string message, Exception innerExcption )
            :base(message,innerExcption)
        {

        }
    }
}
