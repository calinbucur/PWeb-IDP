using Petaway.Core.Domain.Foster;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.Rescuers.FinishTransport
{
    public record FinishTransportCommand
    {
        public FinishTransportCommand(int transportId)
        {
            TransportId = transportId;
        }

        public int TransportId { get; set; }
    }
}
