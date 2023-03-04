﻿using System.ComponentModel.DataAnnotations;

namespace Filmes.Data.Dtos.Endereco
{
    public class ReadEnderecoDto
    {
		[Key]
		[Required]
		public int Id { get; set; }
		[Required(ErrorMessage = "O campo título é obrigatório")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}
