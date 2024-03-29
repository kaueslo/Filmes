﻿using System.ComponentModel.DataAnnotations;

namespace Filmes.Data.Dtos.Cinema
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        public int IdEndereco { get; set; }
        public int IdGerente { get; set; }
    }
}
