using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos.Gerente;
using Filmes.Data.Dtos.Sessoes;
using Filmes.Models;
using Filmes.Services;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SessaoController : ControllerBase
	{
		private SessaoService _sessaoService;

		public SessaoController(SessaoService sessaoService)
		{
			_sessaoService = sessaoService;
		}

		[HttpPost("AdicionaSessao")]
		public IActionResult AdicionaSessao(CreateSessaoDto dto)
		{
			var readDto = _sessaoService.AdicionaSessao(dto);

			return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = readDto.Id }, readDto);
		}

		[HttpGet("RecuperaSessoesPorId/{id}")]
		public IActionResult RecuperaSessoesPorId(int id)
		{
			var readDto = _sessaoService.RecuperaSessaoPorId(id);

			if (readDto != null) return Ok(readDto);

			return NotFound();
		}
	}
}
