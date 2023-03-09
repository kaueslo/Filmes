﻿// <auto-generated />
using System;
using Filmes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Filmes.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230305010848_Incluindo a ClassificacaoEtaria no filme")]
    partial class IncluindoaClassificacaoEtarianofilme
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Filmes.Models.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<int>("IdGerente")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco")
                        .IsUnique();

                    b.HasIndex("IdGerente");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("Filmes.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdCinema")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Filmes.Models.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClassificacaoEtaria")
                        .HasColumnType("int");

                    b.Property<string>("Diretor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("Filmes.Models.Gerente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Gerentes");
                });

            modelBuilder.Entity("Filmes.Models.Sessao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("HorarioDeEncerramento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdCinema")
                        .HasColumnType("int");

                    b.Property<int>("IdFilme")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCinema");

                    b.HasIndex("IdFilme");

                    b.ToTable("Sessoes");
                });

            modelBuilder.Entity("Filmes.Models.Cinema", b =>
                {
                    b.HasOne("Filmes.Models.Endereco", "Endereco")
                        .WithOne("Cinema")
                        .HasForeignKey("Filmes.Models.Cinema", "IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Filmes.Models.Gerente", "Gerente")
                        .WithMany("Cinemas")
                        .HasForeignKey("IdGerente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Gerente");
                });

            modelBuilder.Entity("Filmes.Models.Sessao", b =>
                {
                    b.HasOne("Filmes.Models.Cinema", "Cinema")
                        .WithMany("Sessoes")
                        .HasForeignKey("IdCinema")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Filmes.Models.Filme", "Filme")
                        .WithMany("Sessoes")
                        .HasForeignKey("IdFilme")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("Filmes.Models.Cinema", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("Filmes.Models.Endereco", b =>
                {
                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("Filmes.Models.Filme", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("Filmes.Models.Gerente", b =>
                {
                    b.Navigation("Cinemas");
                });
#pragma warning restore 612, 618
        }
    }
}
