using System;
using System.Collections.Generic;
using AssistPurchaseCaseStudy.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AssistPurchaseCaseStudy.Repository
{
    public interface IAlertRepository
    {
        void add(AlertDataModel dataModel);
        IEnumerable<AlertDataModel> GetCustomers();
        IEnumerable<AlertDataModel> GetRegionSpecificCustomers(string region);
    }
}
