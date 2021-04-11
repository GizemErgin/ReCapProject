using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Business.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerManager _customerManager;
        public CustomersController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        //---GET
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerManager.GetAll();
            if (result.Success) { return Ok(result);}
            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _customerManager.GetByCustomerId(customerId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getcustomerbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _customerManager.GetByUserId(userId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }


        [HttpGet("getcustomerdetails")]
        public IActionResult GetCustomerDetails()
        {
            var result = _customerManager.GetCustomerDetails();
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getcustomerdetailsbyid")]
        public IActionResult GetCustomerDetailsById(int customerId)
        {
            var result = _customerManager.GetCustomerDetailsById(customerId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getcustomerdetailsbyuserid")]
        public IActionResult GetCustomerDetailsByUserId(int userId)
        {
            var result = _customerManager.GetCustomerDetailsByUserId(userId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }


        //---POST
        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerManager.Add(customer);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerManager.Delete(customer);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerManager.Update(customer);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

    }
}
