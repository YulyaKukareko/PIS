using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab_APSNETCORE.Models;

namespace Lab_APSNETCORE.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
