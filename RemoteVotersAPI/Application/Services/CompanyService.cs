using System;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using remotevotersapi.Application.ViewModel;
using remotevotersapi.Domain.Entities;
using remotevotersapi.Infra.Data.Repositories;
using remotevotersapi.Utils;

namespace remotevotersapi.Application.Services
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
        private CampaignRepository campaignRepository;

        /// <value>vote service</value>
        private VoteRepository voteRepository;

        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="campaignRepository"></param>
        /// <param name="companyRepository"></param>
        /// <param name="voteRepository"></param>
        public CompanyService(CampaignRepository campaignRepository, CompanyRepository companyRepository, VoteRepository voteRepository)
        {
            this.companyRepository = companyRepository;
            this.campaignRepository = campaignRepository;
            this.voteRepository = voteRepository;
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
            await campaignRepository.DeleteAllByCompanyId(companyId);
            await voteRepository.DeleteAllByCompanyId(companyId);
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
