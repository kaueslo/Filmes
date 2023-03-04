using Filmes.Data;
using Filmes.Data.Dtos;
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
		public async Task<ActionResult> AdicionaFilme([FromBody]CreateFilmeDto filmeDto)
		{
			var filme = new Filme
			{
				Titulo = filmeDto.Titulo,
				Genero = filmeDto.Genero,
				Diretor = filmeDto.Diretor,
				Duracao = filmeDto.Duracao
			};

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
			{
				var filmeDto = new ReadFilmeDto
				{
					Id = filme.Id,
					Titulo = filme.Titulo,
					Diretor = filme.Diretor,
					Duracao = filme.Duracao,
					Genero = filme.Genero,
					HoraDaConsulta = DateTime.Now
				};

				return Ok(filme);
			}

			return NotFound();
		}

		[HttpPut("AtualizaFilme/{id}")]
		public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
		{
			var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

			if (filme == null)
				return NotFound();

			filme.Titulo = filmeDto.Titulo;
			filme.Genero = filmeDto.Genero;
			filme.Diretor = filmeDto.Diretor;
			filme.Duracao = filmeDto.Duracao;

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
