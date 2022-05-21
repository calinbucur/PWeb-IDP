using Petaway.Api.Features.Rescuers.RegisterRescuer;
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

        public RescuersController(

            IRegisterRescuerCommandHandler registerRescuerCommandHandler
            )

        {
            this.registerRescuerCommandHandler = registerRescuerCommandHandler;
        }

        [HttpPost("registerRescuer")]
        [Authorize("RescuerAccess")]
        public async Task<IActionResult> RegisterOwnerAsync(RegisterRescuerCommand command, CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            await registerRescuerCommandHandler.HandleAsync(command, identityId, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
