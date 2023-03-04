using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos.Filme;
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
		private IMapper _mapper;

		public FilmeController(FilmeContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpPost("AdicionaFilme")]
		public async Task<ActionResult> AdicionaFilme([FromBody]CreateFilmeDto filmeDto)
		{
			var filme = _mapper.Map<Filme>(filmeDto);

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
				var filmeDto = _mapper.Map<ReadFilmeDto>(filme);

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

			_mapper.Map(filmeDto, filme);

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
