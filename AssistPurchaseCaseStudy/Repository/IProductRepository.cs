using System.Collections.Generic;
using AssistPurchaseCaseStudy.Models;

namespace AssistPurchaseCaseStudy.Repository
{
   public  interface IProductRepository
    {
        public void AddNewProduct(Products newProduct);
        public IEnumerable<Products> GetAllProducts();

        public IEnumerable<Products> GetAllProductsBasedOnQuestions(Dictionary<string, string[]> choiceDictionary);

      //  IEnumerable<ProductDataModel> GetAllProducts();
        Products GetSpecificProduct(string productId);
        //void AddProduct(Products product);
        bool RemoveProduct(string productId);
        bool UpdateProduct(string productId, Products product);
        bool Check(string productid, Products product);
      

    }
}
