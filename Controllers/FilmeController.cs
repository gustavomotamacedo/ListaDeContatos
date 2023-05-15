using ListaContatos.Models;
using ListaContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ListaContatos.Controllers
{
    public class FilmeController : Controller
    {
        private readonly IFilmeRepository _repo;
        public FilmeController(IFilmeRepository repo)
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
        public IActionResult Edit([FromRoute]Guid id)
        {
            return View();
        }
        public IActionResult DeleteConfirm([FromRoute] Guid id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FilmeModel model)
        {
            _repo.Add(model);
            return View();
        }
    }
}
