using apshop.BLL;
using apshop.Data.DTOs;
using apshop.Data.Models;
using apshop.Mapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace apshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {

        private readonly IUserService userService;
        private MapperProfiles mapper;
        public UserController(IUserService us, MapperProfiles mp)
        {
          userService=us; mapper = mp;
        }

        [HttpGet("{userid}")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                return Ok(userService.GetUserById(userId));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("mycart/{userid}")]
        public IActionResult GetUserCart(int userId)
        {
            try
            {
                return Ok(userService.GetMyCart(userId));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("orders/{userid}")]
        public IActionResult GetUserOrders(int userId)
        {
            try
            {
                return Ok(userService.GetMyOrders(userId));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult LogIn(User user)
        {
            //UserDto userdto = mapper.Map<UserDto>(user);
            if (userService.Authenticate(user.username, user.password) == true) return Ok();
            else return BadRequest("The username and password do not match");
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!userService.CheckIfUserExists(user.username)) { userService.Register(user.username, user.password); return Ok(); }
            else return BadRequest("This username already exists");
        }



    }
}
