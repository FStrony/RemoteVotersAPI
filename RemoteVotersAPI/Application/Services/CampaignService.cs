using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using remotevotersapi.Application.ViewModel;
using remotevotersapi.Domain.Entities;
using remotevotersapi.Infra.Data.Repositories;

namespace remotevotersapi.Application.Services
{
    /// <summary>
    /// Campaign Service
    ///
    /// Author: FStrony
    /// </summary>
    public class CampaignService
    {
        /// <value>campaign repository</value>
        private CampaignRepository campaignRepository;

        /// <value>vote service</value>
        private VoteRepository voteRepository;

        // <value> company service</value>
        private CompanyRepository companyRepository;

        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="companyRepository"></param>
        /// <param name="voteRepository"></param>
        /// <param name="campaignRepository"></param>
        public CampaignService(CompanyRepository companyRepository, VoteRepository voteRepository, CampaignRepository campaignRepository)
        {
            this.campaignRepository = campaignRepository;
            this.voteRepository = voteRepository;
            this.companyRepository = companyRepository;
        }

        /// <summary>
        /// Delete Campaign by company ID and Campaign ID. It also deletes the votes from the campaign
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public async Task DeleteCampaign(ObjectId companyId, ObjectId campaignId)
        {
            await campaignRepository.Delete(companyId, campaignId);
            await voteRepository.DeleteAll(companyId, campaignId);
        }

        /// <summary>
        /// Create Campaign
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task CreateCampaign(CampaignViewModel record)
        {
            await campaignRepository.Create(Mapper.Map<Campaign>(record));
        }

        /// <summary>
        /// Update Campaign
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task UpdateCampaign(CampaignViewModel record)
        {
            await campaignRepository.Update(Mapper.Map<Campaign>(record));
        }

        /// <summary>
        /// Retrieve Campaign by company ID and campaign ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <returns>Campaign View Model</returns>
        public async Task<CampaignViewModel> RetrieveCampaign(ObjectId companyId, ObjectId campaignId)
        {
            return Mapper.Map<CampaignViewModel>(await campaignRepository.Retrieve(companyId, campaignId));
        }

        /// <summary>
        /// Retrieve Campaign by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Campaign View Model</returns>
        public async Task<CampaignViewModel> RetrieveCampaignByCode(string code)
        {
            CampaignViewModel campaign = Mapper.Map<CampaignViewModel>(await campaignRepository.RetrieveByCode(code));
            campaign.CompanyName = (await companyRepository.Retrieve(campaign.CompanyId)).CompanyName;

            return campaign;
        }

        /// <summary>
        /// Retrieve All campaigns by company ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns>Campaign List</returns>
        public async Task<List<CampaignViewModel>> RetrieveAllByCompanyId(ObjectId companyId)
        {
            return Mapper.Map<List<CampaignViewModel>>(await campaignRepository.RetrieveAllByCompanyId(companyId));
        }

        /// <summary>
        /// Fetch and process the campaign Results
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <returns>Campaign Result Information</returns>
        public async Task<CampaignResultViewModel> RetrieveResults(ObjectId companyId, ObjectId campaignId)
        {
            CampaignResultViewModel campaignResults = new CampaignResultViewModel();

            // Fetch the campaign
            CampaignViewModel campaign = await RetrieveCampaign(companyId, campaignId);
            if (campaign != null)
            {
                campaignResults.Campaign = campaign;

                foreach(CampaignOptionViewModel option in campaignResults.Campaign.CampaignOptions)
                {
                    // Count the votes for each campaign option
                    campaignResults.VoteSummary.Add(
                        new VoteSummaryViewModel() {
                            Description = option.Description,
                            OptionId = option.Id,
                            TotalVotes = await voteRepository.CountOptionTotalVotes(campaignResults.Campaign.CompanyId,
                                                                                 campaignResults.Campaign.Id,
                                                                                 option.Id)
                        }
                    );
                }
            }
            return campaignResults;
        }
    }
}
