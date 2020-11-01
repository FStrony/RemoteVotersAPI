using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace remotevotersapi.Controllers
{

    /// <summary>
    /// Vote Auth Mock Controller
    ///
    /// Author: FStrony
    /// </summary> 
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class VoteAuthMock : ControllerBase
    {
        /// <summary>
        /// POST Success Auth Mock
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        [HttpPost("success")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool AuthSuccess([FromBody] Dictionary<String, String> properties)
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
        public bool AuthFail([FromBody] IDictionary<String, String> properties)
        {
            return false;
        }
    }
}
