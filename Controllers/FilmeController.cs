using Filmes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace Filmes.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FilmeController : ControllerBase
	{
		private static List<Filme> filmes = new List<Filme>();
		private static int id = 1;

		[HttpPost("AdicionaFilme")]
		public void AdicionaFilme([FromBody]Filme filme)
		{
			filme.Id = id++;
			filmes.Add(filme);

			Console.WriteLine(filme.Titulo);
		}

		[HttpGet("RecuperaFilme")]
		public IEnumerable<Filme> RecuperaFilme() 
		{
			return filmes;
		}

		[HttpGet("RecuperaFilmePorId/{id}")]
		public Filme RecuperaFilmePorId(int id)
		{
			return filmes.FirstOrDefault(x => x.Id == id);
		}

	}
}
