using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos.Endereco;
using Filmes.Data.Dtos.Filme;
using Filmes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace Filmes.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EnderecoController : ControllerBase
	{
		private AppDbContext _context;
		private IMapper _mapper;

		public EnderecoController(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpPost("AdicionaEntedeco")]
		public async Task<ActionResult> AdicionaEndereco([FromBody]CreateEnderecoDto enderecoDto)
		{
			var endereco = _mapper.Map<Endereco>(enderecoDto);

			_context.Enderecos.Add(endereco);

			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = endereco.Id }, endereco);
			
		}

		[HttpGet("RecuperaEndereco")]
		public IEnumerable<Endereco> RecuperaEndereco() 
		{
			return _context.Enderecos;
		}

		[HttpGet("RecuperaEnderecoPorId/{id}")]
		public IActionResult RecuperaEnderecoPorId(int id)
		{
			var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

			if (endereco != null) 
			{
				var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

				return Ok(endereco);
			}

			return NotFound();
		}

		[HttpPut("AtualizaEndereco/{id}")]
		public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
		{
			var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

			if (endereco == null)
				return NotFound();

			_mapper.Map(enderecoDto, endereco);

			_context.SaveChanges();

			return NoContent();
		}

		[HttpDelete("DeletaEndereco/{id}")]
		public IActionResult DeletaEndereco(int id)
		{
			var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

			if (endereco == null)
				return NotFound();

			_context.Remove(endereco);
			_context.SaveChanges();

			return NoContent();
		}

	}
}
