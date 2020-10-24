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
    public class CompanyService
    {
        private CompanyRepository companyRepository;
        private CampaignService campaignService;
        private VoteService voteService;
        private IOptions<MongoDBConfig> mongoDBConfig;

        public CompanyService(IOptions<MongoDBConfig> mongoDBConfig)
        {
            this.mongoDBConfig = mongoDBConfig;
            this.companyRepository = new CompanyRepository(mongoDBConfig);
            this.campaignService = new CampaignService(mongoDBConfig);
            this.voteService = new VoteService(mongoDBConfig);
        }

        public async Task CreateCompany(CompanyViewModel record)
        {
            await companyRepository.Create(Mapper.Map<Company>(record));
        }

        public async Task UpdateCompany(CompanyViewModel record)
        {
            await companyRepository.Update(Mapper.Map<Company>(record));
        }

        public async Task DeleteCompany(ObjectId companyId)
        {
            await companyRepository.Delete(companyId);
            await campaignService.DeleteAllCampaignsByCompanyId(companyId);
            await voteService.DeleteAllVotesByCompanyId(companyId);
        }

        public async Task<CompanyViewModel> RetrieveCompany(ObjectId companyId)
        {
            return Mapper.Map<CompanyViewModel>(await companyRepository.Retrieve(companyId));
        }
    }
}
