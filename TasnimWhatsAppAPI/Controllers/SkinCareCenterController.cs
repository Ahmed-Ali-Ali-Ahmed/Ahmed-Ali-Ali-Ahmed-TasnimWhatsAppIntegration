
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasnimWhatsAppAPI.Attributes;
using TasnimWhatsAppAPI.Model;
using TasnimWhatsAppOrchestration.Helper;
using TasnimWhatsAppOrchestration.WorkingWithData;
using TasnimWhatsAppOrchestration.WorkingWithData.SkinCareCenter;

namespace TasnimWhatsAppAPI.Controllers
{


    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class SkinCareCenterController : ControllerBase
    {

        private readonly ILogger<SkinCareCenterController> _logger;
        private IGetAndSetDataForTheCenter _getAndSetData;
     



        public SkinCareCenterController(ILogger<SkinCareCenterController> logger, IGetAndSetDataForTheCenter getAndSetData)
        {
            _logger = logger;
            _getAndSetData = getAndSetData;

        }




         [HttpGet]
         [Route("[action]")]
        public VerifyFieldResponse CustomerCheck(string FormId, string BotId,string CustomerId, string ContactMobile,string SessionKey, string SessionLanguage,string OptionCode)
        {

            /* Customer Number Registration 
            * -------------------------------
            * Result: = 0 is Not Registered 
            * Result = 1 Exits
            * Result = 2 BlackList

            */


            int Result = 0;
            int MobileNo = 0;
            var Response = new VerifyFieldResponse();
            try
            {

                

                if (ContactMobile == null || ContactMobile.Length <= 3)
                {
                    Response.ActionId = 4;
                    Response.OtherFieldId = "8";
                    return Response;
                }




                ContactMobile = ContactMobile.Remove(0, 3);
                int.TryParse(ContactMobile, out MobileNo);


                if (MobileNo != 0)
                {
                    Result = _getAndSetData.GetCustomerCheck(MobileNo);
                }

                if (Result == 0)
                {
                    Response.ActionId = 4;
                    Response.OtherFieldId = "8";


                }
                else if (Result == 1)
                {
                    Response.ActionId = 1;
                    Response.OtherFieldId = OptionCode;

                }
                else if (Result == 2)
                {
                    Response.ActionId = 6; // stop the commucation 
                }
            }
            catch (Exception e )
            {

                _logger.LogError(e.Message);
            }
          
            

            return Response;
        }

        [HttpGet]
        [Route("[action]")]
        public List<RestListItem> CustomerDueSession(string FormId, string BotId, string CustomerId, string ContactMobile, string SessionKey, string SessionLanguage)
        {

            int MobileNo = 0;
            List<RestListItem> restListItems = new List<RestListItem>();

            try
            {
                ContactMobile = ContactMobile.Remove(0, 3);
                int.TryParse(ContactMobile, out MobileNo);

                List<string> Sessions = _getAndSetData.GetCutomerSessions(MobileNo);


                int i = 0;

                //Here I did stope
                foreach (var session in Sessions)
                {
                    i++;

                    restListItems.Add(
                        new RestListItem
                        {
                            Code = i.ToString(),
                            TitleAr = session

                        }
                        );
                }

            
          }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }


            return restListItems;
        }

        [HttpGet]
        [Route("[action]")]
        public List<RestListItem> SaleOffer(string FormId, string BotId, string CustomerId, string ContactMobile, string SessionKey, string SessionLanguage)
        {
            List<RestListItem> restListItems = new List<RestListItem>();

            try
            {
                var SalseOffers = _getAndSetData.GetSalesOffere();
                int i = 0;
                foreach (var offer in SalseOffers)
                {
                    i++;
                    restListItems.Add(
                        new RestListItem
                        {
                            Code = i.ToString(),
                            TitleAr = offer
                        });
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }

            return restListItems;
        }



        [HttpPost]
        [Route("[action]")]
        
        public VerifyFieldResponse Booking( string FormId, string BotId, string CustomerId, string ContactMobile, string SessionKey, string SessionLanguage,  int CityCode, int ServiceCode)
        {
            // Result Code 
            // Failed = 0
            // Success = 1

            // City Code
            // Dubai = 183
            // AlKhobar = 180 
            // Riyadh = 151 


            // ServiceCode
            // hair = 20124    
            // skin = 20125
            //

            int Result = 0;

            int MobileNo = 0;

            VerifyFieldResponse Response = new VerifyFieldResponse();

            try
            {
                ContactMobile = ContactMobile.Remove(0, 3);
                 int.TryParse(ContactMobile, out MobileNo);

                switch (CityCode)
                {
                    case 1:
                     CityCode = 151;
                    break;


                    case 2:
                      CityCode = 180;
                    break;

                    case 3:
                      CityCode = 183;
                    break;

                }

                switch (ServiceCode)
                {

                    case 1:
                        ServiceCode = 20124;
                    break;

                    case 2:
                        ServiceCode = 20125;
                    break;

           
                }

           
                    bool Success = _getAndSetData.RequestBooking(MobileNo, CityCode, ServiceCode);

                    Result = Success == true ?  1 :  0;
           
                if(Result == 0)
                {
                    Response.ActionId = 3;
                    Response.MessageText = "ناسف لم نستطيع تنفيذ طلبك  نرجو منك اعدة ادخال البيانات ";
                    Response.OtherFieldId = "1";
               
                
                }
                else if(Result == 1)
                 {
                    Response.ActionId = 3;
                    Response.MessageText = "لقد تم طلب الحجز بنجاح ✅";
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }


            return Response;
        }




        [HttpPost]
        [Route("[action]")]
        public VerifyFieldResponse OpenNewFile(string FormId, string BotId, string CustomerId, string ContactMobile, string SessionKey, string SessionLanguage, int CityCode, int GenderCode, string CustomerName)
        {

            // Result Code 
            // Failed = 0
            // Success = 1

            // City Code
            // Dubai = 206
            // Dammam = 227
            // AlKhobar = 228 
            // Riyadh = 225 

            int Result = 0;
            int MobileNo = 0;

            VerifyFieldResponse Response = new VerifyFieldResponse();


            try
            {

                ContactMobile = ContactMobile.Remove(0, 3);
               int.TryParse(ContactMobile, out MobileNo);


            switch (CityCode)
            {
                case 1:
                  CityCode = 225;
                break;

                case 2:
                    CityCode = 228;
                 break;

                case 3:
                    CityCode = 206;
                break;
            }

            switch (GenderCode)
            {
                case 1:
                    GenderCode = 221;
                break;

                case 2:
                    GenderCode = 220;
                break;

            }

                bool Success =  _getAndSetData.OppenNewFile(MobileNo, CityCode, GenderCode, CustomerName);

                Result = Success == true ? 1 : 0;
          


            if (Result == 0)
            {
                Response.ActionId = 5;
                Response.MessageText = "ناسف لم نستطيع تنفيذ طلبك نرجو منك اعدة ادخال البيانات ";
                Response.OtherFieldId = "8";

            }
            else if (Result == 1)
            {
                Response.ActionId = 5;
                Response.MessageText = "لقد تم فتح الملف  بنجاح ✅";
                Response.OtherFieldId = "1";
            }

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return Response;
        }



    }
}
