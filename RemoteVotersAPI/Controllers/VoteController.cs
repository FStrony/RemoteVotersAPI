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
    [Route("vote")]
    public class VoteController : ControllerBase
    {
        private VoteService voteService;
        IOptions<MongoDBConfig> mongoDBConfig;

        public VoteController(IOptions<MongoDBConfig> mongoDBConfig)
        {
            this.mongoDBConfig = mongoDBConfig;
            this.voteService = new VoteService(mongoDBConfig);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task RegisterVote([FromBody]VoteViewModel model)
        {
            await voteService.RegisterVote(model);
        }

        [HttpDelete("{companyId}/reset-votes/{campaignId}")]
        public async Task ResetVotes([FromRoute]string companyId, [FromRoute]string campaignId)
        {
            await voteService.DeleteAllVotes(new ObjectId(companyId), new ObjectId(campaignId));
        }

        [HttpGet("{companyId}/get-results/{campaignId}")]
        public async Task<List<VoteViewModel>> RetrieveResults([FromRoute]string companyId, [FromRoute]string campaignId)
        {
            return await voteService.RetrieveResults(new ObjectId(companyId), new ObjectId(campaignId));
        }
    }
}
