using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasnimWhatsAppOrchestration.Models;

namespace TasnimWhatsAppOrchestration.WorkingWithData.SkinCareCenter
{
    public class GetAndSetDataForTheCenter : GetAndSetData, IGetAndSetDataForTheCenter
    {

        public GetAndSetDataForTheCenter(TasnimContext tasnimContext, IConfiguration config)
           : base(tasnimContext, config)
        {

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

            var CustomerLevel = _db.TN_GET_CUSTOMNER_LEVEL.FromSqlRaw($"TN_GET_CUSTOMNER_LEVEL '{MobileNo}'").AsEnumerable().FirstOrDefault();

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

        public List<string> GetCutomerSessions(int MobileNo)
        {
            List<string> CustomerSessiuos = new List<string>();



            var fileCustomer = _db.TN_GET_CUSTOMNER_LEVEL.FromSqlRaw($"TN_GET_CUSTOMNER_LEVEL '{MobileNo}'").AsEnumerable().FirstOrDefault();
            //   var fileCustomer = _db.FileCustomers.FirstOrDefault(f => f.IsMerge == false && f.MobileKey == 966 && (f.Mobile == MobileNo || f.FileCustomerMobiles.Any(m => m.Mobile == MobileNo)));
            if (fileCustomer != null)
            {



                var customerSessionsQuery = _db.TN_GET_CUSTOMER_SESSION.FromSqlRaw($"TN_GET_CUSTOMER_SESSION '{fileCustomer.Id}'").ToList();


                /*  if(customerSessionsQuery.Count > 5)
                  {
                      customerSessionsQuery = customerSessionsQuery.Take(5).ToList();
                  }
                 */
                if (customerSessionsQuery != null)
                {
                    foreach (var CS in customerSessionsQuery)
                    {
                        CustomerSessiuos.Add(string.Format("{0} {1} {2}", CS.MAT_STP_NM_NTV.ToString().Trim(), "Expire:", CS.EXPIRE_END_DATE.ToString("yyyy-MM-dd")));
                    }
                }



            }


            return CustomerSessiuos;

        }


        public List<string> GetSalesOffere()
        {



            List<string> returnOffer = new List<string>();


            var Offers = _db.WhatsappOffers.Where(o => o.WhatsappDisplay == true).OrderBy(o => o.DisplayOrder).ToList();

            foreach (var Offer in Offers)
            {
                returnOffer.Add(Offer.OfferName);
            }


            return returnOffer;

        }

        public List<WhatsappOffer> GetSalesOffereFromDb()
        {



            List<string> returnOffer = new List<string>();


            var Offers = _db.WhatsappOffers.Where(o => o.WhatsappDisplay == true).OrderBy(o => o.DisplayOrder).ToList();



            return Offers;

        }


        public bool OppenNewFile(int mobileNo, int cityCode, int GenderCode = 221, string CustomerName = "")
        {
            bool Saved = false;

            int MobileKey = 966;

            // Gender Code
            // Female = 221;
            // Male = 220


            // City Code
            // Dubai = 206
            // Dammam = 227
            // AlKhobar = 228 
            // Riyadh = 225 

            // IdentifyWayId
            // whatsAPP= 1742;


            if (cityCode != 206 && cityCode != 227 && cityCode != 228 && cityCode != 225)
            {
                return Saved;
            }

            if (CustomerName.Equals(""))
            {
                return Saved;
            }

            if (GetCustomerCheck(mobileNo) != 0)
            {
                return Saved;
            }


            FileCustomer NewfileCustomer = new FileCustomer();

            NewfileCustomer.Name = CustomerName;
            NewfileCustomer.Mobile = mobileNo;
            NewfileCustomer.MobileKey = MobileKey;
            NewfileCustomer.Address = cityCode;
            NewfileCustomer.Gender = GenderCode;
            NewfileCustomer.IsMerge = false;
            NewfileCustomer.OpenViaApp = false;
            NewfileCustomer.CreateDate = DateTime.Now;
            NewfileCustomer.Completed = false;
            NewfileCustomer.Directly = false;
            NewfileCustomer.OpenViaWhatsApp = true;
            NewfileCustomer.IdentifyWayId = 1742;


            _db.Add(NewfileCustomer);
            Saved = _db.SaveChanges() > 0;


            return Saved;

        }

        public bool RequestBooking(int MobileNo, int CityCode, int ServiceID)
        {

            // City Code
            // Dubai = 183
            // Jeddah = 156
            // AlKhobar = 180 
            // Riyadh = 151 


            // Service Id
            // hair = 20124    
            // skin = 20125
            //
            // the value stored in NewMaterilaName
            // with forign Key MAT_STP_ID 




            bool saved = false;

            if (CityCode != 183 && CityCode != 151 && CityCode != 180)
            {
                return saved;
            }


            if (ServiceID != 20124 && ServiceID != 20125)
            {
                return saved;
            }



            int onlineRegistrationSourceID = _config.GetOnlineRegistertionTypeCode();

            string Notes = "Booking  by whatsApp";
            DateTime DateTime = DateTime.Now;
            DateTime Date = DateTime.Today;

            var fileCustomer = _db.FileCustomers.FirstOrDefault(f => f.IsMerge == false && f.MobileKey == 966 && (f.Mobile == MobileNo || f.FileCustomerMobiles.Any(m => m.Mobile == MobileNo)));


            if (fileCustomer.Gender == null)
            {
                fileCustomer.Gender = 221;
            }




            _db.OnlineRegistrationInfos.Add(new OnlineRegistrationInfo
            {
                OnlineRegistrationSourceId = onlineRegistrationSourceID,
                FileCustomerId = fileCustomer.Id,
                FileCustomerNew = false,
                FullName = fileCustomer.Name,
                MobileKey = (int)fileCustomer.MobileKey,
                MobileNumber = (int)fileCustomer.Mobile,
                GenderId = (int)fileCustomer.Gender,
                CityStpId = CityCode,
                MatStpId = ServiceID,
                Notes = Notes,
                CreateDate = Date,
                CreateDateTime = DateTime
            });

            saved = (_db.SaveChanges() > 0);


            return saved;

        }
    }
}
