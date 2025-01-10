using Microsoft.AspNetCore.Mvc;

namespace WebApplication15.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
