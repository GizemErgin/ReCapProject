using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserManager _userManager;
        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        //---GET
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userManager.GetAll();
            if (result.Success) { return Ok(result);}
            return BadRequest(result);
        }
        [HttpGet("getclaims")]
        public IActionResult GetClaims(User user)
        {
            var result = _userManager.GetClaims(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getclaimsbyuserid")]
        public IActionResult GetClaimsByUserId(int userId)
        {
            var result = _userManager.GetClaimById(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByCustomerId(int userId)
        {
            var result = _userManager.GetByUserId(userId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getbyemail")]
        public IActionResult GetById(string email)
        {
            var result = _userManager.GetByEmail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("edit")]
        public IActionResult EditProfile(UserUpdateDto user)
        {
            var result = _userManager.EditProfile(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //---POST
        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userManager.Add(user);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userManager.Delete(user);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userManager.Update(user);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

    }
}
