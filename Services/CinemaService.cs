using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos.Cinema;
using Filmes.Data.Dtos.Filme;
using Filmes.Models;
using FluentResults;

namespace Filmes.Services
{
	public class CinemaService
	{
		private AppDbContext _context;
		private IMapper _mapper;

		public CinemaService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto)
		{
			var cinema = _mapper.Map<Cinema>(cinemaDto);

			_context.Cinemas.Add(cinema);

			_context.SaveChangesAsync();

			return _mapper.Map<ReadCinemaDto>(cinema);
		}

		public List<ReadCinemaDto> RecuperaCinemas(string nomeDoFilme)
		{
			var cinemas = new List<Cinema>();

			cinemas = _context.Cinemas.ToList();

			if (cinemas == null)
				return null;

			//Outra forma de consulta, sem LINQ
			if (!string.IsNullOrEmpty(nomeDoFilme))
			{
				IEnumerable<Cinema> query = from cinema in cinemas
											where cinema.Sessoes.Any(x => x.Filme.Titulo == nomeDoFilme)
											select cinema;

				cinemas = query.ToList();
			}

			return _mapper.Map<List<ReadCinemaDto>>(cinemas);
		}

		public ReadCinemaDto RecuperaCinemaPorId(int id)
		{
			var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

			if (cinema != null)
			{
				var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);

				return cinemaDto;
			}

			return null;
		}

		public Result AtualizaCinema(int id, UpdateCinemaDto cinemaDto)
		{
			var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

			if (cinema == null)
				return Result.Fail("Cinema não encontrado");

			_mapper.Map(cinemaDto, cinema);

			_context.SaveChanges();

			return Result.Ok();
		}

		public Result DeletaCinema(int id)
		{
			var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);

			if (cinema == null)
				return Result.Fail("Cinema não encontrado");

			_context.Remove(cinema);
			_context.SaveChanges();

			return Result.Ok();
		}

	}
}
