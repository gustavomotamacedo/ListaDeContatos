using ListaContatos.Data;
using ListaContatos.Models;

namespace ListaContatos.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly AppDbContext _context;
        public FilmeRepository(AppDbContext context)
        {
            _context = context;
        }
        public FilmeModel Add(FilmeModel filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return filme;
        }

        public bool DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<FilmeModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public FilmeModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public FilmeModel Update(FilmeModel filme)
        {
            throw new NotImplementedException();
        }
    }
}
