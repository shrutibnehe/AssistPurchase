using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AssistPurchaseCaseStudy.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistPurchaseCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        Repository.IProductRepository _repository;
        public ProductController(Repository.IProductRepository repository)
        {
            this._repository = repository;
        }


        #region Sample
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Products> Get()
        {
            return this._repository.GetAllProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Products Get(string id)
        {
            Models.Products proObj = default(Models.Products);
            foreach (Models.Products prod in _repository.GetAllProducts())
            {
                if (prod.ID == id)
                {
                    proObj = prod;
                    break;
                }
            }
            return proObj;
        }

        // POST api/<ProductController>
        [HttpPost]
        public Products Post([FromBody] Models.Products newProduct)
        {
            Products newObj = newProduct;
            //Console.WriteLine();
            this._repository.AddNewProduct(newObj);
            return newProduct;
        }

        

        #endregion


        [HttpPost("questions")]
        public RequestResponse GetNextQuestion([FromBody] RequestResponse recievedResponse)
        {
            var sendResponse = new RequestResponse();
            var suggestionPathObj = new SuggestionPaths();
            sendResponse.Layer = suggestionPathObj.NextLayer(recievedResponse.Layer);
            sendResponse.LayerMembers = suggestionPathObj.NextLayerMembers(recievedResponse.LayerMembers);

            sendResponse.ChoiceDictionary = recievedResponse.ChoiceDictionary;
            sendResponse.ChoiceDictionary.Add(recievedResponse.Layer, recievedResponse.LayerMembers);

            return sendResponse;
        }

        //GET: api/<ProductController>/question

        [HttpGet("questions")]
        public RequestResponse GetSampleRequestResponse()
        {
            var sendResponse = new RequestResponse();
            return sendResponse;
        }

        //GET: api/<ProductController>/question/showproducts

        [HttpGet("questions/showproducts")]
        public IEnumerable<Products> Get([FromBody] RequestResponse recievedResponse)
        {
            return this._repository.GetAllProductsBasedOnQuestions(recievedResponse.ChoiceDictionary);

        }
    }
}
