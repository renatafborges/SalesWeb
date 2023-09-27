using Microsoft.AspNetCore.Mvc;

namespace SalesWeb.Controllers
{
    public class SalesRecordsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        // GET
        public IActionResult SimpleSearch()
        {
            return View();
        }
        
        // GET
        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}