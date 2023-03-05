namespace Filmes.Data.Dtos.Sessoes
{
	public class CreateSessaoDto
	{
		public int IdCinema { get; set; }
		public int IdFilme { get; set; }
		public DateTime HorarioDeEncerramento { get; set; }
	}
}
