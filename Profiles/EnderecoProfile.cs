using AutoMapper;
using Filmes.Data.Dtos.Endereco;
using Filmes.Models;

namespace Filmes.Profiles
{
	public class EnderecoProfile : Profile
	{
		public EnderecoProfile()
		{
			CreateMap<CreateEnderecoDto, Endereco>();
			CreateMap<Endereco, ReadEnderecoDto>();
			CreateMap<UpdateEnderecoDto, Endereco>();
		}
	}
}
