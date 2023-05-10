using ListaContatos.Data;
using ListaContatos.Models;
using ListaContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ListaContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _repo;
        public ContatoController(IContatoRepository repo) 
        {
            _repo = repo;
        }
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
        [HttpPost]
        public IActionResult Create(ContatoModel contato)
        {
            _repo.Add(contato);
            return RedirectToAction("Index");
        }
    }
}
