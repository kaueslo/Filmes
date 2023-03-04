using AutoMapper;
using Filmes.Data.Dtos.Endereco;
using Filmes.Data.Dtos.Filme;
using Filmes.Models;

namespace Filmes.Profiles
{
	public class FilmeProfile : Profile
	{
		public FilmeProfile()
		{
			CreateMap<CreateFilmeDto, Filme>();
			CreateMap<Filme, ReadFilmeDto>();
			CreateMap<UpdateFilmeDto, Filme>();
		}
	}
}
