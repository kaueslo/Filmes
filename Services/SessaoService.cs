using AutoMapper;
using Filmes.Data;
using Filmes.Data.Dtos.Sessoes;
using Filmes.Models;

namespace Filmes.Services
{
	public class SessaoService
	{
		private AppDbContext _context;
		private IMapper _mapper;

		public SessaoService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public ReadSessaoDto AdicionaSessao(CreateSessaoDto sessaoDto)
		{
			var sessao = _mapper.Map<Sessao>(sessaoDto);

			_context.Sessoes.Add(sessao);
			_context.SaveChanges();

			return _mapper.Map<ReadSessaoDto>(sessao);
		}

		public ReadSessaoDto RecuperaSessaoPorId(int id)
		{
			var sessao = _context.Sessoes.FirstOrDefault(x => x.Id == id);

			if (sessao != null)
			{
				var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

				return sessaoDto;
			}

			return null;
		}

	}
}
