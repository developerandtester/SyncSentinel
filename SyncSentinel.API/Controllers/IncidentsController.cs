using Microsoft.AspNetCore.Mvc;

namespace SyncSentinel.API.Controllers
{
    public class IncidentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
