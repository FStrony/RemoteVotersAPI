using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using remotevotersapi.Application.Services;
using remotevotersapi.Application.ViewModel;
using remotevotersapi.Utils;

namespace remotevotersapi.Controllers
{
    /// <summary>
    /// Campaigns Controller
    ///
    /// Author: FStrony
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CampaignsController : ControllerBase
    {
        /// <value>campaign service</value>
        private CampaignService campaignService;

        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="campaignService"></param>
        public CampaignsController(CampaignService campaignService)
        {
            this.campaignService = campaignService;
        }

        /// <summary>
        /// POST Create Campaign
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{companyId}")]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task Create([FromRoute] string companyId, [FromBody] CampaignViewModel model)
        {
            model.CompanyId = ObjectId.Parse(companyId);
            await campaignService.CreateCampaign(model);
        }

        /// <summary>
        /// PUT Update Campaign
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<CampaignViewModel> RetrieveCampaign([FromRoute] string code)
        {
            return await campaignService.RetrieveCampaignByCode(code);
        }

        /// <summary>
        /// GET Retrieve all campaigns by company ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns>Campaign list</returns>
        [HttpGet("{companyId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<CampaignResultViewModel> RetrieveCampaignResults([FromRoute]string companyId, [FromRoute]string campaignId)
        {
            return await campaignService.RetrieveResults(new ObjectId(companyId), new ObjectId(campaignId));
        }
    }
}
