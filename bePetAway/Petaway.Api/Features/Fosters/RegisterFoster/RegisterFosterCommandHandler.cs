using Petaway.Core.Domain.Foster;

namespace Petaway.Api.Features.Fosters.RegisterFoster
{
    public class RegisterFosterCommandHandler : IRegisterFosterCommandHandler
    {
        private readonly IFostersRepository fostersRepository;

        public RegisterFosterCommandHandler(IFostersRepository fostersRepository)
        {
            this.fostersRepository = fostersRepository;
        }

        public Task HandleAsync(RegisterFosterCommand command, string identityId, CancellationToken cancellationToken)
            => fostersRepository.AddAsync(
                new RegisterFosterProfileCommand(identityId, command.Email, command.Name, command.PhoneNumber, command.Address, command.PhotoPath, command.MaxCapacity), 
                cancellationToken);
    }
    
}
