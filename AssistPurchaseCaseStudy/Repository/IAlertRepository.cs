using System.Collections.Generic;
using AssistPurchaseCaseStudy.Models;


namespace AssistPurchaseCaseStudy.Repository
{
    public interface IAlertRepository
    {
        void Add(AlertDataModel dataModel);
        IEnumerable<AlertDataModel> GetCustomers();
        IEnumerable<AlertDataModel> GetRegionSpecificCustomers(string region);
    }
}
