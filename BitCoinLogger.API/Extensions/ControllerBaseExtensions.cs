using Microsoft.AspNetCore.Mvc;
using BitcoinLogger.Api.Services.Shared;

namespace BitcoinLogger.Api.Extensions
{
    public static class ControllerBaseExtensions
    {   
        public static ActionResult FromServiceOperationResult<TData>(
            this ControllerBase controllerBase, ServiceOperationResult<TData> result
        )
        {
            if (!result.IsSuccessful)
            {
                return controllerBase.BadRequest(result.Errors);
            }
            return controllerBase.Ok(result.Data);
        }
        
        public static ActionResult FromServiceOperationResult(
            this ControllerBase controllerBase, ServiceOperationResult result
        )
        {
            if (!result.IsSuccessful)
            {
                return controllerBase.BadRequest(result.Errors);
            }
            return controllerBase.Ok();
        }
    }
}