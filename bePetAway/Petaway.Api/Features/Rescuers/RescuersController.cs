using Petaway.Api.Features.Rescuers.RegisterRescuer;
using Petaway.Api.Features.Rescuers.GetRescuer;
using Petaway.Api.Features.Rescuers.GetRescuerExternal;
using Petaway.Api.Features.Rescuers.UpdateRescuer;
using Petaway.Api.Features.Rescuers.ViewRescuerFinishedTransports;
using Petaway.Api.Features.Rescuers.ViewRescuerPendingTransports;
using Petaway.Api.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Petaway.Api.Features.Rescuers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RescuersController : ControllerBase
    {
        private readonly IRegisterRescuerCommandHandler registerRescuerCommandHandler;
        private readonly IGetRescuerCommandHandler getRescuerCommandHandler;
        private readonly IGetRescuerExternalCommandHandler getRescuerExternalCommandHandler;
        private readonly IUpdateRescuerCommandHandler updateRescuerCommandHandler;
        private readonly IViewRescuerFinishedTransportsCommandHandler viewRescuerFinishedTransportsCommandHandler;
        private readonly IViewRescuerPendingTransportsCommandHandler viewRescuerPendingTransportsCommandHandler;
        public RescuersController(

            IRegisterRescuerCommandHandler registerRescuerCommandHandler,
            IGetRescuerCommandHandler getRescuerCommandHandler,
            IGetRescuerExternalCommandHandler getRescuerExternalCommandHandler,
            IUpdateRescuerCommandHandler updateRescuerCommandHandler,
            IViewRescuerFinishedTransportsCommandHandler viewRescuerFinishedTransportsCommandHandler,
            IViewRescuerPendingTransportsCommandHandler viewRescuerPendingTransportsCommandHandler

            )

        {
            this.registerRescuerCommandHandler = registerRescuerCommandHandler;
            this.getRescuerCommandHandler = getRescuerCommandHandler;
            this.getRescuerExternalCommandHandler = getRescuerExternalCommandHandler;
            this.updateRescuerCommandHandler = updateRescuerCommandHandler;
            this.viewRescuerFinishedTransportsCommandHandler = viewRescuerFinishedTransportsCommandHandler;
            this.viewRescuerPendingTransportsCommandHandler = viewRescuerPendingTransportsCommandHandler;
        }

        [HttpPost("registerRescuer")]
        [Authorize("RescuerAccess")]
        public async Task<IActionResult> RegisterRescuerAsync(RegisterRescuerCommand command, CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            await registerRescuerCommandHandler.HandleAsync(command, identityId, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpGet("getRescuer")]
        [Authorize("RescuerAccess")]
        public async Task<IActionResult> GetRescuer(CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            var rescuer = await getRescuerCommandHandler.HandleAsync(identityId, cancellationToken);

            return Ok(rescuer);
        }

        [HttpGet("getRescuerExternal")]
        [Authorize]
        public async Task<IActionResult> GetOwnerExternal(string rescuerEmail, CancellationToken cancellationToken)
        {
            var rescuer = await getRescuerExternalCommandHandler.HandleAsync(rescuerEmail, cancellationToken);

            return Ok(rescuer);
        }

        [HttpPut("updateRescuer")]
        [Authorize("RescuerAccess")]
        public async Task<IActionResult> UpdateRescuer([FromBody] UpdateRescuerDto command, CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            await updateRescuerCommandHandler.HandleAsync(command, identityId, cancellationToken);

            return NoContent();
        }

        [HttpGet("viewRescuerFinishedTransports")]
        [Authorize("RescuerAccess")]
        public async Task<IActionResult> ViewRescuerFinishedTransports(CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            var transports = await viewRescuerFinishedTransportsCommandHandler.HandleAsync(identityId, cancellationToken);

            return Ok(transports);
        }

        [HttpGet("viewRescuerPendingTransports")]
        [Authorize("RescuerAccess")]
        public async Task<IActionResult> ViewRescuerPendingTransports(CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            var transports = await viewRescuerPendingTransportsCommandHandler.HandleAsync(identityId, cancellationToken);

            return Ok(transports);
        }
    }
}
