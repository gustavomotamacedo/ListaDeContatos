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
            // Esse tipo "List<ContatoModel>" pode ser substituído por var
            List<ContatoModel> contatos = _repo.GetAll();
            return View(contatos);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit([FromRoute]Guid id)
        {
            ContatoModel contato = _repo.GetById(id);
            return View(contato);
        }
        public IActionResult DeleteConfirm([FromRoute]Guid id)
        {
            ContatoModel contato = _repo.GetById(id);
            return View(contato);
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
        public IActionResult Create(ContatoModel contato)
        {
            try
            { 
                if (ModelState.IsValid)
                {
                    _repo.Add(contato);
                    TempData["mensagemSucesso"] = "Contato cadastrado com sucesso!";
                }
                return View(contato);
            } catch(Exception e)
            {
                TempData["mensagemErro"] = $"Ops, parece que algo deu errado ao cadastrar o contato! Mais detalhes: {e.Message}";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Update(contato);
                    TempData["mensagemSucesso"] = "Contato alterado com sucesso!";
                }
                else
                {
                    return View("Edit", contato);
                }
            }
            catch (Exception e)
            {
                TempData["mensagemErro"] = $"Ops, parece que algo deu errado ao atualizar o contato! Mais detalhes: {e.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}
