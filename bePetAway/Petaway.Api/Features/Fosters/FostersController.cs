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
        //[Authorize] //(Policy = "FosterAccess")
        public async Task<IActionResult> RegisterOwnerAsync(RegisterFosterCommand command, CancellationToken cancellationToken)
        {

            await registerFosterCommandHandler.HandleAsync(command, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
