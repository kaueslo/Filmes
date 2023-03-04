﻿using Filmes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace Filmes.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FilmeController : ControllerBase
	{
		private static List<Filme> filmes = new List<Filme>();
		private static int id = 1;

		[HttpPost("AdicionaFilme")]
		public IActionResult AdicionaFilme([FromBody]Filme filme)
		{
			filme.Id = id++;
			filmes.Add(filme);

			return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
			
		}

		[HttpGet("RecuperaFilme")]
		public IActionResult RecuperaFilme() 
		{
			return Ok(filmes);
		}

		[HttpGet("RecuperaFilmePorId/{id}")]
		public IActionResult RecuperaFilmePorId(int id)
		{
			var filme = filmes.FirstOrDefault(x => x.Id == id);

			if (filme != null)
				return Ok(filme);

			return NotFound();
		}

	}
}
