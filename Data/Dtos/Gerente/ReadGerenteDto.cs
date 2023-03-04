namespace Filmes.Data.Dtos.Gerente
{
	public class ReadGerenteDto
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		//Deixa como object para resolver o [JsonIgnore] no retorno dos objetos estrangeiros
		public object Cinemas { get; set; }
	}
}
