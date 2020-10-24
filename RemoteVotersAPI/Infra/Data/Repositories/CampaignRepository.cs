using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using RemoteVotersAPI.Domain.Bases;
using RemoteVotersAPI.Domain.Entities;
using RemoteVotersAPI.Infra.ModelSettings;

namespace RemoteVotersAPI.Infra.Data.Repositories
{
    public class CampaignRepository : BaseRepository
    {
        public const string CollectionName = "campaigns";
        public IMongoCollection<Campaign> Collection { get; set; }
        private IOptions<MongoDBConfig> MongoDBConfig;

        public CampaignRepository(IOptions<MongoDBConfig> mongoDBConfig) : base(mongoDBConfig)
        {
            MongoDBConfig = mongoDBConfig;
            Collection = DataBase.GetCollection<Campaign>(CollectionName);
        }

        public async Task Create(Campaign record)
        {
            await Collection.InsertOneAsync(record);
        }

        public async Task Delete(ObjectId companyId, ObjectId campaignId)
        {
            await Collection.DeleteOneAsync(Builders<Campaign>.Filter.Where(record => record.Id.Equals(campaignId) &&
                                                                                      record.CompanyId.Equals(companyId)));
        }

        public async Task DeleteAllByCompanyId(ObjectId companyId)
        {
            await Collection.DeleteManyAsync(Builders<Campaign>.Filter.Eq(record => record.CompanyId, companyId));
        }

        public async Task Update(Campaign record)
        {
            await Collection.ReplaceOneAsync(x => x.Id.Equals(record.Id), record);
        }

        public async Task<Campaign> Retrieve(ObjectId companyId, ObjectId campaignId)
        {
            return await Collection.Find(record => record.Id.Equals(campaignId)
                                                && record.CompanyId.Equals(companyId))
                                            .FirstAsync();
        }

        public async Task<List<Campaign>> RetriveAllByCompanyId(ObjectId companyId)
        {
            return await Collection.Find(record => record.CompanyId.Equals(companyId)).ToListAsync();
        }

        public async Task<Campaign> RetrieveByCode(string code)
        {
            return await Collection.Find(record => record.CampaignCode.Equals(code)).FirstAsync();
        }
    }
}
