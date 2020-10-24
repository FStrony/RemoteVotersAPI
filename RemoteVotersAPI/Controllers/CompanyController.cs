using System;
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
    [Route("company")]
    public class CompanyController : ControllerBase
    {
        private CompanyService companyService;
        IOptions<MongoDBConfig> mongoDBConfig;

        public CompanyController(IOptions<MongoDBConfig> mongoDBConfig)
        {
            this.mongoDBConfig = mongoDBConfig;
            this.companyService = new CompanyService(mongoDBConfig);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task Create([FromBody] CompanyViewModel companyModel)
        {
            await companyService.CreateCompany(companyModel);
        }

        [HttpPut]
        [ValidateModelState]
        public async Task Update([FromBody] CompanyViewModel companyModel)
        {
            await companyService.UpdateCompany(companyModel);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] string id)
        {
            await companyService.DeleteCompany(new ObjectId(id));
        }

        [HttpGet("getCompany/{id}")]
        public async Task<CompanyViewModel> RetrieveByCompanyId([FromRoute] string id)
        {
            return await companyService.RetrieveCompany(new ObjectId(id));
        }
    }
}
