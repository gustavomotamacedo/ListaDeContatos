using ListaContatos.Models;

namespace ListaContatos.Repositories
{
    public interface IContatoRepository
    {
        List<ContatoModel> GetAll();
        ContatoModel GetById(Guid id);
        public ContatoModel Add(ContatoModel contato);
        public ContatoModel Update(ContatoModel contato);
        public bool DeleteById(Guid id);
    }
}
