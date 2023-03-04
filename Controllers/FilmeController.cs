using Filmes.Data;
using Filmes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace Filmes.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FilmeController : ControllerBase
	{
		private FilmeContext _context;

		public FilmeController(FilmeContext context)
		{
			_context = context;
		}

		[HttpPost("AdicionaFilme")]
		public async Task<ActionResult> AdicionaFilme([FromBody]Filme filme)
		{
			_context.Filmes.Add(filme);

			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
			
		}

		[HttpGet("RecuperaFilme")]
		public IEnumerable<Filme> RecuperaFilme() 
		{
			return _context.Filmes;
		}

		[HttpGet("RecuperaFilmePorId/{id}")]
		public IActionResult RecuperaFilmePorId(int id)
		{
			var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

			if (filme != null)
				return Ok(filme);

			return NotFound();
		}

		[HttpPut("AtualizaFilme/{id}")]
		public IActionResult AtualizaFilme(int id, [FromBody] Filme novoFilme)
		{
			var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

			if (filme == null)
				return NotFound();

			filme.Titulo = novoFilme.Titulo;
			filme.Genero = novoFilme.Genero;
			filme.Diretor = novoFilme.Diretor;
			filme.Duracao = novoFilme.Duracao;

			_context.SaveChanges();

			return NoContent();
		}

		[HttpDelete("DeletaFilme/{id}")]
		public IActionResult DeletaFilme(int id)
		{
			var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

			if (filme == null)
				return NotFound();

			_context.Remove(filme);
			_context.SaveChanges();

			return NoContent();
		}

	}
}
