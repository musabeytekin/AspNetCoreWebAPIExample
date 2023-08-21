using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;

namespace NLayer.API.Middlewares
{
    public static class CustomExeptionHandler
	{
		public static void UseCustomExceptionHandler(this IApplicationBuilder app)
		{
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    int statusCode = exceptionFeature!.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });

            });
		}
	}
}

