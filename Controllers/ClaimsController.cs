using System;
using Majestics.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Majestics.Data;
using Majestics.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using ActionResult = Majestics.Models.Common.ActionResult;

namespace Majestics.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimsController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ApplicationDbContext _dbContext;

        public ClaimsController(IHttpContextAccessor contextAccessor
                              , ApplicationDbContext dbContext)
        {
            _contextAccessor = contextAccessor;
            _dbContext = dbContext;
        }

        [Authorize("Admin")]
        [HttpPost("/api/Claims/Create")]
        public async Task<ActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                try
                {
                    _dbContext.UserClaims.Add(new IdentityUserClaim<string>
                    {
                        UserId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value,
                        ClaimType = ClaimTypes.Role,
                        ClaimValue = name
                    });

                    await _dbContext.SaveChangesAsync();

                    return Result.Ok("true");
                }
                catch (Exception ex)
                {
                    return Result.Error(ex);
                }
            }

            return Result.Error("false");
        }
    }

    public class ChangeRoleViewModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public IList<string> UserRoles { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
    }
}