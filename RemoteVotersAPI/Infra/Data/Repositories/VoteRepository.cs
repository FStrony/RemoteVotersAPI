using System;
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
    public class VoteRepository : BaseRepository
    {
        public const string CollectionName = "votes";
        public IMongoCollection<Vote> Collection { get; set; }
        private IOptions<MongoDBConfig> MongoDBConfig;

        public VoteRepository(IOptions<MongoDBConfig> mongoDBConfig) : base(mongoDBConfig)
        {
            MongoDBConfig = mongoDBConfig;
            Collection = DataBase.GetCollection<Vote>(CollectionName);
        }

        public async Task RegisterVote(Vote record)
        {
            await Collection.InsertOneAsync(record);
        }

        public async Task<bool> hasAlreadyVoted(ObjectId campaignId, String voterIdentity)
        {
            return await Collection.Find(record => record.CampaignId.Equals(campaignId) && record.VoterIdentity.Equals(voterIdentity)).FirstAsync() != null;
        }

        public async Task<List<Vote>> RetriveAllByCampaignId(ObjectId campaignId)
        {
            return await Collection.Find(record => record.CampaignId.Equals(campaignId)).ToListAsync();
        }

        public async Task DeleteAllByCompanyId(ObjectId id)
        {
            await Collection.DeleteManyAsync(Builders<Vote>.Filter.Eq(record => record.CompanyId, id));
        }

        public async Task DeleteAllByCapaignId(ObjectId id)
        {
            await Collection.DeleteManyAsync(Builders<Vote>.Filter.Eq(record => record.CampaignId, id));
        }

    }
}
