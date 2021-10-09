using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasnimWhatsAppOrchestration.Models;

namespace TasnimWhatsAppOrchestration.WorkingWithData.Husoomat
{
    public class GetAndSetDataForHusoomat :GetAndSetData,  IGetAndSetDataForHusoomat
    {
        public GetAndSetDataForHusoomat(TasnimContext _db, IConfiguration config) : base(_db, config)
        {
        }

        public List<SP_Husoomat_Whatsapp_Offer_Cityies> GetAllCities()
        {
            List<SP_Husoomat_Whatsapp_Offer_Cityies> cityies = _db.SP_Husoomat_Whatsapp_Offer_Cityies.FromSqlRaw("SP_Husoomat_Whatsapp_Offer_Cityies").ToList();

            return cityies;
        }

        public int GetCustomerCheck(int MobileNo)
        {
            /* Customer Number Registration 
             * -------------------------------
             * Result: = 0 is Not Registered 
             * Result = 1 Exits
             * Result = 2 BlackList
             */


            int Result = 0;
            int BlackListCustomerCode = 112;



            if (MobileNo <= 0)
            {
                return 0;
            }

            var CustomerLevel = _db.SP_H7N_GET_CUSTOMNER_LEVEL.FromSqlRaw($"TN_GET_CUSTOMNER_LEVEL '{MobileNo}'").AsEnumerable().FirstOrDefault();

            if (CustomerLevel != null)
            {
                if (CustomerLevel.SUB_COD == BlackListCustomerCode)
                {
                    Result = 2;
                }
                else
                {
                    Result = 1;
                }

            }




            return Result;
        }


        public List<HusoomatWhatsappOffer> GetAllOfferForCity(int SelectedCity)
        {

            List<HusoomatWhatsappOffer> offers = _db.HusoomatWhatsappOffers.Where(o => o.CityId == SelectedCity && o.WhatsappDisplay == true).OrderBy(o => o.DisplayOrder).ToList();

            return offers;

        }
    }
}
