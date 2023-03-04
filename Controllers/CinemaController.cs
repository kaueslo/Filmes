using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos.Cinema;
using Filmes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace Filmes.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CinemaController : ControllerBase
	{
		private FilmeContext _context;
		private IMapper _mapper;

		public CinemaController(FilmeContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpPost("AdicionaCinema")]
		public async Task<ActionResult> AdicionaCinema([FromBody]CreateCinemaDto cinemaDto)
		{
			var cinema = _mapper.Map<Cinema>(cinemaDto);

			_context.Cinemas.Add(cinema);

			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = cinema.Id }, cinema);
			
		}

		[HttpGet("RecuperaCinema")]
		public IEnumerable<Cinema> RecuperaCinema() 
		{
			return _context.Cinemas;
		}

		[HttpGet("RecuperaCinemaPorId/{id}")]
		public IActionResult RecuperaCinemaPorId(int id)
		{
			var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

			if (cinema != null) 
			{
				var filmeDto = _mapper.Map<ReadCinemaDto>(cinema);

				return Ok(cinema);
			}

			return NotFound();
		}

		[HttpPut("AtualizaCinema/{id}")]
		public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
		{
			var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

			if (cinema == null)
				return NotFound();

			_mapper.Map(cinemaDto, cinema);

			_context.SaveChanges();

			return NoContent();
		}

		[HttpDelete("DeletaCinema/{id}")]
		public IActionResult DeletaCinema(int id)
		{
			var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

			if (cinema == null)
				return NotFound();

			_context.Remove(cinema);
			_context.SaveChanges();

			return NoContent();
		}

	}
}
