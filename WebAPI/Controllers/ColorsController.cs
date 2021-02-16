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
    public class ColorsController : ControllerBase
    {
        IColorManager _colorManager;
        public ColorsController(IColorManager colorManager)
        {
            _colorManager = colorManager;
        }

        //---GET
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorManager.GetAll();
            if (result.Success) { return Ok(result);}
            return BadRequest(result);
        }
        [HttpGet("getbycolorid")]
        public IActionResult GetByColorId(int colorId)
        {
            var result = _colorManager.GetByColorId(colorId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        //---POST
        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorManager.Add(color);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorManager.Delete(color);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Color color)
        {
            var result = _colorManager.Update(color);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

    }
}
