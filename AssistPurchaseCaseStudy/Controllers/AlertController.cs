using System;
using System.Collections.Generic;
using System.Linq;
using AssistPurchaseCaseStudy.Utility;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssistPurchaseCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        Repository.IAlertRepository _alertDataBaseRepository;

        public AlertController(Repository.IAlertRepository repository)
        {
            this._alertDataBaseRepository = repository;
        }
        // GET: api/<AlertController>
        [HttpGet("Consumers")]
        public IEnumerable<Models.AlertDataModel> Get()
        {
            return this._alertDataBaseRepository.GetCustomers();
        }

        // POST api/<AlertController>
        [HttpPost("ConfirmationAlert")]
        public ActionResult Post([FromBody] Models.AlertDataModel dataModel)
        {
            Validation validations = new Validation();
            bool response = validations.CheckValidity(dataModel);
            if (dataModel == null || response == false)
            {
                return BadRequest("Please Enter Valid Details");
            }
            else
            {
                this._alertDataBaseRepository.add(dataModel);
                string message = "Order with ProductId " + dataModel.ProductIdConfirmed + " has been Confirmed";
                return Ok(message);
            }
        }
        [HttpGet("Consumers/{region}")]
        public ActionResult Get(string region)
        {
            var customers = this._alertDataBaseRepository.GetRegionSpecificCustomers(region);
            if (customers.Count() > 0)
            {
                return Ok(customers);
            }
            else
            {
                return NotFound("No Customers");
            }
        }


    }
}
