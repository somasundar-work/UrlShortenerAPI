namespace UrlShortener.Business.Query
{
    public record GetLongUrlQuery(string ShortUrl) : IRequest<Result<string>>;
}
