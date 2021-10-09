using System;
using Xunit;
using TansimWhatsAppOrchestration;
using TasnimWhatsAppOrchestration.WorkingWithData;
using Autofac.Extras.Moq;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TasnimWhatsAppOrchestration.Models;
using System.Collections.Generic;
using Castle.Core.Configuration;
using TasnimWhatsAppOrchestration.WorkingWithData.SkinCareCenter;

namespace TansimWhatsAppOrchestration.Tests
{
    public class GetAndSetDataForTheCenterTest  
    {



      /*  [Theory]
        [InlineData(554940723, 1)]
        [InlineData(555555555, 2)]
        [InlineData(444444444, 0)]
        public void GetCustomerCheck_ShouldCheckWatherCustomeExiste_Muck(int MobileNo, int expected)
        {

            // mocking unit Test 
            using (var context = GetTestContext())
            {
                var GetAndSetDataForTheCenter = new GetAndSetDataForTheCenter(context, null);


                int actual = GetAndSetDataForTheCenter.GetCustomerCheck(MobileNo);

                Assert.Equal(expected, actual);
            }




        }*/


        [Theory]
        [InlineData(554940723, 1)]
        [InlineData(547080917, 1)]
        [InlineData(000000000, 0)]
        public void GetCustomerCheck_ShouldCheckWatherCustomeExiste(int MobileNo, int expected)
        {
            var connection = "Server = 192.168.13.20\\Principle; Database = Eureka; Trusted_Connection = false; User id = ahmed; Password = AhmedAli1999;";
            var options = new DbContextOptionsBuilder<TasnimContext>()
                .UseSqlServer(connection)
                .Options;


            using (var context = new TasnimContext(options))
            {
                var GetAndSetDataForTheCenter = new GetAndSetDataForTheCenter(context, null);

                int actual = GetAndSetDataForTheCenter.GetCustomerCheck(MobileNo);
                Assert.Equal(expected, actual);
            }









        }

      

        [Fact]
        public void GetSalesOffereFromDb_ValidCall()
        {

            var connection = "Server = 192.168.13.20\\Principle; Database = Eureka; Trusted_Connection = false; User id = ahmed; Password = AhmedAli1999;";
            var options = new DbContextOptionsBuilder<TasnimContext>()
                .UseSqlServer(connection)
                .Options;



            using (var context = new TasnimContext(options))
            {
                  var GetAndSetDataForTheCenter = new GetAndSetDataForTheCenter(context, null);


                List<string> expected = new List<string>();




                List<string> actual = GetAndSetDataForTheCenter.GetSalesOffere();

                Assert.True(actual != null);
                Assert.Equal(expected, actual);
            }


        }


        //[Fact]
     /*   public void GetCutomerSessions()
        {


            var connection = "Server = 192.168.13.20\\Principle; Database = Eureka; Trusted_Connection = false; User id = ahmed; Password = AhmedAli1999;";
            var options = new DbContextOptionsBuilder<TasnimContext>()
                .UseSqlServer(connection)
                .Options;


            using (var context = new TasnimContext(options))
            {
                var GetAndSetDataForTheCenter = new GetAndSetDataForTheCenter(context, null);

                List<string> expected = new List<string>();

                foreach (var session in GetCustomerSession())
                {
                    expected.Add(session.MAT_STP_NM_NTV);
                }

                var actual = GetAndSetDataForTheCenter.GetCutomerSessions(547080917);

                Assert.Equal(expected, actual);


            }

        }*/
        private TasnimContext GetTestContext()
        {

            var options = new DbContextOptionsBuilder<TasnimContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            var context = new TasnimContext(options);

            foreach (var offer in GetSalesOffere())
            {
                context.WhatsappOffers.Add(offer);
            }

            foreach (var cuomers in GetCustomersLevel())
            {
                context.TN_GET_CUSTOMNER_LEVEL.Add(cuomers);
            }

            foreach (var session in GetCustomerSession())
            {
                context.TN_GET_CUSTOMER_SESSION.Add(session);
            }

            context.SaveChanges();

            return context;

        }

        private List<WhatsappOffer> GetSalesOffere()
        {
            List<string> Offers = new List<string>();
            List<WhatsappOffer> whatsappOffers = new List<WhatsappOffer>
            {
                new WhatsappOffer
                {
                    Id = 1,
                    DisplayOrder = 2,
                    InsertedDateTime = DateTime.Now,
                    OfferName = "Criateen for 300",
                    WhatsappDisplay = true


                },

                   new WhatsappOffer
                {
                    Id = 2,
                    DisplayOrder = 1,
                    InsertedDateTime = DateTime.Today.AddDays(-2),
                    OfferName = "face mask price 320",
                    WhatsappDisplay = true


                },

                      new WhatsappOffer
                {
                    Id = 3,
                    DisplayOrder = 3,
                    InsertedDateTime = DateTime.Now.AddDays(-3),
                    OfferName = "new skin care price 400",
                    WhatsappDisplay = true


                }

            };



            return whatsappOffers;
        }
        private List<TN_GET_CUSTOMNER_LEVEL> GetCustomersLevel()
        {

            List<TN_GET_CUSTOMNER_LEVEL> cuomers = new List<TN_GET_CUSTOMNER_LEVEL>
            {
                new TN_GET_CUSTOMNER_LEVEL
                {
                Id = 1234,
                MobileKey = 966,
                mobile = 554940723,
                Name = "ahmed",
                SUB_COD = 23
                },
                new TN_GET_CUSTOMNER_LEVEL
                {
                Id = 3421,
                MobileKey = 966,
                mobile = 555555555,
                Name = "Mohammed",
                SUB_COD = 112
                }
            };




            return cuomers;
        }

        private List<TN_GET_CUSTOMER_SESSION> GetCustomerSession()
        {
            List<TN_GET_CUSTOMER_SESSION> sessions = new List<TN_GET_CUSTOMER_SESSION>
            {
                new TN_GET_CUSTOMER_SESSION
                {
                    FileCustomerId = 1234,
                    EXPIRE_END_DATE = DateTime.Today.AddMonths(1),
                    MAT_STP_NM_NTV = "(اكسبريس الشعر للعناية بالجذور) Express hair session ] Expire: 2021 - 09 - 28"
                },
                new TN_GET_CUSTOMER_SESSION
                {
                    FileCustomerId = 1234,
                    EXPIRE_END_DATE = DateTime.Today.AddMonths(1),
                    MAT_STP_NM_NTV = "(اكسبريس الشعر للعناية بالجذور) Express hair session ] Expire: 2022 - 05 - 26"
                }

            };

            return sessions;
        }

    }
}
