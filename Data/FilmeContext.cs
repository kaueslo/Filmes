using Filmes.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Data
{
	public class FilmeContext : DbContext
	{
		public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//Relacao 1:1
			builder.Entity<Endereco>()
				.HasOne(endereco => endereco.Cinema)
				.WithOne(cinema => cinema.Endereco)
				.HasForeignKey<Cinema>(cinema => cinema.IdEndereco);

			//Relacao 1:n / DeleteBehavior tira o delete em cascada, ou seja, não deleta o Cinema quando deleta o gerente
			builder.Entity<Cinema>()
				.HasOne(cinema => cinema.Gerente)
				.WithMany(gerente => gerente.Cinemas)
				.HasForeignKey(cinema => cinema.IdGerente)
				.OnDelete(DeleteBehavior.Restrict);
		}

		public DbSet<Filme> Filmes { get; set; }
		public DbSet<Cinema> Cinemas { get; set; }
		public DbSet<Endereco> Enderecos { get; set; }
		public DbSet<Gerente> Gerentes { get; set; }
	}
}
