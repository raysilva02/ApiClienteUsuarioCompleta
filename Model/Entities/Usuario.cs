using System.ComponentModel.DataAnnotations;

namespace ApiClienteUsuarioCompleta.Model.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatário")]
        [StringLength(150, ErrorMessage ="O campo {0} deve conter entre {2} e {1} caracteres", MinimumLength=6)]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage ="O formato do e-mail é inválido")]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage ="As senhas não são condizentes")]
        public string SenhaConfirmacao { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
