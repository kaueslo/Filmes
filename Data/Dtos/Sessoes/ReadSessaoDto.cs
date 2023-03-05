namespace Filmes.Data.Dtos.Sessoes
{
	public class ReadSessaoDto
	{
		public int Id { get; set; }
		public Filmes.Models.Cinema Cinema { get; set; }
		public Filmes.Models.Filme Filme { get; set; }
	}
}
