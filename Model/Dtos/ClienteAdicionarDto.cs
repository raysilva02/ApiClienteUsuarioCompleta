﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiClienteUsuarioCompleta.Model.Dtos
{
    public class ClienteAdicionarDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int TipoCliente { get; set; }
        public bool Ativo { get; set; }
    }
}
