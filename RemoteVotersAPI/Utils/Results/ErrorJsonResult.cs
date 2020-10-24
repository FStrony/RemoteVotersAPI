using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RemoteVotersAPI.Utils.Results
{
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
