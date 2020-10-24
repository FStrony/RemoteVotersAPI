using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RemoteVotersAPI.Infra.ModelSettings;

namespace RemoteVotersAPI.Domain.Bases
{
    public class BaseRepository
    {
        private readonly MongoDBConfig _mongoDBConfig = null;
        protected MongoClient client { get; private set; }

        public BaseRepository(IOptions<MongoDBConfig> mongoDBConfig)
        {
            _mongoDBConfig = mongoDBConfig.Value;
            client = new MongoClient(_mongoDBConfig.getConnectionString());
            DataBase = client.GetDatabase(_mongoDBConfig.Database);
        }

        public IMongoDatabase DataBase { get; private set; }
    }
}
