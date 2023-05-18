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
            List<FilmeModel> filmes = _repo.GetAll();
            return View(filmes);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit([FromRoute]Guid id)
        {
            FilmeModel filme = _repo.GetById(id);
            return View(filme);
        }
        public IActionResult DeleteConfirm([FromRoute] Guid id)
        {
            FilmeModel filme = _repo.GetById(id);
            return View(filme);
        }
        public IActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool deleted = _repo.DeleteById(id);
                    if (deleted)
                    {
                        TempData["mensagemSucesso"] = "Contato deletado com sucesso!";
                    }
                    else
                    {
                        TempData["mensagemErro"] = "Ops, parece que algo deu errado ao deletar o contato!";

                    }
                }
            }
            catch (Exception e)
            {
                TempData["mensagemErro"] = $"Ops, parece que algo deu errado ao cadastrar o contato! Mais detalhes: {e.Message}";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(FilmeModel model)
        {
            try
            {
                _repo.Add(model);
                TempData["mensagemSucesso"] = "Filme adicionado com sucesso!";
            } catch (Exception e)
            {
                TempData["mensagemErro"] = $"Ops, parece que algo deu errado ao adicionar o filme! Mais detalhes: {e.Message}";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(FilmeModel filme)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Update(filme);
                    TempData["mensagemSucesso"] = "Filme alterado com sucesso!";
                }
                else
                {
                    return View("Edit", filme);
                }
            }
            catch (Exception e)
            {
                TempData["mensagemErro"] = $"Ops, parece que algo deu errado ao atualizar o filme! Mais detalhes: {e.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}
