using Amazon.DynamoDBv2.DataModel;

namespace UrlShortener.DataAccess.Interfaces;

public interface IDataBase<T>
{
    public Task<ICollection<T>> GetUrlsAsync(List<ScanCondition> conditions);
    public Task<T> GetUrlAsync(string primaryKey);
    public Task<T> CreateUrlAsync(T url);
    public Task<T> UpdateUrlAsync(T url);
    public Task DeleteUrlAsync(string primaryKey);
}
