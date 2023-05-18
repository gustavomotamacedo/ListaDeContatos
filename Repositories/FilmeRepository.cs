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
            var filmeDB = this.GetById(id);
            if (filmeDB == null) throw new Exception("Erro na deleção do contato!");
            _context.Filmes.Remove(filmeDB);
            _context.SaveChanges();
            return true;
        }

        public List<FilmeModel> GetAll()
        {
            return _context.Filmes.ToList();
        }

        public FilmeModel GetById(Guid id)
        {
            return _context.Filmes.FirstOrDefault(f => f.Id == id);
        }

        public FilmeModel Update(FilmeModel filme)
        {
            var filmeDB = this.GetById(filme.Id);

            if (filmeDB == null) throw new Exception("Erro na atualização do contato!");

            filmeDB.Nome = filme.Nome;
            filmeDB.ImageLink = filme.ImageLink;
            _context.Filmes.Update(filmeDB);
            _context.SaveChanges();

            return filmeDB;
        }
    }
}
