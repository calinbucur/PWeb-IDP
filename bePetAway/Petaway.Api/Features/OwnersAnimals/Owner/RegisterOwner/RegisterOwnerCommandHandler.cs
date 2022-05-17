using Petaway.Core.Domain.Owner;

namespace Petaway.Api.Features.OwnersAnimals.Owner.RegisterOwner
{
    public class RegisterOwnerCommandHandler : IRegisterOwnerCommandHandler
    {
        private readonly IOwnersAnimalsRepository OwnersAnimalsRepository;

        public RegisterOwnerCommandHandler(IOwnersAnimalsRepository OwnersAnimalsRepository)
        {
            this.OwnersAnimalsRepository = OwnersAnimalsRepository;
        }

        public Task HandleAsync(RegisterOwnerCommand command, CancellationToken cancellationToken)
            => OwnersAnimalsRepository.AddAsync(
                new RegisterOwnerProfileCommand(command.UserId, command.Email, command.Name, command.PhoneNumber, command.Address), 
                cancellationToken);
    }
    
}
