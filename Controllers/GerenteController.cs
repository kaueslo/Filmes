using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos.Filme;
using Filmes.Data.Dtos.Gerente;
using Filmes.Models;
using Filmes.Services;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GerenteController : ControllerBase
	{
		
		private GerenteService _gerenteService;

		public GerenteController(GerenteService gerenteService)
		{
			_gerenteService = gerenteService;
		}
		

		[HttpPost("AdicionaGerente")]
		public IActionResult AdicionaGerente (CreateGerenteDto dto)
		{
			var readDto = _gerenteService.AdicionaGerente(dto);

			return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = readDto.Id }, readDto);
		}

		[HttpGet("RecuperaGerentePorId/{id}")]
		public IActionResult RecuperaGerentePorId(int id) 
		{
			var readDto = _gerenteService.RecuperaGerentePorId(id);

			if (readDto != null) return Ok(readDto);

			return NotFound();
		}

		[HttpDelete("DeletaGerente/{id}")]
		public IActionResult DeletaGerente(int id)
		{
			var resultado = _gerenteService.DeletaGerente(id);

			if (resultado.IsFailed) return NotFound();

			return NoContent();
		}

	}
}
