using System.Reflection;
using Application.Abstractions;
using Application.Posts.Commands;
using DataAcceess.Repositories;
using DataAcceess;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Abstractions;

namespace MinimalApi.Extension
{
    public static class MinimalApiExtension
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<SocialDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreatePost).GetTypeInfo().Assembly));
        }

        public static void RegisterEndpointDefinitions(this WebApplication app)
        {
            app.MapGet("/Touch", () => "I AM ALIVE");
            using var scope = app.Services.CreateScope();
            var minimalApis = scope.ServiceProvider.GetService<IEndpointDefinition>();
            foreach (var endpointDef in minimalApis)
            {
                endpointDef.RegisterEndPoints(app);
                
            }

        }

    }
}
