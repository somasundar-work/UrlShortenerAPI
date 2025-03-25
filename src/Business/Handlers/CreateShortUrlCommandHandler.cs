using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace UrlShortener.Business.Handlers
{
    public class CreateShortUrlCommandHandler(IDataBase<UrlsTable> dataBase, IConfiguration configuration)
        : IRequestHandler<CreateShortUrlCommand, Result<string>>
    {
        private readonly IDataBase<UrlsTable> _dataBase = dataBase;
        private readonly IConfiguration _configuration = configuration;

        public async Task<Result<string>> Handle(CreateShortUrlCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var shorturl = _configuration["ShortUrl"] ?? "";
                if (string.IsNullOrEmpty(shorturl))
                {
                    return Result<string>.Error("Short url not found.");
                }
                var shortCode = string.Empty;
                if (!string.IsNullOrEmpty(request.CustomAlias))
                {
                    var exist = await CheckAlias(request.CustomAlias);
                    if (!exist)
                    {
                        return Result<string>.Failure("Custom alias already exists.");
                    }
                    shortCode = request.CustomAlias;
                }
                else
                {
                    shortCode = await GenerateShortCode();
                }
                var url = new UrlsTable
                {
                    LongUrl = request.LongUrl,
                    ExpiryDate = request.Expiration,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    DeletionDate = request.Expiration.AddDays(30),
                    ShortCode = shortCode,
                };
                await _dataBase.CreateUrlAsync(url);
                return Result<string>.Success($"{shorturl}/{url.ShortCode}", "Url shortened successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Result<string>.Error("An error occurred while shortening the url.");
            }
        }

        private async Task<bool> CheckAlias(string customAlias)
        {
            var url = await _dataBase.GetUrlAsync(customAlias);
            return url == null;
        }

        private async Task<string> GenerateShortCode()
        {
            var shortCode = MD5.HashData(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()))
                .Select(x => x.ToString("x2"))
                .Aggregate((x, y) => x + y)[..6];
            var notExist = await CheckAlias(shortCode);
            return notExist ? shortCode : await GenerateShortCode();
        }
    }
}
