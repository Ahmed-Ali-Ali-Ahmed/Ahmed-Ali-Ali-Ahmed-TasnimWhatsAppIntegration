using Microsoft.EntityFrameworkCore;
using TasnimWhatsAppOrchestration.Models;

namespace TasnimWhatsAppOrchestration.WorkingWithData
{
    public interface IScafoldedContext 
    {
        DbSet<FileCustomerMobile> FileCustomerMobiles { get; set; }
        DbSet<FileCustomer> FileCustomers { get; set; }
        DbSet<FileListed> FileListeds { get; set; }
        DbSet<OnlineRegistrationInfo> OnlineRegistrationInfos { get; set; }
        DbSet<OnlineRegistrationSource> OnlineRegistrationSources { get; set; }
        DbSet<OsSubCod> OsSubCods { get; set; }
        DbSet<SessionCardHeader> SessionCardHeaders { get; set; }
        DbSet<SessionCardType> SessionCardTypes { get; set; }
        DbSet<WhatsappOffer> WhatsappOffers { get; set; }

        void OnTansimeModeolCreaing(ModelBuilder modelBuilder);
    }
}