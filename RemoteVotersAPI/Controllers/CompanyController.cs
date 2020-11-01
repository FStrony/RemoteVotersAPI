using System;
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
    /// Company Controller
    ///
    /// Author: FStrony
    /// </summary> 
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CompanyController : ControllerBase
    {
        /// <value>company service</value>
        private CompanyService companyService;

        /// <value>MongoDB configs</value>
        private readonly IOptions<MongoDBConfig> _mongoDBConfig;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="mongoDBConfig"></param>
        public CompanyController(IOptions<MongoDBConfig> mongoDBConfig)
        {
            _mongoDBConfig = mongoDBConfig;
            this.companyService = new CompanyService(mongoDBConfig);
        }

        /// <summary>
        /// POST Create Company
        /// </summary>
        /// <param name="companyModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task Create([FromBody] CompanyViewModel companyModel)
        {
            await companyService.CreateCompany(companyModel);
        }

        /// <summary>
        /// PUT Update Company
        /// </summary>
        /// <param name="companyModel"></param>
        /// <returns></returns>
        [HttpPut]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task Update([FromBody] CompanyViewModel companyModel)
        {
            await companyService.UpdateCompany(companyModel);
        }

        /// <summary>
        /// DELETE delete company By company ID, it also deletes all the campaigns and votes from the company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task Delete([FromRoute] string id)
        {
            await companyService.DeleteCompany(new ObjectId(id));
        }

        /// <summary>
        /// GET Retrieve company information
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Company Information</returns>
        [HttpGet("getCompany/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<CompanyViewModel> RetrieveByCompanyId([FromRoute] string id)
        {
            return await companyService.RetrieveCompany(new ObjectId(id));
        }
    }
}
