using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos.Endereco;
using Filmes.Data.Dtos.Filme;
using Filmes.Models;
using Filmes.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace Filmes.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EnderecoController : ControllerBase
	{
		private EnderecoService _enderecoService;

		public EnderecoController(EnderecoService enderecoService)
		{
			_enderecoService = enderecoService;
		}

		[HttpPost("AdicionaEntedeco")]
		public async Task<ActionResult> AdicionaEndereco([FromBody]CreateEnderecoDto enderecoDto)
		{
			var readDto = _enderecoService.AdicionaEndereco(enderecoDto);

			return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = readDto.Id }, readDto);
			
		}

		[HttpGet("RecuperaEndereco")]
		public IEnumerable<ReadEnderecoDto> RecuperaEndereco() 
		{
			return _enderecoService.RecuperaEnderecos(); 
		}

		[HttpGet("RecuperaEnderecoPorId/{id}")]
		public IActionResult RecuperaEnderecoPorId(int id)
		{
			var readDto = _enderecoService.RecuperaEnderecoPorId(id);

			if (readDto != null) return Ok(readDto);

			return NotFound();
		}

		[HttpPut("AtualizaEndereco/{id}")]
		public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
		{
			var resultado = _enderecoService.AtualizaEndereco(id, enderecoDto);

			if (resultado.IsFailed) return NotFound();

			return NoContent();
		}

		[HttpDelete("DeletaEndereco/{id}")]
		public IActionResult DeletaEndereco(int id)
		{
			var resultado = _enderecoService.DeletaFilme(id);

			if (resultado.IsFailed) return NotFound();

			return NoContent();
		}

	}
}
