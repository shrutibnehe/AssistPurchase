using System;
using System.Collections.Generic;
using System.Net;
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
        [HttpGet("{productId}")]
        public ActionResult GetSpecificProductByProductId(string productId)
        {
            //return this._productDataBaseRepository.GetAllProducts();
            if (this._productDataBaseRepository.GetSpecificProduct(productId) == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(this._productDataBaseRepository.GetSpecificProduct(productId));
            }

        }
        [HttpPost("AddProduct")]
        public HttpStatusCode Post([FromBody] Models.Products product)
        {
            if (String.IsNullOrEmpty(product.ID))
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
        [HttpDelete("RemoveProduct/{productId}")]
        public HttpStatusCode Delete(string productId)
        {

            bool flag = this._productDataBaseRepository.RemoveProduct(productId);
            if (flag == false)
            {
                return HttpStatusCode.NotFound;


            }
            else
            {
                return HttpStatusCode.OK;

            }
        }
        [HttpPut("UpdateProduct/{productId}")]
        public HttpStatusCode Put(string productId, Models.Products product)
        {
            if (!_productDataBaseRepository.Check(productId, product))
                return HttpStatusCode.BadRequest;
            bool flag = this._productDataBaseRepository.UpdateProduct(productId, product);
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
