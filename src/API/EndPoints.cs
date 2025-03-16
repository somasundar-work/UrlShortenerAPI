namespace UrlShortener.API
{
    public static class EndPoints
    {
        public static IApplicationBuilder MapUrlShortenerEndPoints(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
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
                ;
            });
            return app;
        }
    }
}
