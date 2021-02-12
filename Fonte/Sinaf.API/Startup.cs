using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Base.Core.Middlewares;
using Base.Core.Settings;
using EF.Base.Core.DBConfigurations;
using Sinaf.Domain.Data.Contexts;
using Sinaf.Domain.Mappers;
using Sinaf.Domain.Data.Repositories.Interfaces;
using Sinaf.Domain.Data.Repositories;
using EF.Base.Core.UnitOfWork;
using Sinaf.Domain.Data.UnitOfWork;
using MediatR;
using Sinaf.Domain.Interfaces.Query;
using Sinaf.Domain.Services.Query;
using Sinaf.Domain.Interfaces.Command;
using Sinaf.Domain.Services.Command;

namespace Sinaf.API
{
    public class Startup
    {
        private IConfiguration _configuration { get; }
        private IMapper _mapper;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //Configuração do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title =
                    "Sinaf Web API",
                    Version = "v1",
                    Description = "Web API para fornecer recursos de propostas de seguros do SINAF"
                });

                // Definir o caminho dos comentários para o Swagger
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(System.AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //Configuração de Injeção de Dependências
            ConfigureApplicationSettings(services);
            ConfigureGlobalConfiguration(services);
            ConfigureEFContext(services);
            ConfigureUnitOfWork(services);
            ConfigureMemoryCache(services);
            ConfigureLogger(services);
            ConfigureSession(services);
            ConfigureAutoMapper(services);
            ConfigureMediatR(services);
            ConfigureDomainService(services);
            ConfigureRepository(services);
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
                app.UseHsts();
            }

            app.ConfigureErrorHandlingMiddleware();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Documentação");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureApplicationSettings(IServiceCollection services)
        {
            services.Configure<AppSettings>(_configuration.GetSection(nameof(AppSettings)));
        }

        private void ConfigureGlobalConfiguration(IServiceCollection services)
        {
            services.AddScoped<IGlobalConfiguration, GlobalConfiguration>();
        }

        private void ConfigureEFContext(IServiceCollection services)
        {
            var globalConfig = services.BuildServiceProvider().GetService<IGlobalConfiguration>();

            services.AddDbContext<DataContext>((provider, options) =>
            {
                var dbConn = globalConfig.GetDbConnection("Sinaf_Proposta");
                options.UseSqlServer(dbConn.ConnectionString);
            });

        }

        private void ConfigureUnitOfWork(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private void ConfigureMemoryCache(IServiceCollection services)
        {
            services.AddSingleton<IMemoryCache, MemoryCache>();
        }

        private void ConfigureLogger(IServiceCollection services)
        {
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
        }

        private void ConfigureSession(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddScoped<IEntityToDtoMappingProfile, EntityToDtoMappingProfile>();
            services.AddScoped<IDtoToEntityMappingProfile, DtoToEntityMappingProfile>();

            _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
            services.AddSingleton(_mapper);
        }

        private void ConfigureMediatR(IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }

        /// <summary>
        /// Classes Domain Service para injeção de dependência
        /// </summary>
        private void ConfigureDomainService(IServiceCollection services)
        {
            services.AddScoped<IClienteQueryService, ClienteQueryService>();
            services.AddScoped<IAddPessoaCommandService, AddPessoaCommandService>();
            services.AddScoped<IUpdatePessoaCommandService, UpdatePessoaCommandService>();
        }

        /// <summary>
        /// Classes Repository para injeção de dependência
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureRepository(IServiceCollection services)
        {
            services.AddScoped<IApoliceRepository, ApoliceRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICoberturaRepository, CoberturaRepository>();
            services.AddScoped<ICorretorRepository, CorretorRepository>();
            services.AddScoped<IPessoaEnderecoRepository, PessoaEnderecoRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPessoaTelefoneRepository, PessoaTelefoneRepository>();
            services.AddScoped<ITipoCoberturaRepository, TipoCoberturaRepository>();
            services.AddScoped<IPropostaDependenteRepository, PropostaDependenteRepository>();
            services.AddScoped<IPropostaRepository, PropostaRepository>();
            services.AddScoped<IRamoRepository, RamoRepository>();
        }
    }
}
