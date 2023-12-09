using Microsoft.AspNetCore.Mvc;

namespace CRUD_MVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
