using ListaContatos.Data;
using ListaContatos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaContatos.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AppDbContext _context;
        public ContatoRepository(AppDbContext context)
        {
            _context = context;
        }
        public ContatoModel Add(ContatoModel contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public bool DeleteById(Guid id)
        {
            var contatoSalvo = this.GetById(id);
            if (contatoSalvo == null) throw new Exception("Erro na deleção do contato!");
            _context.Contatos.Remove(contatoSalvo);
            _context.SaveChanges();
            return true;
        }

        public List<ContatoModel> GetAll()
        {
            return _context.Contatos.ToList();
        }

        public ContatoModel GetById(Guid id)
        {
            return _context.Contatos.FirstOrDefault(c => c.Id == id);
        }

        public ContatoModel Update(ContatoModel contato)
        {
            var contatoSalvo = this.GetById(contato.Id);

            if (contatoSalvo == null) throw new Exception("Erro na atualização do contato!");

            contatoSalvo.Nome = contato.Nome;
            contatoSalvo.Email = contato.Email;
            contatoSalvo.Celular = contato.Celular;
            _context.Contatos.Update(contatoSalvo);
            _context.SaveChanges();

            return contatoSalvo;
        }
    }
}
