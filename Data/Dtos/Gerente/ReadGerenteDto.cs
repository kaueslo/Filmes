namespace Filmes.Data.Dtos.Gerente
{
	public class ReadGerenteDto
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public List<Filmes.Models.Cinema> Cinemas { get; set; }
	}
}
