using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Diagnostics;
using System.Net.Mail;
using Zap.Models;
using Zap.Filters;

namespace Zap.Controllers
{
    [AuthFilter]
    public class AuthController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private UserHandling u;
        private RegistrationHandling rh;

        public AuthController(ILogger<HomeController> logger, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _configuration = configuration;
            u = new UserHandling(configuration);
            rh = new RegistrationHandling(httpContextAccessor.HttpContext.Session);
            httpContextAccessor.HttpContext.Items["roleUser"] = rh.GiveUserRole();
        }
        public IActionResult Registration()
        {
            ViewData["listMuseums"] = u.MuseumsList();
            return View(new HappeningHandler());
        }
        [HttpPost]
        public IActionResult Registration(HappeningHandler id)
        {
            if (ModelState.IsValid)
            {
                List<string> v = u.MailList();
                if (v.Contains(id.Email))
                {
                    ViewData["listMuseums"] = u.MuseumsList();
                    ModelState.AddModelError("", "Mail already registered!");
                    return View(id);
                }
                if (u.InsertUser(id) == true)
                {
                    User ut = u.FindUser(id.Email, id.Password);
                    u.SendMailRegistration(ut.Email, ut.Id);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid data!");
                    return View(id);
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid data!");
                return View(id);
            }
        }
        public IActionResult Login()
        {
            return View(new User());
        }
        [HttpPost]
        public IActionResult Login(User id)
        {
            User ut = u.FindUser(id.Email, id.Password);
            if (ut == null)
            {
                ModelState.AddModelError("", "User not found or wrong credentials!");
                return View(id);
            }
            else
            {
                rh.SetUser(ut);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}