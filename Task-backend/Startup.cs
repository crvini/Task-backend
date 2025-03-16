using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Sales.infrastructure.Repositories;
using Task_backend.Core.Interfaces;
using Task_backend.Infrastructure.Data;
using Task_backend.Infrastructure.Repositories;

namespace Task_backend;

public class Startup
{
    private readonly IConfiguration _configuration;
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options => options.AddDefaultPolicy(
            builder => builder.WithOrigins("http://localhost:4200")
                .AllowAnyOrigin()
                .SetIsOriginAllowed(x => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
        ));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("Task-backend")));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly));


        
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddDbContext<DbTaskContext>(options =>
            options.UseInMemoryDatabase("DBTaskMemory"));
        services.AddControllers(options =>
            {
               

            })
            .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true) // Disable auto validate models
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.DefaultIgnoreCondition =
                    System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);
        services.AddSwaggerGen(x => {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            x.IncludeXmlComments(xmlPath);

            
        });
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseCors();
           
            
            
            app.UseSwagger();

            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task API");
                c.DefaultModelsExpandDepth(-1);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
}