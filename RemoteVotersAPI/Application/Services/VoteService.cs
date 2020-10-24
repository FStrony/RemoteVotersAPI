using System;
using System.Collections.Generic;
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
    public class VoteService
    {
        private VoteRepository voteRepository;
        private IOptions<MongoDBConfig> mongoDBConfig;

        public VoteService(IOptions<MongoDBConfig> mongoDBConfig)
        {
            this.mongoDBConfig = mongoDBConfig;
            this.voteRepository = new VoteRepository(mongoDBConfig);
        }

        public async Task DeleteAllVotesByCompanyId(ObjectId companyId)
        {
            await voteRepository.DeleteAllByCompanyId(companyId);
        }
        
        public async Task DeleteAllVotesByCampaignId(ObjectId campaignId)
        {
            await voteRepository.DeleteAllByCapaignId(campaignId);
        }

        public async Task RegisterVote(VoteViewModel record)
        {
            await voteRepository.RegisterVote(Mapper.Map<Vote>(record));
        }

        public async Task<List<VoteViewModel>> RetrieveAllByCampaignId(ObjectId campaignId)
        {
            return Mapper.Map<List<VoteViewModel>>(await voteRepository.RetriveAllByCampaignId(campaignId));
        }

        public async Task<bool> hasAlreadyVoted(ObjectId campaignId, String voterIdentity)
        {
            return await voteRepository.hasAlreadyVoted(campaignId, voterIdentity);
        }
    }
}
