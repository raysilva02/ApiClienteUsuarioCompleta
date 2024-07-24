namespace ApiClienteUsuarioCompleta.Model.Dtos.Usuario
{
    public record LoginDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
