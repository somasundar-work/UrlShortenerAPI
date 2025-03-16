using Amazon.DynamoDBv2.DataModel;

namespace UrlShortener.Models;

[DynamoDBTable("UrlShortener_UrlsTable")]
public class UrlsTable
{
    [DynamoDBHashKey("US_UT_PK")]
    public required string ShortCode { get; set; }

    [DynamoDBProperty("US_UT_LU")]
    public required string LongUrl { get; set; }

    [DynamoDBProperty("US_UT_CA")]
    public DateTime CreatedAt { get; set; }

    [DynamoDBProperty("US_UT_ED")]
    public DateTime? ExpiryDate { get; set; }

    [DynamoDBProperty("US_UT_DD")]
    public DateTime? DeletionDate { get; set; }

    [DynamoDBProperty("US_UT_LA")]
    public DateTime? LastAccessed { get; set; }

    [DynamoDBProperty("US_UT_AC")]
    public int AccessCount { get; set; }

    [DynamoDBProperty("US_UT_IA")]
    public bool IsActive { get; set; }
}
