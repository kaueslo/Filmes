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
			builder.Entity<Endereco>()
				.HasOne(endereco => endereco.Cinema)
				.WithOne(cinema => cinema.Endereco)
				.HasForeignKey<Cinema>(cinema => cinema.IdEndereco);
		}

		public DbSet<Filme> Filmes { get; set; }
		public DbSet<Cinema> Cinemas { get; set; }
		public DbSet<Endereco> Enderecos { get; set; }
	}
}
