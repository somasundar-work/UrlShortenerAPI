﻿using System.Text.Json.Serialization;
using Amazon.DynamoDBv2.DataModel;

namespace UrlShortener.Models;

[DynamoDBTable("UrlShortener_UrlsTable")]
public class UrlsTable
{
    [DynamoDBHashKey("US_UT_PK")]
    [JsonPropertyName("shortCode")]
    public required string ShortCode { get; set; }

    [DynamoDBProperty("US_UT_LU")]
    [JsonPropertyName("longUrl")]
    public required string LongUrl { get; set; }

    [DynamoDBProperty("US_UT_CA")]
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [DynamoDBProperty("US_UT_ED")]
    [JsonPropertyName("expiresAt")]
    public DateTime? ExpiryDate { get; set; }

    [DynamoDBProperty("US_UT_DD")]
    [JsonIgnore]
    public DateTime? DeletionDate { get; set; }

    [DynamoDBProperty("US_UT_LA")]
    [JsonPropertyName("lastAccessed")]
    public DateTime? LastAccessed { get; set; }

    [DynamoDBProperty("US_UT_AC")]
    [JsonPropertyName("clicks")]
    public int AccessCount { get; set; }

    [DynamoDBProperty("US_UT_IA")]
    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }
}
