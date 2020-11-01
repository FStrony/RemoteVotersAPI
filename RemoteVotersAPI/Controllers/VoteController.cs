using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using remotevotersapi.Application.Services;
using remotevotersapi.Application.ViewModel;
using remotevotersapi.Infra.ModelSettings;
using remotevotersapi.Utils;

namespace remotevotersapi.Controllers
{
    /// <summary>
    /// Vote Controller
    ///
    /// Author: FStrony
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class VoteController : ControllerBase
    {
        /// <value>vote service</value>
        private VoteService voteService;

        /// <value>MongoDB configs</value>
        private readonly IOptions<MongoDBConfig> _mongoDBConfig;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="mongoDBConfig"></param>
        public VoteController(IOptions<MongoDBConfig> mongoDBConfig)
        {
            _mongoDBConfig = mongoDBConfig;
            this.voteService = new VoteService(mongoDBConfig);
        }

        /// <summary>
        /// POST Register Vote
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task RegisterVote([FromBody]VoteRequestViewModel model)
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task ResetVotes([FromRoute]string companyId, [FromRoute]string campaignId)
        {
            await voteService.DeleteAllVotes(new ObjectId(companyId), new ObjectId(campaignId));
        }
    }
}
