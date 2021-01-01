using Academia.Dados;
using Academia.Dados.Interfaces;
using Academia.Dados.Repositorios;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rotativa.AspNetCore;
using System;

namespace Academia
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
            services.AddDbContext<Contexto>(opcoes =>
                                                opcoes.UseSqlServer(Configuration.GetConnectionString("Conexao")));

            services.AddScoped<ICategoriaExercicioRepositorio, CategoriaExercicioRepositorio>();
            services.AddScoped<IAdministradorRepositorio, AdministradorRepositorio>();
            services.AddScoped<IExercicioRepositorio, ExercicioRepositorio>();
            services.AddScoped<IProfessorRepositorio, ProfessorRepositorio>();
            services.AddScoped<IObjetivoRepositorio, ObjetivoRepositorio>();
            services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
            services.AddScoped<IFichaRepositorio, FichaRepositorio>();
            services.AddScoped<IListaExercicioRepositorio, ListaExercicioRepositorio>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSession(opcoes =>
            {
                opcoes.IdleTimeout = TimeSpan.FromHours(1);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opcoes =>
                {
                    opcoes.LoginPath = "/Administradores/Login";
                });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            RotativaConfiguration.Setup(env.WebRootPath);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Administradores}/{action=Login}/{id?}");
            });
        }
    }
}