using Microsoft.OpenApi.Models;
using Restaurants.API.Middlewares;
using Serilog;
using System.Runtime.CompilerServices;

namespace Restaurants.API.Extension;

public static class WebApplicationBuilderExtension
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference{Type=ReferenceType.SecurityScheme,Id="bearerAuth"}

                        },[]
                    }
                });
        });
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddScoped<ErrorHandlingMiddleWare>();
        builder.Services.AddScoped<RequestTimeLoggingMiddleware>();
        builder.Host.UseSerilog((context, configurstion) =>
        configurstion.ReadFrom.Configuration(context.Configuration)
    );
    }
}
