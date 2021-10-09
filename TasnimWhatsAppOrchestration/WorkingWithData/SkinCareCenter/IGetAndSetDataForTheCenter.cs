using System.Collections.Generic;
using TasnimWhatsAppOrchestration.Models;

namespace TasnimWhatsAppOrchestration.WorkingWithData.SkinCareCenter
{
    public interface IGetAndSetDataForTheCenter: IGetAndSetData
    {
        int GetCustomerCheck(int MobileNo);

        bool OppenNewFile(int mobileNo, int cityCode, int GenderCode = 221, string CustomerName = "");
        List<string> GetCutomerSessions(int MobileNo);
        List<string> GetSalesOffere();
        List<WhatsappOffer> GetSalesOffereFromDb();
        bool RequestBooking(int MobileNo, int CityCode, int ServiceID);
    }
}