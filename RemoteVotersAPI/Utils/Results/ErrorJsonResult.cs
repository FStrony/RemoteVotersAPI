using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace remotevotersapi.Utils.Results
{
    /// <summary>
    /// Helper class - JSON Error Model
    /// 
    /// Author: FStrony
    /// </summary>
    public class ErrorJsonResult : JsonResult
    {
        public ErrorJsonResult(IEnumerable<ErrorValidate> errors)
                   : base(new
                   {
                       Success = false,
                       Errors = errors
                   })
        {
        }

        public ErrorJsonResult(IEnumerable<ErrorValidate> errors, JsonSerializerSettings serializerSettings)
            : base(new
            {
                Success = false,
                Errors = errors
            }, serializerSettings)
        {
        }
    }
}
