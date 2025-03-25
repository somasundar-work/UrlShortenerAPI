using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UrlShortener.Business.Commands
{
    public class CreateShortUrlCommand : IRequest<Result<string>>
    {
        [Url]
        [Required]
        [JsonPropertyName("long_url")]
        public required string LongUrl { get; set; }

        [Required]
        [JsonPropertyName("expiration")]
        public DateTime Expiration { get; set; }

        [JsonPropertyName("custom_alias")]
        [RegularExpression(
            "^[a-zA-Z0-9]*$",
            ErrorMessage = "Custom alias can only contain alphabetic and numeric characters."
        )]
        public string? CustomAlias { get; set; }
    }
}
