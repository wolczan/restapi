using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MovieManagement.Api.Models;

namespace MovieManagement.Api.Controllers
{
    [Route("api/hc")]
    [ApiController]

    public class HealthChecksController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type=typeof(ErrorModel))]

        [HttpGet("async")]
        public async Task<ActionResult<string>> getAsync()
        {
        
        var result = await someAsyncOperation();
        return result;
        }
        
        [HttpGet("standard")]   
        public ActionResult<string> Get()
        {
            return "Healthy";
        }
        private async Task<string> someAsyncOperation()
        {
            // Placeholder for an asynchronous operation
            await Task.Delay(1000); // Simulating async work
            return "Result of async operation";
            
        }


    }
}