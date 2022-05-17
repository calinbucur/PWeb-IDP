﻿using Petaway.Core.DataModel;
using Petaway.Core.SeedWork;
using Petaway.Core.Domain.Transport;

namespace Petaway.Core.Domain.Rescuer
{
    public class RescuersDomain : DomainOfAggregate<Rescuers>
    {
        public RescuersDomain(Rescuers aggregate) : base(aggregate)
        {
        }

        public void UpdateRescuerAddress(string address)
        {
            aggregate.Address = address;
        }

        public void UpdateRescuerProfile(string ownerId, string email, string name, string phoneNumber, string address, string password)
        {
            aggregate.UserId = ownerId;
            aggregate.Email = email;
            aggregate.Name = name;
            aggregate.PhoneNumber = phoneNumber;
            aggregate.Address = address;
        }

        public RescuerAcceptTransportEvent AcceptTransport(int transportId)
        {
            if (aggregate.MaxCapacity < aggregate.CrtCapacity + 1)
            {
                throw new RescuerFullCapacityException(aggregate.Id);
            }

            aggregate.CrtTransportId = transportId;
            return new RescuerAcceptTransportEvent(transportId);
        }
        public RescuerRejectTransportEvent RejectTransport(int transportId)
        {
            return new RescuerRejectTransportEvent(transportId);
        }

        public RescuerFinishTransportEvent FinishTransport(int transportId)
        {
            aggregate.CrtCapacity = 0;
            return new RescuerFinishTransportEvent(transportId);
        }

    }
}
