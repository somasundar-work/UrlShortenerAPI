namespace UrlShortener.Business.Handlers
{
    public class GetLongUrlQueryHandler(IDataBase<UrlsTable> dataBase)
        : IRequestHandler<GetLongUrlQuery, Result<string>>
    {
        private readonly IDataBase<UrlsTable> _dataBase = dataBase;

        public async Task<Result<string>> Handle(GetLongUrlQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var longUrl = await _dataBase.GetUrlAsync(request.ShortUrl);
                if (longUrl == null)
                {
                    return Result<string>.Failure("Short url not found.");
                }
                if (longUrl.ExpiryDate < DateTime.Now)
                {
                    return Result<string>.Failure("Short url has expired.");
                }
                return Result<string>.Success(longUrl.LongUrl, "Long url retrieved successfully.");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Result<string>.Error("An error occurred while getting the long url.");
            }
        }
    }
}
