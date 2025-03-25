using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.DataAccess.Interfaces;
using UrlShortener.DataAccess.Service;

namespace UrlShortener.DataAccess.Extensions;

public static class DataBaseExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var awsOptions = configuration.GetAWSOptions();
        services.AddDefaultAWSOptions(awsOptions);
        services.AddAWSService<IAmazonDynamoDB>();
        services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
        services.AddSingleton(typeof(IDataBase<>), typeof(DataBase<>));
        return services;
    }
}
