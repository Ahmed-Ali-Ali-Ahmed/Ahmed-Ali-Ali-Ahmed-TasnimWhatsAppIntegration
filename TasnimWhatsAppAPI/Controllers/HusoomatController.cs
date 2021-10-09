using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasnimWhatsAppAPI.Attributes;
using TasnimWhatsAppAPI.Model;
using TasnimWhatsAppOrchestration.WorkingWithData.Husoomat;

namespace TasnimWhatsAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
     [ApiKey]
    public class HusoomatController : ControllerBase
    {

        ILogger<HusoomatController> _logger;
        IGetAndSetDataForHusoomat _getAndSetData;
                              
        public HusoomatController(ILogger<HusoomatController> logger,IGetAndSetDataForHusoomat getAndSetData)
        {
            _logger = logger;
            _getAndSetData = getAndSetData;

        }
        [HttpGet]
        [Route("[action]")]
        public VerifyFieldResponse CustomerCheck(string FormId, string BotId, string CustomerId, string ContactMobile, string SessionKey, string SessionLanguage)
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
                Response.OtherFieldId = "2";

            }
            else if (Result == 2)
            {
                Response.ActionId = 6; // stop the commucation 
            }

            }catch(Exception e)
            {
                _logger.LogError(e.Message);
            }

            return Response;
        }
       
        [HttpGet]
        [Route("[action]")]
        public List<RestListItem> GetCities(string FormId, string BotId, string CustomerId, string ContactMobile, string SessionKey, string SessionLanguage)
        {
            List<RestListItem> restListItems = new List<RestListItem>();

            try
            {
                var cityies = _getAndSetData.GetAllCities();

                foreach(var city in cityies)
                {
                    restListItems.Add(
                       new RestListItem
                       {
                           Code = city.CITY_COD.ToString(),
                           TitleAr = city.CITY_NM_NTV,
                           TitleEn = city.CITY_NM_FRN

                       });
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }

            return restListItems;

        }

        [HttpGet]
        [Route("[action]")]
        public List<RestListItem> CityOffers(string FormId, string BotId, string CustomerId, string ContactMobile, string SessionKey, string SessionLanguage, int CityCode)
        {
            List<RestListItem> restListItems = new List<RestListItem>();

            try
            {
                if(CityCode > 0)
                {

                    var offers = _getAndSetData.GetAllOfferForCity(CityCode);

                    foreach(var offer in offers)
                    {

                        restListItems.Add(
                            new RestListItem
                            {
                                Code = offer.Id.ToString(),
                                TitleAr = offer.OfferName
                            });
                    }
                }
               
            } catch(Exception e)
            {
                _logger.LogError(e.Message);
            }

            return restListItems;
        }


        //[HttpPost]
        //[Route("[action]")]
        //public VerifyFieldResponse OpenNewFile(string FormId, string BotId, string CustomerId, string ContactMobile, string SessionKey, string SessionLanguage, int CityCode, int GenderCode, string CustomerName)
        //{

        //    // Result Code 
        //    // Failed = 0
        //    // Success = 1

        //    // City Code
        //    // Dubai = 206
        //    // Dammam = 227
        //    // AlKhobar = 228 
        //    // Riyadh = 225 

        //    int Result = 0;
        //    int MobileNo = 0;

        //    VerifyFieldResponse Response = new VerifyFieldResponse();

        //    ContactMobile = ContactMobile.Remove(0, 3);
        //    int.TryParse(ContactMobile, out MobileNo);


        //    switch (CityCode)
        //    {
        //        case 1:
        //            CityCode = 225;
        //            break;

        //        case 2:
        //            CityCode = 228;
        //            break;

        //        case 3:
        //            CityCode = 206;
        //            break;
        //    }

        //    switch (GenderCode)
        //    {
        //        case 1:
        //            GenderCode = 221;
        //            break;

        //        case 2:
        //            GenderCode = 220;
        //            break;

        //    }

        //    try
        //    {
        //        bool Success = _getAndSetData.OppenNewFile(MobileNo, CityCode, GenderCode, CustomerName);

        //        Result = Success == true ? 1 : 0;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e.Message);
        //    }


        //    if (Result == 0)
        //    {
        //        Response.ActionId = 5;
        //        Response.MessageText = "ناسف لم نستطيع تنفيذ طلبك نرجو منك اعدة ادخال البيانات ";
        //        Response.OtherFieldId = "8";

        //    }
        //    else if (Result == 1)
        //    {
        //        Response.ActionId = 5;
        //        Response.MessageText = "لقد تم فتح الملف  بنجاح ✅";
        //        Response.OtherFieldId = "1";
        //    }


        //    return Response;
        //}

    }
}
