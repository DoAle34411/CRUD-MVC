using Microsoft.AspNetCore.Mvc;

namespace CRUD_MVC.Controllers
{
    public class EventosClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
