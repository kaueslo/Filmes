using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos.Endereco;
using Filmes.Models;
using FluentResults;

namespace Filmes.Services
{
	public class EnderecoService
	{
		private AppDbContext _context;
		private IMapper _mapper;

		public EnderecoService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
		{
			var endereco = _mapper.Map<Endereco>(enderecoDto);

			_context.Enderecos.Add(endereco);

			_context.SaveChangesAsync();

			return _mapper.Map<ReadEnderecoDto>(endereco);
		}

		public List<ReadEnderecoDto> RecuperaEnderecos()
		{
			var endereco = _context.Enderecos;

			return _mapper.Map<List<ReadEnderecoDto>>(endereco);
		}

		public ReadEnderecoDto RecuperaEnderecoPorId(int id)
		{
			var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

			if (endereco != null)
			{
				var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

				return enderecoDto;
			}

			return null;
		}

		public Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto)
		{
			var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

			if (endereco == null)
				return Result.Fail("Endereço não encontrado");

			_mapper.Map(enderecoDto, endereco);

			_context.SaveChanges();

			return Result.Ok();
		}

		public Result DeletaFilme(int id)
		{
			var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

			if (endereco == null)
				return Result.Fail("Endereço não encontrado");

			_context.Remove(endereco);
			_context.SaveChanges();

			return Result.Ok();
		}
	}
}
