using System;
using AssistPurchaseCaseStudy.Models;
using AssistPurchaseCaseStudy.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistPurchaseCaseStudy.Utility
{
    public class Validation
    {
        public bool CheckValidity(Models.AlertDataModel dataModel)
        {
            Repository.ProductRepository repository = new ProductRepository();
            bool productIdResponse = repository.checkProductId(dataModel.ProductIdConfirmed);
            bool detailsresponse = checkContactNoAndName(dataModel.CustomerContactNo, dataModel.CustomerName);
            if (productIdResponse == false || detailsresponse == false)
            {
                return false;
            }
            return true;

        }
        public bool checkContactNoAndName(string contactno, string customername)
        {
            if (contactNocheck(contactno) || String.IsNullOrEmpty(customername))
            {
                return false;
            }
            return true;
        }
        public bool contactNocheck(string contactno)
        {
            if (String.IsNullOrEmpty(contactno) || contactno.Length != 10)
                return true;
            else
                return false;
        }
    }
}
