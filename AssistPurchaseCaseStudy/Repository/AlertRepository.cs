using System;
using System.Collections.Generic;
using AssistPurchaseCaseStudy.Models;
using System.Linq;
using System.Threading.Tasks;

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

            public void add(AlertDataModel dataModel)
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
                for (int i = 0; i < _alertsdb.Count; i++)
                {
                    if (_alertsdb[i].CustomerRegion == region)
                    {
                        dataModels.Add(_alertsdb[i]);
                    }
                }
                return dataModels;
            }
        }
}
