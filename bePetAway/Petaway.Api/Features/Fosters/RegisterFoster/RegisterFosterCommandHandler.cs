using Petaway.Core.Domain.Foster;

namespace Petaway.Api.Features.Fosters.RegisterFoster
{
    public class RegisterFosterCommandHandler : IRegisterFosterCommandHandler
    {
        private readonly IFostersRepository FostersRepository;

        public RegisterFosterCommandHandler(IFostersRepository FostersRepository)
        {
            this.FostersRepository = FostersRepository;
        }

        public Task HandleAsync(RegisterFosterCommand command, CancellationToken cancellationToken)
            => FostersRepository.AddAsync(
                new RegisterFosterProfileCommand(command.IdentityId, command.Email, command.Name, command.PhoneNumber, command.Address, command.PhotoPath, command.MaxCapacity), 
                cancellationToken);
    }
    
}
