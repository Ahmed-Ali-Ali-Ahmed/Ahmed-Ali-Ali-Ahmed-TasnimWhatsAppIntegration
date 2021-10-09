using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasnimWhatsAppOrchestration.Helper
{
    public class AppSettingConfig
    {

        private readonly IConfiguration _config;

        public AppSettingConfig(IConfiguration config)
        {
            this._config = config;
        }
        public int GetOrganzationId()
        {

            try
            {
                return int.Parse(_config.GetValue<string>("TansimSetting:OrganizationId"));
            }
            catch (Exception e)
            {
                throw new Exception("Please Provid Organization Id as Integer value", e);
            }


        }


        public int GetOnlineRegistertionTypeCode()
        {

            try
            {
                return int.Parse(_config.GetValue<string>("TansimSetting:OnlineRegistrationSourceCode"));
            }
            catch (Exception e)
            {
                throw new Exception("Please Provid Organization Id as Integer value", e);
            }


        }
    }
}
