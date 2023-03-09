using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos.Filme;
using Filmes.Models;
using FluentResults;

namespace Filmes.Services
{
	public class FilmeService
	{
		private AppDbContext _context;
		private IMapper _mapper;

		public FilmeService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
		{
			var filme = _mapper.Map<Filme>(filmeDto);

			_context.Filmes.Add(filme);

			_context.SaveChangesAsync();

			return _mapper.Map<ReadFilmeDto>(filme);
		}

		public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
		{
			var filmes = new List<Filme>();

			if (classificacaoEtaria == null)
			{
				filmes = _context.Filmes.ToList();
			}
			else
			{
				filmes = _context.Filmes.Where(x => x.ClassificacaoEtaria <= classificacaoEtaria).ToList();
			}


			if (filmes != null)
			{
				var readDto = _mapper.Map<List<ReadFilmeDto>>(filmes);

				return readDto;
			}

			return null;
		}

		public ReadFilmeDto RecuperaFilmesPorId(int id)
		{
			var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

			if (filme != null)
			{
				var filmeDto = _mapper.Map<ReadFilmeDto>(filme);

				return filmeDto;
			}

			return null;
		}

		public Result AtualizaFilme(int id, UpdateFilmeDto filmeDto)
		{
			var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

			var readFilmeDto = _mapper.Map<ReadFilmeDto>(filme);

			if (readFilmeDto == null)
				return Result.Fail("Filme não encontrado");

			_mapper.Map(filmeDto, filme);

			_context.SaveChanges();

			return Result.Ok();
		}

		public Result DeletaFilme(int id)
		{
			var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

			if (filme == null)
				return Result.Fail("Filme não encontrado");

			_context.Remove(filme);
			_context.SaveChanges();

			return Result.Ok();
		}
	}
}
