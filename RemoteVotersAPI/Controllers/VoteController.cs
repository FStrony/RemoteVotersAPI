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
    /// Vote Controller
    ///
    /// Author: FStrony
    /// </summary>
    [ApiController]
    [Route("vote")]
    public class VoteController : ControllerBase
    {
        /// <value>vote service</value>
        private VoteService voteService;

        /// <value>MongoDB configs</value>
        IOptions<MongoDBConfig> mongoDBConfig;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="mongoDBConfig"></param>
        public VoteController(IOptions<MongoDBConfig> mongoDBConfig)
        {
            this.mongoDBConfig = mongoDBConfig;
            this.voteService = new VoteService(mongoDBConfig);
        }

        /// <summary>
        /// POST Register Vote
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModelState]
        public async Task RegisterVote([FromBody]VoteViewModel model)
        {
            await voteService.RegisterVote(model);
        }

        /// <summary>
        /// DELETE Reset Votes - Delete all votes by campaign ID and company ID
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        [HttpDelete("{companyId}/reset-votes/{campaignId}")]
        public async Task ResetVotes([FromRoute]string companyId, [FromRoute]string campaignId)
        {
            await voteService.DeleteAllVotes(new ObjectId(companyId), new ObjectId(campaignId));
        }

        /// <summary>
        /// GET Campaign Result
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="campaignId"></param>
        /// <returns>Campaign Results</returns>
        [HttpGet("{companyId}/get-results/{campaignId}")]
        public async Task<List<VoteViewModel>> RetrieveResults([FromRoute]string companyId, [FromRoute]string campaignId)
        {
            return await voteService.RetrieveResults(new ObjectId(companyId), new ObjectId(campaignId));
        }
    }
}
