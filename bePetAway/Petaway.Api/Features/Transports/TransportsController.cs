using Petaway.Api.Features.Transports.ViewDisponibleTransports;
using Petaway.Api.Features.Transports.GetSpecificTransportByDbId;
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
        private readonly IGetSpecificTransportByDbIdCommandHandler getSpecificTransportByDbIdCommandHandler;

        public TransportsController(

            IViewDisponibleTransportsCommandHandler viewDisponibleTransportsCommandHandler,
            IGetSpecificTransportByDbIdCommandHandler getSpecificTransportByDbIdCommandHandler
            )

        {
            this.viewDisponibleTransportsCommandHandler = viewDisponibleTransportsCommandHandler;
            this.getSpecificTransportByDbIdCommandHandler = getSpecificTransportByDbIdCommandHandler;
        }

        [HttpGet("viewDisponibleTransports")]
        [Authorize("RescuerAccess")]
        public async Task<IActionResult> ViewDisponibleTransports(CancellationToken cancellationToken)
        {
            var transports = await viewDisponibleTransportsCommandHandler.HandleAsync(cancellationToken);

            return Ok(transports);
        }

        [HttpGet("getSpecificTransportByDbId")]
        [Authorize]
        public async Task<IActionResult> GetSpecificTransportByDbId([FromQuery] int transportId, CancellationToken cancellationToken)
        {
            var transport = await getSpecificTransportByDbIdCommandHandler.HandleAsync(transportId, cancellationToken);

            return Ok(transport);
        }
    }
}
