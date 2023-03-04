using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos.Filme;
using Filmes.Data.Dtos.Gerente;
using Filmes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GerenteController : ControllerBase
	{
		private FilmeContext _context;
		private IMapper _mapper;

		public GerenteController(FilmeContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpPost("AdicionaGerente")]
		public IActionResult AdicionaGerente (CreateGerenteDto dto)
		{
			var gerente = _mapper.Map<Gerente>(dto);
			
			_context.Gerentes.Add(gerente);
			_context.SaveChanges();

			return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = gerente.Id }, gerente);
		}

		[HttpGet("RecuperaGerentePorId/{id}")]
		public IActionResult RecuperaGerentePorId(int id) 
		{
			var gerente = _context.Gerentes.FirstOrDefault(x => x.Id == id);

			if (gerente != null)
			{
				var gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

				return Ok(gerenteDto);
			}

			return NotFound();
		}

	}
}
