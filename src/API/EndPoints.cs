namespace UrlShortener.API
{
    public static class EndPoints
    {
        public static IApplicationBuilder MapUrlShortenerEndPoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet(
                    "/api/{id}",
                    async context =>
                    {
                        await context.Response.WriteAsync(
                            $"Welcome to running ASP.NET Core on AWS Lambda. your path is `{context.Request.Path}`"
                        );
                    }
                );

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
