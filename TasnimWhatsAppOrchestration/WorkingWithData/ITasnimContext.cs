using Microsoft.EntityFrameworkCore;
using TasnimWhatsAppOrchestration.Models;

namespace TasnimWhatsAppOrchestration.WorkingWithData
{
    public interface ITasnimContext : IScafoldedContext
    {
        DbSet<SAL_OFFERS> SAL_OFFERS { get; set; }
        DbSet<TN_GET_CUSTOMER_SESSION> TN_GET_CUSTOMER_SESSION { get; set; }
        DbSet<TN_GET_CUSTOMNER_LEVEL> TN_GET_CUSTOMNER_LEVEL { get; set; }

        void OnTansimeModeolCreaing(ModelBuilder modelBuilder);
    }
}