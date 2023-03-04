using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmes.Models
{
	public class Cinema
	{
		[Key]
		[Required]
		public int Id { get; set; }
		public int IdEndereco { get; set; }
		public int IdGerente { get; set; }
		[Required(ErrorMessage ="O campo de nome é obrigatório")]
		public string Nome { get; set; }
		public virtual Endereco Endereco { get; set; }
		public virtual Gerente Gerente { get; set; }

	}
}
