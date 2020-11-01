using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using remotevotersapi.Infra.ModelSettings;

namespace remotevotersapi.Domain.Bases
{
    /// <summary>
    /// Class responsible for configuring the connection with the database
    /// 
    /// Author: FStrony
    /// </summary>
    public class BaseRepository
    {
        private readonly MongoDBConfig _mongoDBConfig;
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
