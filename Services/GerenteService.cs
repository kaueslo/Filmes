using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos.Gerente;
using Filmes.Models;
using FluentResults;

namespace Filmes.Services
{
	public class GerenteService
	{
		private AppDbContext _context;
		private IMapper _mapper;

		public GerenteService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public ReadGerenteDto AdicionaGerente(CreateGerenteDto gerenteDto)
		{
			var gerente = _mapper.Map<Gerente>(gerenteDto);

			_context.Gerentes.Add(gerente);
			_context.SaveChanges();

			return _mapper.Map<ReadGerenteDto>(gerente);
		}

		public ReadGerenteDto RecuperaGerentePorId(int id)
		{
			var gerente = _context.Gerentes.FirstOrDefault(x => x.Id == id);

			if (gerente != null)
			{
				var gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

				return gerenteDto;
			}

			return null;
		}

		public Result DeletaGerente(int id)
		{
			var gerente = _context.Gerentes.FirstOrDefault(x => x.Id == id);

			if (gerente == null)
				return Result.Fail("Gerente não encontrado");

			_context.Remove(gerente);
			_context.SaveChanges();

			return Result.Ok();
		}
	}
}
