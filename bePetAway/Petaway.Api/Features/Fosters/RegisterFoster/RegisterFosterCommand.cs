using Petaway.Core.Domain.Foster;
using System.Text.Json.Serialization;

namespace Petaway.Api.Features.Fosters.RegisterFoster
{
    public record RegisterFosterCommand : RegisterFosterProfileCommand
    {
        public RegisterFosterCommand(string email, string name, string phoneNumber, string address, string photoPath, int maxCapacity) : base(email, name, phoneNumber, address, photoPath, maxCapacity)
        {

        }
    }
}
