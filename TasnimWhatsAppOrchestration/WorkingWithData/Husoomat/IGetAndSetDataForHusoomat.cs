using System.Collections.Generic;
using TasnimWhatsAppOrchestration.Models;

namespace TasnimWhatsAppOrchestration.WorkingWithData.Husoomat
{
    public interface IGetAndSetDataForHusoomat
    {
        List<SP_Husoomat_Whatsapp_Offer_Cityies> GetAllCities();

        int GetCustomerCheck(int MobileNo);
        List<HusoomatWhatsappOffer> GetAllOfferForCity(int SelectedCity);
    }
}