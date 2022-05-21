using Petaway.Core.Domain.Rescuer;

namespace Petaway.Api.Features.Rescuers.RegisterRescuer
{
    public class RegisterRescuerCommandHandler : IRegisterRescuerCommandHandler
    {
        private readonly IRescuersRepository RescuersRepository;

        public RegisterRescuerCommandHandler(IRescuersRepository RescuersRepository)
        {
            this.RescuersRepository = RescuersRepository;
        }

        public Task HandleAsync(RegisterRescuerCommand command, string identityId, CancellationToken cancellationToken)
            => RescuersRepository.AddAsync(
                new RegisterRescuerProfileCommand(identityId, command.Email, command.Name, command.PhoneNumber, command.Address, command.PhotoPath), 
                cancellationToken);
    }
    
}
