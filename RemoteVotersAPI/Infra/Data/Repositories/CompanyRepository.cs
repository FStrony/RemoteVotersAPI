using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using RemoteVotersAPI.Domain.Bases;
using RemoteVotersAPI.Domain.Entities;
using RemoteVotersAPI.Infra.ModelSettings;

namespace RemoteVotersAPI.Infra.Data.Repositories
{
    public class CompanyRepository : BaseRepository
    {
        public const string CollectionName = "companies";
        public IMongoCollection<Company> Collection { get; set; }
        private IOptions<MongoDBConfig> MongoDBConfig;

        public CompanyRepository(IOptions<MongoDBConfig> mongoDBConfig) : base(mongoDBConfig)
        {
            MongoDBConfig = mongoDBConfig;
            Collection = DataBase.GetCollection<Company>(CollectionName);
        }

        public async Task Create(Company record)
        {
            await Collection.InsertOneAsync(record);
        }

        public async Task Delete(ObjectId id)
        {
            await Collection.DeleteOneAsync(Builders<Company>.Filter.Eq(record => record.Id, id));
        }

        public async Task Update(Company record)
        {
            await Collection.ReplaceOneAsync(x => x.Id.Equals(record.Id), record);
        }

        public async Task<Company> Retrieve(ObjectId id)
        {
            return await Collection.Find(record => record.Id.Equals(id)).FirstAsync();
        }
    }
}
