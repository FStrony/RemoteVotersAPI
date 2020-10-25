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
    /// Campaign Repository
    ///
    /// Author: FStrony
    /// </summary>
    public class CampaignRepository : BaseRepository
    {
        /// <value>Table name</value>
        public const string CollectionName = "campaigns";

        /// <value>DB Connection</value>
        public IMongoCollection<Campaign> Collection { get; set; }

        /// <value>MongoDB configs</value>
        private IOptions<MongoDBConfig> MongoDBConfig;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="mongoDBConfig"></param>
        public CampaignRepository(IOptions<MongoDBConfig> mongoDBConfig) : base(mongoDBConfig)
        {
            MongoDBConfig = mongoDBConfig;
            Collection = DataBase.GetCollection<Campaign>(CollectionName);
        }

        /// <summary>
        /// Create Campaign
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task Create(Campaign record)
        {
            await Collection.InsertOneAsync(record);
        }

        /// <summary>
        /// Delete Campaign by company ID and Campaign Id
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public async Task Delete(ObjectId companyId, ObjectId campaignId)
        {
            await Collection.DeleteOneAsync(Builders<Campaign>.Filter.Where(record => record.Id.Equals(campaignId) &&
                                                                                      record.CompanyId.Equals(companyId)));
        }

        /// <summary>
        /// Delete All Campaigns by company ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task DeleteAllByCompanyId(ObjectId companyId)
        {
            await Collection.DeleteManyAsync(Builders<Campaign>.Filter.Eq(record => record.CompanyId, companyId));
        }

        /// <summary>
        /// Update Campaign
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task Update(Campaign record)
        {
            await Collection.ReplaceOneAsync(x => x.Id.Equals(record.Id), record);
        }

        /// <summary>
        /// Retrieve Company by company ID and campaign ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <returns>Campaign</returns>
        public async Task<Campaign> Retrieve(ObjectId companyId, ObjectId campaignId)
        {
            return await Collection.Find(record => record.Id.Equals(campaignId)
                                                && record.CompanyId.Equals(companyId))
                                            .FirstAsync();
        }

        /// <summary>
        /// Retrieve All Campaigns By company ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns>Campaign List</returns>
        public async Task<List<Campaign>> RetrieveAllByCompanyId(ObjectId companyId)
        {
            return await Collection.Find(record => record.CompanyId.Equals(companyId)).ToListAsync();
        }

        /// <summary>
        /// Retrieve Campaign by Code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Campaign</returns>
        public async Task<Campaign> RetrieveByCode(string code)
        {
            return await Collection.Find(record => record.CampaignCode.Equals(code)).FirstAsync();
        }
    }
}
