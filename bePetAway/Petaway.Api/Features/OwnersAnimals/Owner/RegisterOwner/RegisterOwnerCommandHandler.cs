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

        public Task HandleAsync(RegisterOwnerCommand command, string identityId, CancellationToken cancellationToken)
            => OwnersAnimalsRepository.AddAsync(
                new RegisterOwnerProfileCommand(identityId, command.Email, command.Name, command.PhoneNumber, command.Address, command.PhotoPath), 
                cancellationToken);
    }
    
}
