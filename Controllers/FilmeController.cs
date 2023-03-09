using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos.Filme;
using Filmes.Models;
using Filmes.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace Filmes.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FilmeController : ControllerBase
	{
		private FilmeService _filmeService;

		public FilmeController(FilmeService filmeService)
		{
			_filmeService = filmeService;
		}

		[HttpPost("AdicionaFilme")]
		public IActionResult AdicionaFilme([FromBody]CreateFilmeDto filmeDto)
		{
			var readDto = _filmeService.AdicionaFilme(filmeDto);

			return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = readDto.Id }, readDto);
		}

		[HttpGet("RecuperaFilme")]
		public IActionResult RecuperaFilme([FromQuery] int? classificacaoEtaria = null) 
		{

			var readDto = _filmeService.RecuperaFilmes(classificacaoEtaria);

			if (readDto != null) return Ok(readDto);

			return NotFound();
		}

		[HttpGet("RecuperaFilmePorId/{id}")]
		public IActionResult RecuperaFilmePorId(int id)
		{
			var readDto = _filmeService.RecuperaFilmesPorId(id);

			if (readDto != null) return Ok(readDto);

			return NotFound();
		}

		[HttpPut("AtualizaFilme/{id}")]
		public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
		{
			var resultado = _filmeService.AtualizaFilme(id, filmeDto);

			if (resultado.IsFailed) return NotFound();

			return NoContent();
		}

		[HttpDelete("DeletaFilme/{id}")]
		public IActionResult DeletaFilme(int id)
		{
			var resultado = _filmeService.DeletaFilme(id);

			if (resultado.IsFailed) return NotFound();

			return NoContent();
		}

	}
}
