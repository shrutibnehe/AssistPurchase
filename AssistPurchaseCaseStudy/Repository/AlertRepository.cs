using System.Collections.Generic;
using AssistPurchaseCaseStudy.Models;


namespace AssistPurchaseCaseStudy.Repository
{
 
        public class AlertRepository : IAlertRepository
        {
            List<AlertDataModel> _alertsdb = new List<AlertDataModel>();
            public AlertRepository()
            {
                _alertsdb.Add(new AlertDataModel
                {
                    CustomerName = "Tom",
                    CustomerContactNo = "8765432019",
                    CustomerRegion = "Pune",
                    CustomerEmailId = "tom@gmail.com",
                    ProductIdConfirmed = "P101"

                });
            }

            public void Add(AlertDataModel dataModel)
            {
                _alertsdb.Add(dataModel);
            }
            public IEnumerable<AlertDataModel> GetCustomers()
            {
                return _alertsdb;
            }

            public IEnumerable<AlertDataModel> GetRegionSpecificCustomers(string region)
            {
                List<AlertDataModel> dataModels = new List<AlertDataModel>();
              
                foreach(AlertDataModel customer in _alertsdb)
                {
                if (customer.CustomerRegion == region)
                    {
                           dataModels.Add(customer);
                    }
                }
                return dataModels;
            }
        }
}
