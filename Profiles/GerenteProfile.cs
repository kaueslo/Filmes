using AutoMapper;
using Filmes.Data.Dtos.Gerente;
using Filmes.Models;

namespace Filmes.Profiles
{
	public class GerenteProfile : Profile
	{
		public GerenteProfile()
		{
			CreateMap<CreateGerenteDto, Gerente>();
			CreateMap<Gerente, ReadGerenteDto>();
		}
	}
}
