using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using RemoteVotersAPI.Application.ViewModel;
using RemoteVotersAPI.Domain.Entities;
using RemoteVotersAPI.Infra.Data.Repositories;
using RemoteVotersAPI.Infra.ModelSettings;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Application.Services
{
    /// <summary>
    /// Company Service
    ///
    /// Author: FStrony
    /// </summary>
    public class CompanyService
    {
        /// <value>company repository</value>
        private CompanyRepository companyRepository;

        /// <value>campaign service</value>
        private CampaignService campaignService;

        /// <value>vote service</value>
        private VoteService voteService;

        /// <value>MongoDB configs</value>
        private readonly IOptions<MongoDBConfig> _mongoDBConfig;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="mongoDBConfig"></param>
        public CompanyService(IOptions<MongoDBConfig> mongoDBConfig)
        {
            _mongoDBConfig = mongoDBConfig;
            this.companyRepository = new CompanyRepository(mongoDBConfig);
            this.campaignService = new CampaignService(mongoDBConfig);
            this.voteService = new VoteService(mongoDBConfig);
        }

        /// <summary>
        /// Create Company
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task CreateCompany(CompanyViewModel record)
        {
            record.Password = Encryptor.Encrypt(record.Password);
            await companyRepository.Create(Mapper.Map<Company>(record));
        }

        /// <summary>
        /// Update Company
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task UpdateCompany(CompanyViewModel record)
        {
            CompanyViewModel company = await RetrieveCompany(record.Id);

            if (String.IsNullOrEmpty(record.Password)) {
                record.Password = company.Password;
            }
            else
            {
                record.Password = Encryptor.Encrypt(record.Password);
            }

            await companyRepository.Update(Mapper.Map<Company>(record));
        }

        /// <summary>
        /// Delete Company by CompanyID
        /// And delete all the campaigns and votes related to the company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task DeleteCompany(ObjectId companyId)
        {
            await companyRepository.Delete(companyId);
            await campaignService.DeleteAllCampaignsByCompanyId(companyId);
            await voteService.DeleteAllVotesByCompanyId(companyId);
        }

        /// <summary>
        /// Retrieve Company Information
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns>Campany View Model</returns>
        public async Task<CompanyViewModel> RetrieveCompany(ObjectId companyId)
        {
            return Mapper.Map<CompanyViewModel>(await companyRepository.Retrieve(companyId));
        }
    }
}
