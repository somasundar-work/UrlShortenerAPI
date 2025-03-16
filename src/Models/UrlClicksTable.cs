using System.Text.Json.Serialization;
using Amazon.DynamoDBv2.DataModel;

namespace UrlShortener.Models
{
    [DynamoDBTable("UrlShortener_UrlClicksTable")]
    public class UrlClicksTable
    {
        [DynamoDBHashKey("US_UCT_PK")]
        [JsonIgnore]
        public required string ClickId { get; set; }

        [DynamoDBProperty("US_UCT_GSI_PK")]
        [JsonIgnore]
        public required string ShortCode { get; set; }

        [DynamoDBProperty("US_UCT_CA")]
        [JsonPropertyName("clickedAt")]
        public required DateTime ClickedAt { get; set; }

        [DynamoDBProperty("US_UCT_UA")]
        [JsonPropertyName("userAgent")]
        public string? UserAgent { get; set; }

        [DynamoDBProperty("US_UCT_RF")]
        [JsonPropertyName("referrer")]
        public string? Referrer { get; set; }

        [DynamoDBProperty("US_UCT_IP")]
        [JsonPropertyName("ipAddress")]
        public string? IPAddress { get; set; }

        [DynamoDBProperty("US_UCT_DD")]
        [JsonIgnore]
        public DateTime? DeletionDate { get; set; }
    }
}
