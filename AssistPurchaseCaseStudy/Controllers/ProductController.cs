using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssistPurchaseCaseStudy.Repository;
using AssistPurchaseCaseStudy.Models;
using AssistPurchaseCaseStudy.Utility;


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

        //POST: api/<ProductController>/questions
        [HttpPost("questions")]
        public RequestResponse GetNextQuestion([FromBody] RequestResponse recievedResponse)
        {
            var sendResponse = new RequestResponse(new Dictionary<string, string[]> { }, new string[] { }, "");
            var requestvalidator = new Utility.RequestResponseValidation();
            if(requestvalidator.IsRequestResponseCorrect(recievedResponse))
            {
                var suggestionPathObj = new SuggestionPaths();
                sendResponse.Layer = suggestionPathObj.NextLayer(recievedResponse.Layer);
                sendResponse.LayerMembers = suggestionPathObj.NextLayerMembers(recievedResponse.LayerMembers);
                sendResponse.ChoiceDictionary = recievedResponse.ChoiceDictionary;
                sendResponse.ChoiceDictionary.Add(recievedResponse.Layer, recievedResponse.LayerMembers);
            }
            else
            {
                sendResponse.Layer = "Invalid RequestResponse Sent";
            }

            return sendResponse;
        }

        //GET: api/<ProductController>/questions
        [HttpGet("questions")]
        public RequestResponse GetSampleRequestResponse()
        {
            var sendResponse = new RequestResponse();
            return sendResponse;
        }

        //GET: api/<ProductController>/questions/showproducts
        [HttpGet("questions/showproducts")]
        public IEnumerable<Products> Get([FromBody] RequestResponse recievedResponse)
        {
            var requestvalidator = new Utility.RequestResponseValidation();
            if (requestvalidator.IsGetProductRequestCorrect(recievedResponse))
            {
                return this._repository.GetAllProductsBasedOnQuestions(recievedResponse.ChoiceDictionary);
            }
            else
            {
                return new List<Products>() { new Products("Invalid GetProductRequest")};
            }
        }
    }
}
