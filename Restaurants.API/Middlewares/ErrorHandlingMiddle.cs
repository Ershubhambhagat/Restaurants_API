﻿
using Microsoft.AspNetCore.Http.HttpResults;
using Restaurants.Domain.Exceptions;

namespace Restaurants.API.Middlewares;

public class ErrorHandlingMiddleWare(
    ILogger<ErrorHandlingMiddleWare> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next.Invoke(context);
		}
		catch (NotFoundException notFound )
		{
			context.Response.StatusCode = 404;
			await context.Response.WriteAsync(notFound.Message);
			logger.LogWarning(notFound.Message);
		}
		catch (ForbidException fb)
		{
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync(fb.Message);
            logger.LogWarning("Access Forbidden ");
        }
		catch (Exception ex)
		{
			logger.LogError(ex,ex.Message);
			context.Response.StatusCode = 500;
			await context.Response.WriteAsync("Something went wronge Message: "+ ex.Message);
		}
    }
}
