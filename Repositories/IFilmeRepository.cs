using ListaContatos.Models;

namespace ListaContatos.Repositories
{
    public interface IFilmeRepository
    {
        List<FilmeModel> GetAll();
        FilmeModel GetById(Guid id);
        public FilmeModel Add(FilmeModel filme);
        public FilmeModel Update(FilmeModel filme);
        public bool DeleteById(Guid id);
    }
}
