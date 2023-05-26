using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Diagnostics;
using System.Net.Mail;
using Zap.Models;
using EventHandler = Zap.Models.EventHandler;

namespace Zap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private EventHandler eh;
        private UserHandling u;
        private RegistrationHandling rh;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _configuration = configuration;
            u = new UserHandling(configuration);
            rh = new RegistrationHandling(httpContextAccessor.HttpContext.Session);
            eh = new EventHandler(_configuration);
            httpContextAccessor.HttpContext.Items["roleUser"] = rh.GiveUserRole();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DeleteReservation(Happening I)
        {
            Happening e = eh.getEvent(I.ID);
            if (e != null)
            {
                ViewData["Evento"] = e;
                ViewData["Persona"] = rh.GiveUserID();
                return View(new Reservation());
            }
            else
            {
                return View("Index");
            }
        }

        public IActionResult DeleteRegistration(int id)
        {
            if (id != 0)
            {
                User p = u.GiveUser(id);
                ViewData["Delete"] = p;
                return View(new User());
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        public IActionResult DeleteReservation(Reservation R)
        {
            if (ModelState.IsValid && R.UserID != 0)
            {
                if (eh.DeleteReservation(R) == true)
                {
                    Happening e = eh.getEvent(R.EventID);
                    ViewData["Evento"] = e;
                    User ut = u.GiveUser(R.UserID);
                    return RedirectToAction("EventList", "Reservation");
                }
                else
                {
                    ModelState.AddModelError("", "Elimination Error: invalid data!");
                    return View(R);
                }
            }
            else
            {
                ModelState.AddModelError("", "Elimination Error: invalid data!");
                return View(R);
            }
        }
        [HttpPost]
        public IActionResult DeleteRegistration(User U)
        {
            if (ModelState.IsValid)
            {
                if (eh.DeleteRegistration(U) == true)
                {

                    return RedirectToAction("Exit");
                }
                else
                {
                    ModelState.AddModelError("", "Error");
                    return View("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "Error");
                return View("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Exit()
        {
            rh.Exit();
            return RedirectToAction("Index", "Home");
        }
    }
}