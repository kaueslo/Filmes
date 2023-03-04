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
			//Resolvendo o [JsonIgnore] nas classes
			CreateMap<Gerente, ReadGerenteDto>()
				.ForMember(x => x.Cinemas, opts => opts.MapFrom(gerente => gerente.Cinemas
				.Select(c => new { c.Id, c.Nome, c.Endereco, c.IdEndereco })));
		}
	}
}
