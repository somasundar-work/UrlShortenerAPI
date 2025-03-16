using Amazon.DynamoDBv2.DataModel;

namespace UrlShortener.Models;

[DynamoDBTable("UrlShortener_UrlsTable")]
public class UrlsTable
{
    [DynamoDBHashKey]
    public required string ShortCode { get; set; }

    [DynamoDBProperty]
    public required string LongUrl { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public DateTime? DeletionDate { get; set; }
    public DateTime? LastAccessed { get; set; }
    public int AccessCount { get; set; }
    public bool IsActive { get; set; }
}
