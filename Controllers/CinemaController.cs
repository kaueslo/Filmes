using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos.Cinema;
using Filmes.Models;
using Filmes.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace Filmes.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CinemaController : ControllerBase
	{
		private CinemaService _cinemaService;

		public CinemaController(CinemaService cinemaService)
		{
			_cinemaService = cinemaService;
		}

		[HttpPost("AdicionaCinema")]
		public async Task<ActionResult> AdicionaCinema([FromBody]CreateCinemaDto cinemaDto)
		{
			var readDto = _cinemaService.AdicionaCinema(cinemaDto);

			return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = readDto.Id }, readDto);
			
		}

		[HttpGet("RecuperaCinema")]
		public IActionResult RecuperaCinema([FromQuery] string nomeDoFilme) 
		{
			var readDto = _cinemaService.RecuperaCinemas(nomeDoFilme);

			if(readDto != null) return Ok(readDto);

			return NotFound();
		}

		[HttpGet("RecuperaCinemaPorId/{id}")]
		public IActionResult RecuperaCinemaPorId(int id)
		{
			var readDto = _cinemaService.RecuperaCinemaPorId(id);

			if (readDto != null) return Ok(readDto);

			return NotFound();
		}

		[HttpPut("AtualizaCinema/{id}")]
		public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
		{
			var resultado = _cinemaService.AtualizaCinema(id, cinemaDto);

			if (resultado.IsFailed) return NotFound();

			return NoContent();
		}

		[HttpDelete("DeletaCinema/{id}")]
		public IActionResult DeletaCinema(int id)
		{
			var resultado = _cinemaService.DeletaCinema(id);

			if (resultado.IsFailed) return NotFound();

			return NoContent();
		}

	}
}
