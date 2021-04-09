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
    public class CarsController : ControllerBase
    {
        ICarManager _carManager;
        public CarsController(ICarManager carManager)
        {
            _carManager = carManager;
        }

        //---GET
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carManager.GetAll();
            if (result.Success) { return Ok(result);}
            return BadRequest(result);
        }
        [HttpGet("get")]
        public IActionResult Get(int carId)
        {
            var result = _carManager.Get(carId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int brandId)
        {
            var result = _carManager.GetByBrandId(brandId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getbycolorid")]
        public IActionResult GetByColorId(int colorId)
        {
            var result = _carManager.GetByColorId(colorId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("carbydailyprice")]
        public IActionResult CarByDailyPrice(decimal min, decimal max)
        {
            var result = _carManager.CarByDailyPrice(min, max);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carManager.GetCarDetails();
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getcardetailsbyid")]
        public IActionResult GetCarDetailsById(int carId)
        {
            var result = _carManager.GetCarDetailsById(carId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getcardetailsbycolorid")]
        public IActionResult GetCarDetailsByColorId(int colorId)
        {
            var result = _carManager.GetCarDetailsByColorId(colorId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getcardetailsbybrandid")]
        public IActionResult GetCarDetailsByBrandId(int brandId)
        {
            var result = _carManager.GetCarDetailsByBrandId(brandId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getallcarsisnotnull")]
        public IActionResult GetAllCarsIsNotNull()
        {
            var result = _carManager.GetAllCarsIsNotNull();
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }



        //---POST
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carManager.Add(car);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carManager.Delete(car);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carManager.Update(car);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

    }
}
