using System.ComponentModel.DataAnnotations;

namespace ListaContatos.Models
{
    public class FilmeModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Nome do contato não pode estar vazio!")]
        public string Nome { get; set; }
        public string ImageLink { get; set; }
    }
}
