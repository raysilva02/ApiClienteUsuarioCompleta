namespace ApiClienteUsuarioCompleta.Model.Dtos
{
    public class ClienteAtualizarDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int TipoCliente { get; set; }
        public bool Ativo { get; set; }
    }
}
