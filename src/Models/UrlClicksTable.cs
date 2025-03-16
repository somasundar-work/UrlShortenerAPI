using Amazon.DynamoDBv2.DataModel;

namespace Models
{
    [DynamoDBTable("UrlShortener_UrlClicksTable")]
    public class UrlClicksTable
    {
        [DynamoDBHashKey("US_UCT_PK")]
        public required string ClickId { get; set; }

        [DynamoDBProperty("US_UCT_GSI_PK")]
        public required string ShortCode { get; set; }

        [DynamoDBProperty("US_UCT_CA")]
        public required DateTime ClickedAt { get; set; }

        [DynamoDBProperty("US_UCT_UA")]
        public string? UserAgent { get; set; }

        [DynamoDBProperty("US_UCT_RF")]
        public string? Referrer { get; set; }

        [DynamoDBProperty("US_UCT_IP")]
        public string? IPAddress { get; set; }
    }
}
