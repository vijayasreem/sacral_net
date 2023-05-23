using System.Threading.Tasks;
using MongoDB.Driver;
using Sacral.DTO;

namespace Sacral
{
    public class ConfigureJiraRepository : IConfigureJiraRepository
    {
        private readonly IMongoDatabase _mongoDb;
        public ConfigureJiraRepository(IMongoDatabase mongoDb)
        {
            _mongoDb = mongoDb;
        }

        public async Task<ConfigureJiraModel> GetConfigureJiraAsync(int id)
        {
            var collection = _mongoDb.GetCollection<ConfigureJiraModel>("ConfigureJira");
            var filter = Builders<ConfigureJiraModel>.Filter.Eq(x => x.Id, id);
            var result = await collection.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task<string> CreateConfigureJiraAsync(ConfigureJiraModel model)
        {
            var collection = _mongoDb.GetCollection<ConfigureJiraModel>("ConfigureJira");
            await collection.InsertOneAsync(model);
            return "Success";
        }

        public async Task<string> UpdateConfigureJiraAsync(ConfigureJiraModel model)
        {
            var collection = _mongoDb.GetCollection<ConfigureJiraModel>("ConfigureJira");
            var filter = Builders<ConfigureJiraModel>.Filter.Eq(x => x.Id, model.Id);
            var update = Builders<ConfigureJiraModel>.Update
            .Set(x => x.Username, model.Username)
            .Set(x => x.Password, model.Password)
            .Set(x => x.Url, model.Url)
            .Set(x => x.RepositoryName, model.RepositoryName)
            .Set(x => x.Title, model.Title)
            .Set(x => x.Action, model.Action)
            .Set(x => x.NoOfEntries, model.NoOfEntries);
            var result = await collection.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? "Success" : "Error Occurred";
        }

        public async Task<string> DeleteConfigureJiraAsync(int id)
        {
            var collection = _mongoDb.GetCollection<ConfigureJiraModel>("ConfigureJira");
            var filter = Builders<ConfigureJiraModel>.Filter.Eq(x => x.Id, id);
            var result = await collection.DeleteOneAsync(filter);
            return result.IsAcknowledged ? "Success" : "Error Occurred";
        }
    }

    public interface IConfigureJiraRepository
    {
        Task<ConfigureJiraModel> GetConfigureJiraAsync(int id);
        Task<string> CreateConfigureJiraAsync(ConfigureJiraModel model);
        Task<string> UpdateConfigureJiraAsync(ConfigureJiraModel model);
        Task<string> DeleteConfigureJiraAsync(int id);
    }
}