using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasnimWhatsAppOrchestration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TasnimWhatsAppOrchestration.Helper;

namespace TasnimWhatsAppOrchestration.WorkingWithData
{
    public class GetAndSetData : IGetAndSetData
    {
        protected readonly TasnimContext _db;


        protected readonly AppSettingConfig _config;

        public GetAndSetData(TasnimContext tasnimContext, IConfiguration config)
        {
            this._db = tasnimContext;
            this._config = new AppSettingConfig(config);

        }


     


      



    }
}
