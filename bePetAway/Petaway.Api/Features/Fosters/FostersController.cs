using Petaway.Api.Features.Fosters.RegisterFoster;
using Petaway.Api.Features.Fosters.GetFoster;
using Petaway.Api.Features.Fosters.UpdateFoster;
using Petaway.Api.Authorization;
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
        private readonly IGetFosterCommandHandler getFosterCommandHandler;
        private readonly IUpdateFosterCommandHandler updateFosterCommandHandler;

        public FostersController(

            IRegisterFosterCommandHandler registerFosterCommandHandler,
            IGetFosterCommandHandler getFosterCommandHandler,
            IUpdateFosterCommandHandler updateFosterCommandHandler
            )

        {
            this.registerFosterCommandHandler = registerFosterCommandHandler;
            this.getFosterCommandHandler = getFosterCommandHandler;
            this.updateFosterCommandHandler = updateFosterCommandHandler;
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

        [HttpGet("getFoster")]
        [Authorize("FosterAccess")]
        public async Task<IActionResult> GetFoster(CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            var animals = await getFosterCommandHandler.HandleAsync(identityId, cancellationToken);

            return Ok(animals);
        }

        [HttpPut("updateFoster")]
        [Authorize("FosterAccess")]
        public async Task<IActionResult> UpdateFoster([FromBody] UpdateFosterDto command, CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            await updateFosterCommandHandler.HandleAsync(command, identityId, cancellationToken);

            return NoContent();
        }


    }
}
