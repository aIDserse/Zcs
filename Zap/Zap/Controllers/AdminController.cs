using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Zap.Models;
using Zap.Filters;

namespace Zap.Controllers
{
    [AdminFilter]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IConfiguration _configuration;
        private RegistrationHandling ga;
        private Zap.Models.EventHandler eh;
        private UserHandling u;
        private RegistrationHandling rh;


        public AdminController(ILogger<AdminController> logger, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _configuration = configuration;
            u = new UserHandling(configuration);
            rh = new RegistrationHandling(httpContextAccessor.HttpContext.Session);
            eh = new Models.EventHandler(_configuration);
            httpContextAccessor.HttpContext.Items["roleUser"] = rh.GiveUserRole();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AddEvent()
        {
            ViewData["listMuseums"] = u.MuseumsList();
            return View(new Happening());
        }
        [HttpPost]
        public IActionResult AddEvent(Happening E)
        {
            if (ModelState.IsValid)
            {
                ViewData["listMuseums"] = u.MuseumsList();
                if (eh.NewEvent(E) == true)
                {
                    return RedirectToAction("EventList", "Reservation");
                }
                else
                {
                    ModelState.AddModelError("", "Error! Invalid data!");
                    return View(E);
                }
            }
            else
            {
                ModelState.AddModelError("", "Error! Invalid data!");
                return View(E);
            }
        }


    }
}