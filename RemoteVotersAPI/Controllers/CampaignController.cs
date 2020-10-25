using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using RemoteVotersAPI.Application.Services;
using RemoteVotersAPI.Application.ViewModel;
using RemoteVotersAPI.Infra.ModelSettings;
using RemoteVotersAPI.Utils;

namespace RemoteVotersAPI.Controllers
{
    /// <summary>
    /// Campaign Controller
    ///
    /// Author: FStrony
    /// </summary>
    [ApiController]
    [Route("campaign")]
    public class CampaignController : ControllerBase
    {
        /// <value>campaign service</value>
        private CampaignService campaignService;

        /// <value>MongoDB configs</value>
        IOptions<MongoDBConfig> mongoDBConfig;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="mongoDBConfig"></param>
        public CampaignController(IOptions<MongoDBConfig> mongoDBConfig)
        {
            this.mongoDBConfig = mongoDBConfig;
            this.campaignService = new CampaignService(mongoDBConfig);
        }

        /// <summary>
        /// POST Create Campaign
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModelState]
        public async Task Create([FromBody] CampaignViewModel model)
        {
            await campaignService.CreateCampaign(model);
        }

        /// <summary>
        /// PUT Update Campaign
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ValidateModelState]
        public async Task Update([FromBody] CampaignViewModel model)
        {
            await campaignService.UpdateCampaign(model);
        }

        /// <summary>
        /// GET Retrieve campaign by company ID and campaign ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <returns>Campaign</returns>
        [HttpGet("{companyId}/getCampaign/{campaignId}")]
        public async Task<CampaignViewModel> RetrieveCampaign([FromRoute] string companyId, [FromRoute] string campaignId)
        {
            return await campaignService.RetrieveCampaign(new ObjectId(companyId), new ObjectId(campaignId));
        }

        /// <summary>
        /// GET Retrieve Campaign by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Campaign</returns>
        [HttpGet("getCampaign/{code}")]
        public async Task<CampaignViewModel> RetrieveCampaign([FromRoute] string code)
        {
            return await campaignService.RetrieveCampaignByCode(code);
        }

        /// <summary>
        /// GET Retrieve all campaigns by company ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns>Campaign list</returns>
        [HttpGet("{companyId}/getAllCampaigns")]
        public async Task<List<CampaignViewModel>> RetrieveAllCompaignByCompany([FromRoute] string companyId)
        {
            return await campaignService.RetrieveAllByCompanyId(new ObjectId(companyId));
        }

        /// <summary>
        /// DELETE delete Campaign by company ID and campaign ID, It also deletes all the votes from that campaign
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        [HttpDelete("{companyId}/delete-campaign/{campaignId}")]
        public async Task Delete([FromRoute] string companyId, [FromRoute] string campaignId)
        {
            await campaignService.DeleteCampaign(new ObjectId(companyId), new ObjectId(campaignId));
        }

        /// <summary>
        /// GET Retrieve the Campaign Results by company ID and Campaign ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <returns>Campaign Results Information</returns>
        [HttpGet("{companyId}/get-campaign-results/{campaignId}")]
        public async Task<CampaignResultViewModel> RetrieveCampaignResults([FromRoute]string companyId, [FromRoute]string campaignId)
        {
            return await campaignService.RetrieveResults(new ObjectId(companyId), new ObjectId(campaignId));
        }
    }
}
