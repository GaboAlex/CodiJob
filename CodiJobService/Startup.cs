using CodiJobService.Model;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Domain.IRepositories;
using Application.IServices;
using Application.Services;
using Infraestructure.Persistencia;
using Infraestructure.Repositories;
using Application;
using FluentValidation;
using Infraestructure.Transversal.FluentValidations;
using FluentValidation.AspNetCore;
using Infraestructure.Transversal.Authenticacion;
using Application.DTOs.CustomDTO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Infraestructure.Transversal.Swagger;

namespace CodiJobService
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
            services.AddDbContext<CodiJobDbContext>(options => 
                options.UseSqlServer(
                    Configuration["Data:CodiJob:ConnectionString"],
                    b => b.MigrationsAssembly("CodiJobService")));

            services.AddDbContext<AppIdentityDbContext>(options => 
                options.UseSqlServer(
                Configuration["Data:CodiJobIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            //Repositorios
            services.AddTransient<IProyectoRepository, EFProyectoRepository>();
            services.AddTransient<ISkillRepository, EFSkillRepository>();
            services.AddTransient<IGrupoRepository, EFGrupoRepository>();
            services.AddTransient<IUsuarioPerfilRepository, EFUsuarioPerfilRepository>();

            //Servicios
            services.AddTransient<IProyectoService, ProyectoService>();
            services.AddTransient<IGrupoService, GrupoService>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<IUsuarioPerfilService, UsuarioPerfilService>();
            services.AddTransient<IUserService, UserService>();

            //Validaciones
            services.AddTransient<IValidator<ProyectoDTO>, ProyectoDTOValidator>();
            services.AddTransient<IValidator<GrupoDTO>, GrupoDTOValidator>();
            services.AddTransient<IValidator<SkillDTO>, SkillDTOValidator>();
            services.AddTransient<IValidator<UsuarioPerfilDTO>, UsuarioPerfilDTOValidator>();
            services.AddTransient<IValidator<LoginDTO>, LoginDTOValidator>();

            //Configure jwt authentication
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x => 
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });

            services.AddSwaggerDocumentation();
            services.AddMvc().AddFluentValidation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            app.UseSwaggerDocumentation();

            app.UseAuthentication();
            app.UseMvc();
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
