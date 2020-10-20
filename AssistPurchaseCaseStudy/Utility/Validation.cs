using System;
using AssistPurchaseCaseStudy.Repository;


namespace AssistPurchaseCaseStudy.Utility
{
    public class Validation
    {
        public bool CheckValidity(Models.AlertDataModel dataModel)
        {
            Repository.ProductRepository repository = new ProductRepository();
            bool productIdResponse = repository.CheckProductId(dataModel.ProductIdConfirmed);
            bool detailsresponse = CheckContactNoAndName(dataModel.CustomerContactNo, dataModel.CustomerName);
            if (productIdResponse == false || detailsresponse == false)
            {
                return false;
            }
            return true;

        }
        public bool CheckContactNoAndName(string contactno, string customername)
        {
            if (ContactNocheck(contactno) || String.IsNullOrEmpty(customername))
            {
                return false;
            }
            return true;
        }
        public bool ContactNocheck(string contactno)
        {
            if (String.IsNullOrEmpty(contactno) || contactno.Length != 10)
                return true;
            else
                return false;
        }
    }
}
