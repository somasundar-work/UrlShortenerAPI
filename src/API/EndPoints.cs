using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Business.Commands;
using UrlShortener.Business.Query;

namespace UrlShortener.API
{
    public static class EndPoints
    {
        public static IApplicationBuilder MapUrlShortenerEndPoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints
                    .MapPost(
                        "/api/short/shorten",
                        async (IMediator mediator, CreateShortUrlCommand request) =>
                        {
                            return await mediator.Send(request);
                        }
                    )
                    .WithName("ShortenUrl")
                    .WithOpenApi();

                endpoints
                    .MapGet(
                        "/{shortUrl}",
                        async (string shortUrl, IMediator mediator) =>
                        {
                            var request = new GetLongUrlQuery(shortUrl);
                            var result = await mediator.Send(request);
                            if (result.IsSuccess && !string.IsNullOrEmpty(result.Data))
                            {
                                return Results.Redirect(result.Data);
                            }
                            else if (
                                result.IsSuccess == false
                                && !string.IsNullOrEmpty(result.Message)
                                && result.Message.Contains("expired")
                            )
                            {
                                return Results.BadRequest(result.Message);
                            }
                            return Results.NotFound();
                        }
                    )
                    .WithName("GetLongUrl")
                    .WithOpenApi();

                endpoints
                    .MapGet(
                        "/",
                        async context =>
                        {
                            await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                        }
                    )
                    .WithName("UrlShortener")
                    .WithOpenApi();
            });
            return app;
        }
    }
}
