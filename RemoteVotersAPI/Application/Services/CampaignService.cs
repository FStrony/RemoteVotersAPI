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
    public class CampaignService
    {
        private CampaignRepository campaignRepository;
        private VoteService voteService;
        private IOptions<MongoDBConfig> mongoDBConfig;

        public CampaignService(IOptions<MongoDBConfig> mongoDBConfig)
        {
            this.mongoDBConfig = mongoDBConfig;
            this.campaignRepository = new CampaignRepository(mongoDBConfig);
            this.voteService = new VoteService(mongoDBConfig);
        }

        public async Task DeleteAllCampaignsByCompanyId(ObjectId companyId)
        {
            await campaignRepository.DeleteAllByCompanyId(companyId);
        }

        public async Task DeleteCampaign(ObjectId companyId, ObjectId campaignId)
        {
            await campaignRepository.Delete(companyId, campaignId);
            await voteService.DeleteAllVotes(companyId, campaignId);
        }

        public async Task CreateCampaign(CampaignViewModel record)
        {
            await campaignRepository.Create(Mapper.Map<Campaign>(record));
        }

        public async Task UpdateCampaign(CampaignViewModel record)
        {
            await campaignRepository.Update(Mapper.Map<Campaign>(record));
        }

        public async Task<CampaignViewModel> RetrieveCampaign(ObjectId companyId, ObjectId campaignId)
        {
            return Mapper.Map<CampaignViewModel>(await campaignRepository.Retrieve(companyId, campaignId));
        }

        public async Task<CampaignViewModel> RetrieveCampaignByCode(string code)
        {
            return Mapper.Map<CampaignViewModel>(await campaignRepository.RetrieveByCode(code));
        }

        public async Task<List<CampaignViewModel>> RetrieveAllByCompanyId(ObjectId companyId)
        {
            return Mapper.Map<List<CampaignViewModel>>(await campaignRepository.RetriveAllByCompanyId(companyId));
        }
    }
}
