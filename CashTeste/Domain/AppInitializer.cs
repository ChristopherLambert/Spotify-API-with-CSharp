using System;
using System.Collections.Generic;
using System.Linq;

using CashTeste.Helpers;
using CashTeste.Model;

namespace CashTeste.Domain
{
	public static class AppInitializer
	{
		public static void Initialize(AppContext context)
		{
			context.Database.EnsureCreated();

			if (!context.CashValores.Any())
				SetCashValores(context);

			if (!context.Discos.Any())
				SetDiscos(context);
		}

		private static void SetCashValores(AppContext context)
		{
			var cashValores = new CashValores[]
			{
				new CashValores{Genero="POP", Dia=1, Valor= Convert.ToDecimal(0.25)},
				new CashValores{Genero="POP", Dia=2, Valor= Convert.ToDecimal(0.07)},
				new CashValores{Genero="POP", Dia=3, Valor= Convert.ToDecimal(0.06)},
				new CashValores{Genero="POP", Dia=4, Valor= Convert.ToDecimal(0.02)},
				new CashValores{Genero="POP", Dia=5, Valor= Convert.ToDecimal(0.10)},
				new CashValores{Genero="POP", Dia=6, Valor= Convert.ToDecimal(0.15)},
				new CashValores{Genero="POP", Dia=7, Valor= Convert.ToDecimal(0.20)},

				new CashValores{Genero="MPB", Dia=1, Valor= Convert.ToDecimal(0.30)},
				new CashValores{Genero="MPB", Dia=2, Valor= Convert.ToDecimal(0.05)},
				new CashValores{Genero="MPB", Dia=3, Valor= Convert.ToDecimal(0.10)},
				new CashValores{Genero="MPB", Dia=4, Valor= Convert.ToDecimal(0.15)},
				new CashValores{Genero="MPB", Dia=5, Valor= Convert.ToDecimal(0.20)},
				new CashValores{Genero="MPB", Dia=6, Valor= Convert.ToDecimal(0.25)},
				new CashValores{Genero="MPB", Dia=7, Valor= Convert.ToDecimal(0.30)},

				new CashValores{Genero="CLASSIC", Dia=1, Valor= Convert.ToDecimal(0.35)},
				new CashValores{Genero="CLASSIC", Dia=2, Valor= Convert.ToDecimal(0.03)},
				new CashValores{Genero="CLASSIC", Dia=3, Valor= Convert.ToDecimal(0.05)},
				new CashValores{Genero="CLASSIC", Dia=4, Valor= Convert.ToDecimal(0.08)},
				new CashValores{Genero="CLASSIC", Dia=5, Valor= Convert.ToDecimal(0.13)},
				new CashValores{Genero="CLASSIC", Dia=6, Valor= Convert.ToDecimal(0.18)},
				new CashValores{Genero="CLASSIC", Dia=7, Valor= Convert.ToDecimal(0.25)},

				new CashValores{Genero="ROCK", Dia=1, Valor= Convert.ToDecimal(0.40)},
				new CashValores{Genero="ROCK", Dia=2, Valor= Convert.ToDecimal(0.10)},
				new CashValores{Genero="ROCK", Dia=3, Valor= Convert.ToDecimal(0.15)},
				new CashValores{Genero="ROCK", Dia=4, Valor= Convert.ToDecimal(0.15)},
				new CashValores{Genero="ROCK", Dia=5, Valor= Convert.ToDecimal(0.15)},
				new CashValores{Genero="ROCK", Dia=6, Valor= Convert.ToDecimal(0.20)},
				new CashValores{Genero="ROCK", Dia=7, Valor= Convert.ToDecimal(0.40)},
			};

			foreach (CashValores cv in cashValores)
			{
				context.CashValores.Add(cv);
			}

			context.SaveChanges();
		}

		private static void SetDiscos(AppContext context)
		{
			var discos = new List<Discos>();

			SpotyRest.StartCredentialsAuth();
			var playListBR = SpotyRest.GetPlaylist("pop", true, "BR");
			var playListEU = SpotyRest.GetPlaylist("pop", true, "AR");

			foreach (var play in playListBR.Playlists.Items)
			{
				if (discos.Count == 50) break;

				discos.Add(new Discos()
				{
					Nome = play.Name,
					Genero = "POP",
					Valor = new Random().Next(10, 100)
				});
			}

			foreach (var play in playListEU.Playlists.Items)
			{
				if (discos.Count == 50) break;

				discos.Add(new Discos()
				{
					Nome = play.Name,
					Genero = "POP",
					Valor = new Random().Next(10, 100)
				});
			}

			foreach (Discos disco in discos)
			{
				context.Discos.Add(disco);
			}

			context.SaveChanges();

			discos.Clear();
		    playListBR = SpotyRest.GetPlaylist("jazz", true, "BR");
			playListEU = SpotyRest.GetPlaylist("jazz", true, "AR");

			foreach (var play in playListBR.Playlists.Items)
			{
				if (discos.Count == 50) break;

				discos.Add(new Discos()
				{
					Nome = play.Name,
					Genero = "MPB",
					Valor = new Random().Next(10, 100)
				});
			}

			foreach (var play in playListEU.Playlists.Items)
			{
				if (discos.Count == 50) break;

				discos.Add(new Discos()
				{
					Nome = play.Name,
					Genero = "MPB",
					Valor = new Random().Next(10, 100)
				});
			}

			foreach (Discos disco in discos)
			{
				context.Discos.Add(disco);
			}

			context.SaveChanges();

			discos.Clear();
			playListBR = SpotyRest.GetPlaylist("classical", true, "BR");
			playListEU = SpotyRest.GetPlaylist("classical", true, "AR");

			foreach (var play in playListBR.Playlists.Items)
			{
				if (discos.Count == 50) break;

				discos.Add(new Discos()
				{
					Nome = play.Name,
					Genero = "CLASSIC",
					Valor = new Random().Next(10, 100)
				});
			}

			foreach (var play in playListEU.Playlists.Items)
			{
				if (discos.Count == 50) break;

				discos.Add(new Discos()
				{
					Nome = play.Name,
					Genero = "CLASSIC",
					Valor = new Random().Next(10, 100)
				});
			}

			foreach (Discos disco in discos)
			{
				context.Discos.Add(disco);
			}

			context.SaveChanges();

			discos.Clear();
			playListBR = SpotyRest.GetPlaylist("rock", true, "BR");
			playListEU = SpotyRest.GetPlaylist("rock", true, "AR");

			foreach (var play in playListBR.Playlists.Items)
			{
				if (discos.Count == 50) break;

				discos.Add(new Discos()
				{
					Nome = play.Name,
					Genero = "ROCK",
					Valor = new Random().Next(10, 100)
				});
			}

			foreach (var play in playListEU.Playlists.Items)
			{
				if (discos.Count == 50) break;

				discos.Add(new Discos()
				{
					Nome = play.Name,
					Genero = "ROCK",
					Valor = new Random().Next(10, 100)
				});
			}

			foreach (Discos disco in discos)
			{
				context.Discos.Add(disco);
			}

			context.SaveChanges();
		}
	}
}

