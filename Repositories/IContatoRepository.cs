using ListaContatos.Models;

namespace ListaContatos.Repositories
{
    public interface IContatoRepository
    {
        public ContatoModel Add(ContatoModel contato);
    }
}
