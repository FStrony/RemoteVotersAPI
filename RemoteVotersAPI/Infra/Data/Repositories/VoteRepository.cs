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
    /// <summary>
    /// Vote Repository
    ///
    /// Author: FStrony
    /// </summary>
    public class VoteRepository : BaseRepository
    {
        /// <value>Table name</value>
        public const string CollectionName = "votes";

        /// <value>DB Connection</value>
        public IMongoCollection<Vote> Collection { get; set; }

        /// <value>MongoDB configs</value>
        private IOptions<MongoDBConfig> MongoDBConfig;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="mongoDBConfig"></param>
        public VoteRepository(IOptions<MongoDBConfig> mongoDBConfig) : base(mongoDBConfig)
        {
            MongoDBConfig = mongoDBConfig;
            Collection = DataBase.GetCollection<Vote>(CollectionName);
        }

        /// <summary>
        /// Create Vote
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task RegisterVote(Vote record)
        {
            await Collection.InsertOneAsync(record);
        }

        /// <summary>
        /// Check if the voter has already voted in the campaign
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="voterIdentity"></param>
        /// <returns></returns>
        public async Task<bool> HasAlreadyVoted(ObjectId campaignId, String voterIdentity)
        {
            return await Collection.Find(record => record.CampaignId.Equals(campaignId) && record.VoterIdentity.Equals(voterIdentity)).FirstAsync() != null;
        }

        /// <summary>
        /// Retrieve the campaign results
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <returns>Vote list</returns>
        public async Task<List<Vote>> RetrieveResults(ObjectId companyId, ObjectId campaignId)
        {
            return await Collection.Find(record => record.CampaignId.Equals(campaignId)
                                                && record.CompanyId.Equals(companyId))
                                            .ToListAsync();
        }

        /// <summary>
        /// Delete All Votes by company Id
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task DeleteAllByCompanyId(ObjectId companyId)
        {
            await Collection.DeleteManyAsync(Builders<Vote>.Filter.Eq(record => record.CompanyId, companyId));
        }

        /// <summary>
        /// Delete All the votes by company Id and campaign Id
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public async Task DeleteAll(Object companyId, ObjectId campaignId)
        {
            await Collection.DeleteManyAsync(Builders<Vote>.Filter.Where(record => record.CampaignId.Equals(campaignId) &&
                                                                                   record.CompanyId.Equals(companyId)));
        }

    }
}
