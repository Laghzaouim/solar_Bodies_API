using Microsoft.AspNetCore.Mvc;
using Fiver.Security.Bearer.Models.Token;
using Fiver.Security.Bearer.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Fiver.Security.Bearer.Controllers
{
    [Route("api/v1/[controller]")]
    [AllowAnonymous]
    public class TokenController : Controller
    {
        [HttpPost]
        public IActionResult Create([FromBody]LoginInputModel inputModel)
        {
            if (inputModel.Username != "james" || inputModel.Password != "bond")
                return Unauthorized();

            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("fiver-secret-key"))
                                .AddSubject("james bond")
                                .AddIssuer("Fiver.Security.Bearer")
                                .AddAudience("Fiver.Security.Bearer")
                                .AddClaim("MembershipId", "112")
                                .AddExpiry(1)
                                .Build();

            //return Ok(token);
            return Ok(token.Value);
        }
    }
}