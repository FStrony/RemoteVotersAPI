using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using RemoteVotersAPI.Application.ViewModel;
using RemoteVotersAPI.Domain.Entities;
using RemoteVotersAPI.Infra.Data.Repositories;
using RemoteVotersAPI.Infra.ModelSettings;

namespace RemoteVotersAPI.Application.Services
{
    /// <summary>
    /// Vote Service
    ///
    /// Author: FStrony
    /// </summary>
    public class VoteService
    {
        /// <value>vote repository</value>
        private VoteRepository voteRepository;

        /// <value>MongoDB configs</value>
        private readonly IOptions<MongoDBConfig> _mongoDBConfig;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="mongoDBConfig"></param>
        public VoteService(IOptions<MongoDBConfig> mongoDBConfig)
        {
            _mongoDBConfig = mongoDBConfig;
            this.voteRepository = new VoteRepository(mongoDBConfig);
        }

        /// <summary>
        /// Delete All Votes By Company ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task DeleteAllVotesByCompanyId(ObjectId companyId)
        {
            await voteRepository.DeleteAllByCompanyId(companyId);
        }

        /// <summary>
        /// Delete All Votes By Company ID and Campaign ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public async Task DeleteAllVotes(ObjectId companyId, ObjectId campaignId)
        {
            await voteRepository.DeleteAll(companyId, campaignId);
        }

        /// <summary>
        /// Register Vote
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task RegisterVote(VoteViewModel record)
        {
            await voteRepository.RegisterVote(Mapper.Map<Vote>(record));
        }

        /// <summary>
        /// Count the Option's total of votes received
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <param name="optionId"></param>
        /// <returns>Total of votes received</returns>
        public async Task<long> CountOptionTotalVotes(ObjectId companyId, ObjectId campaignId, ObjectId optionId)
        {
            return await voteRepository.CountOptionTotalVotes(companyId, campaignId, optionId);
        }

        /// <summary>
        /// Checks if the voter already voted in the campaign
        /// </summary>
        /// <param name="campaignId"></param>
        /// <param name="voterIdentity"></param>
        /// <returns>bool</returns>
        public async Task<bool> HasAlreadyVoted(ObjectId campaignId, String voterIdentity)
        {
            return await voteRepository.HasAlreadyVoted(campaignId, voterIdentity);
        }
    }
}
