using Filmes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FilmeController : ControllerBase
	{
		private static List<Filme> filmes = new List<Filme>();

		[HttpPost("AdicionaFilme")]
		public void AdicionaFilme([FromBody]Filme filme)
		{
			filmes.Add(filme);

			Console.WriteLine(filme.Titulo);
		}

	}
}
