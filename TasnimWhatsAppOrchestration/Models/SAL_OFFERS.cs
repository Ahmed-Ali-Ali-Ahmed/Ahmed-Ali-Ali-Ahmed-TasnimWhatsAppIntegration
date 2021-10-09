using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasnimWhatsAppOrchestration.Models
{
    [Keyless]
    public class SAL_OFFERS
    {

        public int OFFRS_ID { get; set; }
        public int ORG_STP_ID { get; set; }
        public int OFFRS_NUM { get; set; }
        public string OFFRS_DT { get; set; }
        public string OFFRS_STRT_DT { get; set; }
        public string OFFRS_END_DT { get; set; }
        public int OFFRS_STAT { get; set; }
        public string OFFRS_RMK { get; set; }
        public string OFFRS_CODE { get; set; }
        public string OFFRS_Name { get; set; }
        public Nullable<int> OFFRS_Value { get; set; }
        public Nullable<int> CENTERS_STP_ID { get; set; }
        public Nullable<int> CAT_STP_ID { get; set; }
        public bool OFFRS_IsACTIVE { get; set; }
        public Nullable<int> OFFERS_CNDTN_ID { get; set; }
        public Nullable<bool> OFFRS_UNTLL_FINISH { get; set; }
        public Nullable<int> Definition_Categories_Offers_ID { get; set; }
        public Nullable<bool> Offer_IS_Husommat_IND { get; set; }
        public Nullable<int> H7N_OFFER_ID { get; set; }
        public string H7N_OFFER_NAME { get; set; }
        public Nullable<System.DateTime> LastEditDate { get; set; }

    }
}
