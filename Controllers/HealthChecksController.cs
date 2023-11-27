using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieManagement.Api.Controllers
{
    [Route("api/hc")]
    [ApiController]

    public class healthChecksController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type=typeof(ErrorModel))]

        public async Task<ActionResult<string>> getAsync()
        {
            return "Healthy";
        }
    }
}