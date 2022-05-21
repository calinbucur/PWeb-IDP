using Petaway.Api.Authorization;
using Petaway.Api.Features.Fosters.RegisterFoster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Petaway.Api.Features.Fosters
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FostersController : ControllerBase
    {
        private readonly IRegisterFosterCommandHandler registerFosterCommandHandler;

        public FostersController(

            IRegisterFosterCommandHandler registerFosterCommandHandler
            )

        {
            this.registerFosterCommandHandler = registerFosterCommandHandler;
        }

        [HttpPost("registerFoster")]
        [Authorize("FosterAccess")]
        public async Task<IActionResult> RegisterFosterAsync([FromBody] RegisterFosterCommand command, CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            await registerFosterCommandHandler.HandleAsync(command, identityId, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
