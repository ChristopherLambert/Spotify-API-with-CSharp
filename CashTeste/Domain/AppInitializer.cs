using CashTeste.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashTeste.Domain
{
	public static class AppInitializer
	{
		public static void Initialize(AppContext context)
		{
			context.Database.EnsureCreated();

			// Look for any students.
			if (context.CashValores.Any())
			{
				return;  // DB has been seeded
			}

			SetCashValores(context);
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
	}
}

