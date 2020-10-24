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
    [ApiController]
    [Route("campaign")]
    public class CampaignController : ControllerBase
    {
        private CampaignService campaignService;
        IOptions<MongoDBConfig> mongoDBConfig;

        public CampaignController(IOptions<MongoDBConfig> mongoDBConfig)
        {
            this.mongoDBConfig = mongoDBConfig;
            this.campaignService = new CampaignService(mongoDBConfig);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task Create([FromBody] CampaignViewModel model)
        {
            await campaignService.CreateCampaign(model);
        }

        [HttpPut]
        [ValidateModelState]
        public async Task Update([FromBody] CampaignViewModel model)
        {
            await campaignService.UpdateCampaign(model);
        }

        [HttpGet("{companyId}/getCampaign/{campaignId}")]
        public async Task<CampaignViewModel> RetriveCampaign([FromRoute] string companyId, [FromRoute] string campaignId)
        {
            return await campaignService.RetrieveCampaign(new ObjectId(companyId), new ObjectId(campaignId));
        }

        [HttpGet("getCampaign/{code}")]
        public async Task<CampaignViewModel> RetriveCampaign([FromRoute] string code)
        {
            return await campaignService.RetrieveCampaignByCode(code);
        }

        [HttpGet("{companyId}/getAllCampaigns")]
        public async Task<List<CampaignViewModel>> RetrieveAllCompaignByCompany([FromRoute] string companyId)
        {
            return await campaignService.RetrieveAllByCompanyId(new ObjectId(companyId));
        }

        [HttpDelete("{companyId}/delete-campaign/{campaignId}")]
        public async Task Delete([FromRoute] string companyId, [FromRoute] string campaignId)
        {
            await campaignService.DeleteCampaign(new ObjectId(companyId), new ObjectId(campaignId));
        }
    }
}
