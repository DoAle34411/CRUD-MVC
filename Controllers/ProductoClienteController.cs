﻿using Microsoft.AspNetCore.Mvc;

namespace CRUD_MVC.Controllers
{
    public class ProductoClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
