using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Zap.Models;
using Zap.Filters;

namespace Zap.Controllers
{
    [ReservationFilter]
    public class ReservationController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IConfiguration _configuration;
        private RegistrationHandling ga;
        private Zap.Models.EventHandler eh;
        private UserHandling u;
        private RegistrationHandling rh;
        public ReservationController(ILogger<AdminController> logger, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
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
        public IActionResult EventList()
        {
            var Eventlist = eh.ListAviables();
            return View(Eventlist);
        }

        public IActionResult AddReservation(int id)
        {
            Happening e = eh.getEvent(id);
            if (e != null)
            {
                int i = eh.AviablePlacesEvent(e);
                if (i < 1)
                {
                    return RedirectToAction("EventList");
                }
                else
                {
                    ViewData["Evento"] = e;
                    ViewData["Persona"] = rh.GiveUserID();
                    return View(new Reservation());
                }
            }
            else
            {
                return View("Index");
            }
        }
        [HttpPost]
        public IActionResult AddReservation(Reservation id)
        {
            if (ModelState.IsValid && id.UserID != 0)
            {
                if (eh.NewReservation(id) == true)
                {
                    Happening e = eh.getEvent(id.EventID);
                    User ut = u.GiveUser(id.UserID);
                    if (eh.AviablePlacesEvent(e) > 0)
                    {
                        u.SendMailReservation(ut.Email, e);
                    }
                    return RedirectToAction("EventList");
                }
                else
                {
                    ModelState.AddModelError("", "Error!: invalid data!");
                    return View(id);
                }
            }
            else
            {
                ModelState.AddModelError("", "Error!: invalid data!");
                return View(id);
            }
        }
        public ActionResult FilterEvents(int? organizer, DateTime? date, string title)
        {
            // Assuming you have a list of events called "events"
            var filteredEvents = eh.ListAviables();

            if (organizer.HasValue)
            {
                filteredEvents = filteredEvents.Where(e => e.Organizer == organizer.Value).ToList();
            }

            if (date.HasValue)
            {
                filteredEvents = filteredEvents.Where(e => e.Date.Date == date.Value.Date).ToList();
            }

            if (!string.IsNullOrEmpty(title))
            {
                filteredEvents = filteredEvents.Where(e => e.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            return View("EventList", filteredEvents);
        }
    }
}