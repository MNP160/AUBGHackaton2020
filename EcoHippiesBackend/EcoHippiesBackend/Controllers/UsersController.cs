using AutoMapper;
using EcoHippiesBackend.DTOs;
using EcoHippiesBackend.Interfaces;
using EcoHippiesBackend.Models;
using EcoHippiesBackend.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EcoHippiesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsersController :ControllerBase
    {
        private IUserService userService;
        private IMapper mapper;
        private readonly ApiContext context;
       
        public UsersController(IUserService service, IMapper map, ApiContext _con)
        {
            userService = service;
            mapper = map;
            context = _con;
        }

        [HttpPost("authenticate")]
     public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = userService.Authenticate(model.Email, model.Password);
           
            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            return Ok();
                                
        }


      
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            var user = mapper.Map<Users>(model);
            try
            {
                userService.Create(user, model.Password);
                var registeredUser = context.Users.FirstOrDefault(x => x.Email == model.Email);

                var mappedUser = mapper.Map<UsersDTO>(registeredUser);
                // _mailService.SendEmail(registeredUser.Email, registeredUser.FirstName, "successfulRegistration", "you have registered successfully");
                return Ok(mappedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }


        }



        [HttpGet("")]

        public IActionResult GetAll()
        {
            var users = userService.GetAll();
                     

            return Ok(users);
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id)        //check when sending request
        {
            var userDto = userService.GetById(id);
            
            return Ok(userDto);
        }


    }
}
