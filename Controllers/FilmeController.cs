﻿using Microsoft.AspNetCore.Mvc;

namespace ListaContatos.Controllers
{
    public class FilmeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult DeleteConfirm()
        {
            return View();
        }

    }
}