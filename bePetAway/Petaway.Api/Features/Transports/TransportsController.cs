using Petaway.Api.Features.Transports.ViewDisponibleTransports;
using Petaway.Api.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Petaway.Api.Features.Transports
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransportsController : ControllerBase
    {
        private readonly IViewDisponibleTransportsCommandHandler viewDisponibleTransportsCommandHandler;
        
        public TransportsController(

            IViewDisponibleTransportsCommandHandler viewDisponibleTransportsCommandHandler
            )

        {
            this.viewDisponibleTransportsCommandHandler = viewDisponibleTransportsCommandHandler;
        }

        [HttpGet("viewDisponibleTransports")]
        [Authorize("RescuerAccess")]
        public async Task<IActionResult> ViewDisponibleTransports(CancellationToken cancellationToken)
        {
            var animals = await viewDisponibleTransportsCommandHandler.HandleAsync(cancellationToken);

            return Ok(animals);
        }
    }
}
