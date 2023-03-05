using AutoMapper;
using Filmes.Data.Dtos.Sessoes;
using Filmes.Models;

namespace Filmes.Profiles
{
	public class SessaoProfile : Profile
	{
		public SessaoProfile()
		{
			CreateMap<CreateSessaoDto, Sessao>();
			CreateMap<Sessao, ReadSessaoDto>()
				.ForMember(x => x.HorarioDeInicio, opts => 
				opts.MapFrom(x => x.HorarioDeEncerramento.AddMinutes(x.Filme.Duracao*(-1))));
		}
	}
}
