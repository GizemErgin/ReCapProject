using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IPaymentManager _paymentManager;

        public PaymentsController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _paymentManager.GetAll();
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getbypaymentid")]
        public IActionResult GetById(int id)
        {
            var result = _paymentManager.GetById(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Payment payment)
        {
            var result = _paymentManager.Add(payment);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
    }
}
