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

        public async Task<bool> HasAlreadyVoted(ObjectId campaignId, String voterIdentity)
        {
            return await Collection.Find(record => record.CampaignId.Equals(campaignId) && record.VoterIdentity.Equals(voterIdentity)).FirstAsync() != null;
        }

        public async Task<List<Vote>> RetrieveResults(ObjectId companyId, ObjectId campaignId)
        {
            return await Collection.Find(record => record.CampaignId.Equals(campaignId)
                                                && record.CompanyId.Equals(companyId))
                                            .ToListAsync();
        }

        public async Task DeleteAllByCompanyId(ObjectId companyId)
        {
            await Collection.DeleteManyAsync(Builders<Vote>.Filter.Eq(record => record.CompanyId, companyId));
        }

        public async Task DeleteAll(Object companyId, ObjectId campaignId)
        {
            await Collection.DeleteManyAsync(Builders<Vote>.Filter.Where(record => record.CampaignId.Equals(campaignId) &&
                                                                                   record.CompanyId.Equals(companyId)));
        }

    }
}
