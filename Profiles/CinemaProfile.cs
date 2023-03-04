using AutoMapper;
using Filmes.Data.Dtos.Cinema;
using Filmes.Models;

namespace Filmes.Profiles
{
	public class CinemaProfile : Profile
	{
		public CinemaProfile()
		{
			CreateMap<CreateCinemaDto, Cinema>();
			CreateMap<Cinema, ReadCinemaDto>();
			CreateMap<UpdateCinemaDto, Cinema>();
		}
	}
}
