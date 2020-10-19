using System;
using System.Collections.Generic;
using AssistPurchaseCaseStudy.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AssistPurchaseCaseStudy.Repository
{
   public  interface IProductRepository
    {
        public void AddNewProduct(Products newProduct);
        public IEnumerable<Products> GetAllProducts();

        public IEnumerable<Products> GetAllProductsBasedOnQuestions(Dictionary<string, string[]> choiceDictionary);

      //  IEnumerable<ProductDataModel> GetAllProducts();
        Products GetSpecificProduct(string ProductId);
        //void AddProduct(Products product);
        bool RemoveProduct(string ProductId);
        bool UpdateProduct(string ProductId, Products product);
        bool check(string productid, Products product);
       // public bool checkProductId(string productId);

    }
}
