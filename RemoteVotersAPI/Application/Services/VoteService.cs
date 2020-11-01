using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using remotevotersapi.Application.ViewModel;
using remotevotersapi.Domain.Entities;
using remotevotersapi.Infra.Data.Repositories;
using remotevotersapi.Infra.ModelSettings;
using remotevotersapi.Utils;

namespace remotevotersapi.Application.Services
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

        /// <value>campaign service</value>
        private CampaignService campaignService;

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
            this.campaignService = new CampaignService(mongoDBConfig);
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
        public async Task RegisterVote(VoteRequestViewModel record)
        {
            CampaignViewModel campaign = await campaignService.RetrieveCampaign(record.CompanyId, record.CampaignId);

            if(campaign == null)
            {
                throw new ArgumentException();
            }

            VoteViewModel vote = new VoteViewModel();
            vote.CampaignId = record.CampaignId;
            vote.CompanyId = record.CompanyId;
            vote.CampaignOptionId = record.CampaignOptionId;

            if (campaign.Auth)
            {
                string identity = string.Join(Environment.NewLine, record.VoterIdentity);
                vote.VoterIdentity = Encryptor.Encrypt(identity);

                if(await HasAlreadyVoted(vote.CampaignId, identity))
                {
                    throw new ApplicationException();
                }
            }

            await voteRepository.RegisterVote(Mapper.Map<Vote>(vote));
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
        /// <returns>bool</returns>∂
        private async Task<bool> HasAlreadyVoted(ObjectId campaignId, String voterIdentity)
        {
            return await voteRepository.HasAlreadyVoted(campaignId, voterIdentity);
        }

    }
}
