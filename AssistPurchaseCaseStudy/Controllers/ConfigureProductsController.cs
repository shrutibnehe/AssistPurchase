using System;
using System.Collections.Generic;

using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssistPurchaseCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigureProductsController : ControllerBase
    {
        Repository.IProductRepository _productDataBaseRepository;

        public ConfigureProductsController(Repository.IProductRepository repository)
        {
            this._productDataBaseRepository = repository;
        }


        // GET: api/<ConfigureProductsController>
        [HttpGet]
        public IEnumerable<Models.Products> Get()
        {
            return this._productDataBaseRepository.GetAllProducts();

        }
        [HttpGet("{ProductId}")]
        public ActionResult GetSpecificProductByProductId(string ProductId)
        {
            //return this._productDataBaseRepository.GetAllProducts();
            if (this._productDataBaseRepository.GetSpecificProduct(ProductId) == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(this._productDataBaseRepository.GetSpecificProduct(ProductId));
            }

        }
        [HttpPost("AddProduct")]
        public HttpStatusCode Post([FromBody] Models.Products product)
        {
            if (product.Equals(null) || String.IsNullOrEmpty(product.ID))
            {
                return HttpStatusCode.BadRequest;
            }
            else
            {
                this._productDataBaseRepository.AddNewProduct(product);
                return HttpStatusCode.Created;

            }
            //return Ok();
            // return Request.CreateResponse(HttpStatusCode.OK);

        }

        // DELETE api/values/5
        //  [HttpDelete("{id}")]
        [HttpDelete("RemoveProduct/{ProductId}")]
        public HttpStatusCode Delete(string ProductId)
        {

            bool flag = this._productDataBaseRepository.RemoveProduct(ProductId);
            if (flag == false)
            {
                return HttpStatusCode.NotFound;


            }
            else
            {
                return HttpStatusCode.OK;

            }
        }
        [HttpPut("UpdateProduct/{ProductId}")]
        public HttpStatusCode Put(string ProductId, Models.Products product)
        {
            if (!_productDataBaseRepository.check(ProductId, product))
                return HttpStatusCode.BadRequest;
            bool flag = this._productDataBaseRepository.UpdateProduct(ProductId, product);
            if (flag == false)
            {
                return HttpStatusCode.NotFound;

            }
            else
            {
                return HttpStatusCode.OK;
            }
        }

    }
}
