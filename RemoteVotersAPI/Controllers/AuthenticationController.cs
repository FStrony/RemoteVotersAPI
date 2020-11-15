using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using remotevotersapi.Application.Services;
using remotevotersapi.Application.ViewModel;
using remotevotersapi.Utils;

namespace remotevotersapi.Controllers
{
    /// <summary>
    /// Authentication Controller
    ///
    /// Author: FStrony
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class AuthenticationController : ControllerBase
    {
        /// <value>authentication service</value>
        private AuthService authService;

        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="authService"></param>
        public AuthenticationController(AuthService authService)
        {
            this.authService = authService;
        }

        /// <summary>
        /// POST Authenticate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModelState]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<string> Authenticate([FromBody] AuthenticationViewModel model)
        {
            return await authService.Authenticate(model);
        }
    }
}
