using Petaway.Core.Domain.Foster;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.Rescuers.TakeTransport
{
    public record TakeTransportCommand
    {
        public TakeTransportCommand(int transportId)
        {
            TransportId = transportId;
        }

        public int TransportId { get; set; }
    }
}
