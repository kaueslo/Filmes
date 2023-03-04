using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmes.Models
{
	public class Endereco
	{
		[Key]
		[Required]
		public int Id { get; set; }
		public int IdCinema { get; set; }
		[Required(ErrorMessage ="É necessário informar o Logradouro")]
		public string Logradouro { get; set; }
		[Required(ErrorMessage = "É necessário informar o Bairro")]
		public string Bairro { get; set; }
		[Required(ErrorMessage = "É necessário informar o Numero")]
		public int Numero { get; set; }
		public Cinema Cinema { get; set; }
	}
}
