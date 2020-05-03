using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Majestics.Models.Contest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Majestics.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ContestController : ControllerBase
    {
        public ContestController()
        {
            
        }

        [HttpGet("Get")]
        [AllowAnonymous]
        public async Task<ContestViewModel> GetContests()
        {
            throw new NotImplementedException();
        }
    }
}
