using ListaContatos.Data;
using ListaContatos.Models;

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
    }
}
