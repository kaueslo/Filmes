using System.ComponentModel.DataAnnotations;

namespace Filmes.Data.Dtos.Cinema
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
