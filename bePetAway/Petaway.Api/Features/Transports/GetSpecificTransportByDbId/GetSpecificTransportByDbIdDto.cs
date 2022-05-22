using Petaway.Core.DataModel;

namespace Petaway.Api.Features.Transports.GetSpecificTransportByDbId
{
    public record GetSpecificTransportByDbIdDto
    {
        public GetSpecificTransportByDbIdDto(Core.DataModel.Transports transport)
        {
            TransportId = transport.Id;
            //RejectedByOwnerOrFoster = rejectedByOwnerOrFoster
            IsFinished = transport.IsFinished;
            OwnerEmail = transport.OwnerEmail;
            AnimalId = transport.AnimalId;
            FosterEmail = transport.FosterEmail;
            RescuerEmail = transport.RescuerEmail;
            StartPoint = transport.StartPoint;
            EndPoint = transport.EndPoint;
        }

        public int TransportId { get; set; }

        //public bool RejectedByOwnerOrFoster { get; set; } = false;
        public bool IsFinished { get; set; }
        public string OwnerEmail { get; set; }
        public int AnimalId { get; set; }
        public string FosterEmail { get; set; }
        public string RescuerEmail { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
    }
}
