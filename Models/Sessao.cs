using System.ComponentModel.DataAnnotations;

namespace Filmes.Models
{
	public class Sessao
	{
		[Key]
		[Required]
		public int Id { get; set; }
		public int IdFilme { get; set; }
		public int IdCinema { get; set; }
		public virtual Cinema Cinema { get; set; }
		public virtual Filme Filme { get; set; }
		public DateTime HorarioDeEncerramento { get; set; }
	}
}
