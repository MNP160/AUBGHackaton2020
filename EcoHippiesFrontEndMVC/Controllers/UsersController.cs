using eCommerceFrontend.Models.REST.Manager;
using eCommerceFrontend.Models.REST.Objects;
using eCommerceFrontend.Models.REST.Objects.Registration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eCommerceFrontend.Controllers
{
    public class UsersController : Controller
    {

        private readonly ILogger<UsersController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _contextAccessor;

        public UsersController(ILogger<UsersController> logger, IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Orders()
        {
            byte[] emailByteArray;
            HttpContext.Session.TryGetValue("email", out emailByteArray);

            var email = System.Text.Encoding.Default.GetString(emailByteArray);
            
            UserManager um = new UserManager(_clientFactory, _contextAccessor);
            List<UserResponse> allUsers = um.Get();
            int currentId = allUsers.Where(x => x.Email == email).Select(x => x.Id).FirstOrDefault();
            UserResponse user = um.Get($"{currentId}");

        
            return View(user);
        }

        [HttpPost]
        public IActionResult Register(RegisterRequest request)
        {
            RegistrationManager rm = new RegistrationManager(_clientFactory, _contextAccessor);
           var responce= rm.Post(request);
          
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }


        [HttpPost]
        public IActionResult Login(AuthenticationRequest request)
        {
                     
          
            return View();
        }


        public IActionResult Logoff()
        {
            HttpContext.Session.Remove("JWToken");
            return Redirect("~/Home/Index");
        }



    }
}
