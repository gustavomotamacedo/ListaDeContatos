using System.ComponentModel.DataAnnotations;

namespace ListaContatos.Models
{
    public class ContatoModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Nome do contato não pode estar vazio!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Email do contato não pode estar vazio!")]
        [EmailAddress(ErrorMessage = "Digite um formato de Email válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O Celular do contato não pode estar vazio!")]
        [Phone(ErrorMessage = "Digite um formato de Celular válido!")]
        public string Celular { get; set; }
    }
}
