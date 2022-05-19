﻿using Petaway.Core.Domain.Rescuer;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.Rescuers.RegisterRescuer
{
    public record RegisterRescuerCommand : RegisterRescuerProfileCommand
    {
        public RegisterRescuerCommand(string email, string name, string phoneNumber, string address, string photoPath) : base(email, name, phoneNumber, address, photoPath)
        {

        }
    }
}