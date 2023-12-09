using Microsoft.AspNetCore.Mvc;

namespace CRUD_MVC.Controllers
{
    public class EventosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
