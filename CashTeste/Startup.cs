using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CashTeste
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//Entity Framework
			services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<Domain.AppContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1",
					new Info
					{
						Title = "CashBackTeste.API",
						Version = "v1",
						Description = "CashBack Teste.API",
						Contact = new Contact
						{
							Name = "Christopher Lambert",
							Url = "https://github.com/ChristopherLambert"
						}
					});

				var caminhoXmlDoc = string.Format(@"{0}\CashTeste.API.XML", AppDomain.CurrentDomain.BaseDirectory);
				c.IncludeXmlComments(caminhoXmlDoc);
				c.DescribeAllEnumsAsStrings();
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json",
					"CashBack.API");
				c.RoutePrefix = string.Empty;
			});
		}
	}
}
