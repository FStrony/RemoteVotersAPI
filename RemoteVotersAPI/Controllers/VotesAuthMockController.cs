using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace remotevotersapi.Controllers
{

    /// <summary>
    /// Votes Auth Mock Controller
    ///
    /// Author: FStrony
    /// </summary> 
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    [Produces("application/json")]
    public class VotesAuthMockController : ControllerBase
    {
        /// <summary>
        /// POST Success Auth Mock
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        [HttpPost("success")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool AuthSuccess([FromBody] Dictionary<string, string> properties)
        {
            return true;
        }

        /// <summary>
        /// POST Fail Auth Mock
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        [HttpPost("fail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool AuthFail([FromBody] IDictionary<string, string> properties)
        {
            return false;
        }
    }
}
