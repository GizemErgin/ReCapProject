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
    public class CarImagesController : ControllerBase
    {
        ICarImageManager _carImageManager;
        public CarImagesController(ICarImageManager carImageManager)
        {
            _carImageManager = carImageManager;
        }

        //---Get
        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _carImageManager.Get(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageManager.GetAll();
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getallimagebycarid")]
        public IActionResult GetAllImageByCarId(int id)
        {
            var result = _carImageManager.GetAllImageByCarId(id);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        //---Post
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageManager.Add(file, carImage);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
        {
            var carImage = _carImageManager.Get(Id).Data;
            var result = _carImageManager.Delete(carImage);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int id)
        {
            var carImage = _carImageManager.Get(id).Data;
            var result = _carImageManager.Update(file, carImage);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
    }
}
