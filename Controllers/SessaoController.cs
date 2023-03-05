using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos.Gerente;
using Filmes.Data.Dtos.Sessoes;
using Filmes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SessaoController : ControllerBase
	{
		private FilmeContext _context;
		private IMapper _mapper;

		public SessaoController(FilmeContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpPost("AdicionaSessao")]
		public IActionResult AdicionaSessao(CreateSessaoDto dto)
		{
			var sessao = _mapper.Map<Sessao>(dto);

			_context.Sessoes.Add(sessao);
			_context.SaveChanges();

			return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = sessao.Id }, sessao);
		}

		[HttpGet("RecuperaSessoesPorId/{id}")]
		public IActionResult RecuperaSessoesPorId(int id)
		{
			var sessao = _context.Sessoes.FirstOrDefault(x => x.Id == id);

			if (sessao != null)
			{
				var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

				return Ok(sessaoDto);
			}

			return NotFound();
		}
	}
}
