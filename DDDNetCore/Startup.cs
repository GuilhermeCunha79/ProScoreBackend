using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Infraestructure.Jogador;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp1;

 public class Startup
    {
        public readonly string LocalHostsAllowed = "_allowedLocalHosts";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

/*
                 services.AddDbContext<DDDSample1DbContext>(opt =>
                     opt.UseInMemoryDatabase("DDDSample1DB")
                         .ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>());*/
            
            
            services.AddDbContext<DDDSample1DbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("jdbc:jtds:sqlserver://192.168.1.72:80;instance=EstagioGuilherme;TrustServerCertificate=True;")) .ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>());
            ConfigureMyServices(services);
            
            services.AddDbContext<DDDSample1DbContext>(opt =>
                opt.UseInMemoryDatabase("DDDSample1DB")
                    .ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>());
        

            ConfigureMyServices(services);

            services.AddControllers().AddNewtonsoftJson();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(LocalHostsAllowed);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public void ConfigureMyServices(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(LocalHostsAllowed, b =>
                {
                    b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IJogadorRepository, JogadorRepository>();
            services.AddTransient<IJogadorService, JogadorService>();
        }
    }