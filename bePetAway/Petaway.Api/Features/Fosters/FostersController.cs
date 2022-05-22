using Petaway.Api.Features.Fosters.RegisterFoster;
using Petaway.Api.Features.Fosters.GetFoster;
using Petaway.Api.Features.Fosters.GetFosterExternal;
using Petaway.Api.Features.Fosters.UpdateFoster;
using Petaway.Api.Features.Fosters.ProposeTransfer;
using Petaway.Api.Features.Fosters.ViewFosterAnimals;
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
        private readonly IGetFosterExternalCommandHandler getFosterExternalCommandHandler;
        private readonly IUpdateFosterCommandHandler updateFosterCommandHandler;
        private readonly IProposeTransferCommandHandler proposeTransferCommandHandler;
        private readonly IViewFosterAnimalsCommandHandler viewFosterAnimalsCommandHandler;

        public FostersController(

            IRegisterFosterCommandHandler registerFosterCommandHandler,
            IGetFosterCommandHandler getFosterCommandHandler,
            IGetFosterExternalCommandHandler getFosterExternalCommandHandler,
            IUpdateFosterCommandHandler updateFosterCommandHandler,
            IProposeTransferCommandHandler proposeTransferCommandHandler,
            IViewFosterAnimalsCommandHandler viewFosterAnimalsCommandHandler
            )

        {
            this.registerFosterCommandHandler = registerFosterCommandHandler;
            this.getFosterCommandHandler = getFosterCommandHandler;
            this.getFosterExternalCommandHandler = getFosterExternalCommandHandler;
            this.updateFosterCommandHandler = updateFosterCommandHandler;
            this.proposeTransferCommandHandler = proposeTransferCommandHandler;
            this.viewFosterAnimalsCommandHandler = viewFosterAnimalsCommandHandler;
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

            var foster = await getFosterCommandHandler.HandleAsync(identityId, cancellationToken);

            return Ok(foster);
        }

        [HttpGet("getFosterExternal")]
        [Authorize]
        public async Task<IActionResult> GetOwnerExternal(string fosterEmail, CancellationToken cancellationToken)
        {
            var foster = await getFosterExternalCommandHandler.HandleAsync(fosterEmail, cancellationToken);

            return Ok(foster);
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

        [HttpPut("proposeTransfer")]
        [Authorize("FosterAccess")]
        public async Task<IActionResult> ProposeTransfer([FromBody] ProposeTransferCommand command, CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            await proposeTransferCommandHandler.HandleAsync(command, identityId, cancellationToken);

            return NoContent();
        }

        [HttpGet("viewFosterAnimals")]
        [Authorize("FosterAccess")]
        public async Task<IActionResult> ViewFosterAnimals(CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            var animals = await viewFosterAnimalsCommandHandler.HandleAsync(identityId, cancellationToken);

            return Ok(animals);
        }

    }
}
