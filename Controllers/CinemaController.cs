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
		private AppDbContext _context;
		private IMapper _mapper;

		public CinemaController(AppDbContext context, IMapper mapper)
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
		public IActionResult RecuperaCinema([FromQuery] string nomeDoFilme) 
		{
			var cinemas = new List<Cinema>();

			cinemas = _context.Cinemas.ToList();

			if(cinemas == null)
				return NotFound();

			//Outra forma de consulta, sem LINQ
			if(!string.IsNullOrEmpty(nomeDoFilme))
			{
				IEnumerable<Cinema> query = from cinema in cinemas 
						where cinema.Sessoes.Any(x => x.Filme.Titulo == nomeDoFilme)
						select cinema;

				cinemas = query.ToList();
			}

			var readtDto = _mapper.Map<List<ReadCinemaDto>>(cinemas);

			return Ok(readtDto);
		}

		[HttpGet("RecuperaCinemaPorId/{id}")]
		public IActionResult RecuperaCinemaPorId(int id)
		{
			var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

			if (cinema != null) 
			{
				var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);

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
