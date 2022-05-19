using Petaway.Api.Features.Rescuers.RegisterRescuer;
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
        //[Authorize] //(Policy = "RescuerAccess")
        public async Task<IActionResult> RegisterOwnerAsync(RegisterRescuerCommand command, CancellationToken cancellationToken)
        {

            await registerRescuerCommandHandler.HandleAsync(command, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
