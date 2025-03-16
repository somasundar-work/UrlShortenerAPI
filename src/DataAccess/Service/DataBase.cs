using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using UrlShortener.DataAccess.Interfaces;

namespace UrlShortener.DataAccess.Service
{
    public class DataBase<T> : IDataBase<T>
    {
        private readonly DynamoDBContext _context;

        public DataBase(IAmazonDynamoDB dynamoDBClient)
        {
            _context = new DynamoDBContext(dynamoDBClient);
        }

        public async Task<ICollection<T>> GetUrlsAsync(List<ScanCondition> conditions)
        {
            var search = _context.ScanAsync<T>(conditions);
            var result = await search.GetNextSetAsync();
            return result;
        }

        public async Task<T> GetUrlAsync(string primaryKey)
        {
            return await _context.LoadAsync<T>(primaryKey);
        }

        public async Task<T> CreateUrlAsync(T url)
        {
            await _context.SaveAsync(url);
            return url;
        }

        public async Task<T> UpdateUrlAsync(T url)
        {
            await _context.SaveAsync(url);
            return url;
        }

        public async Task DeleteUrlAsync(string primaryKey)
        {
            await _context.DeleteAsync<T>(primaryKey);
        }
    }
}
