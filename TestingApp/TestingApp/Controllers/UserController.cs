namespace TestingApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Numbers"] = new int[] { 1, 2, 3, 4, 5, };
            return View();
        }
    }
}