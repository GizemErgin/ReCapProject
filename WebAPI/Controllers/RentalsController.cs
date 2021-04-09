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
    public class RentalsController : ControllerBase
    {
        IRentalManager _rentalManager;
        public RentalsController(IRentalManager rentalManager)
        {
            _rentalManager = rentalManager;
        }

        //---GET
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalManager.GetAll();
            if (result.Success) { return Ok(result);}
            return BadRequest(result);
        }
        [HttpGet("get")]
        public IActionResult Get(int rentalId)
        {
            var result = _rentalManager.Get(rentalId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getrentaldetails")]
        public IActionResult GetRentalDetails()
        {
            var result = _rentalManager.GetRentalDetails();
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getrentaldetailsbycarid")]
        public IActionResult GetRentalDetailsByCarId(int carId)
        {
            var result = _rentalManager.GetRentalDetailsByCarId(carId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getrentaldetailsbycustomerid")]
        public IActionResult GetRentalDetailsByCustomerId(int customerId)
        {
            var result = _rentalManager.GetRentalDetailsByCustomerId(customerId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        //---POST
        [HttpPost("rent")]
        public IActionResult Rent(Rental rental)
        {
            var result = _rentalManager.Rent(rental);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("deliver")]
        public IActionResult Deliver(int rentId, DateTime dateTime)
        {
            dateTime = DateTime.Now;
            var result = _rentalManager.Deliver(rentId, dateTime);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalManager.Update(rental);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpPost("checkcarstatus")]
        public IActionResult CheckCarStatus(Rental rental)
        {
            var result = _rentalManager.CheckCarStatus(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
