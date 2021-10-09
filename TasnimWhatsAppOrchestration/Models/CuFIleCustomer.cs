using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasnimWhatsAppOrchestration.Models
{
    public partial class FileCustomer
    {

        public FileCustomer()
        {
            
        }
        public virtual ICollection<FileCustomerMobile> FileCustomerMobiles { get; set; }
    }
}
