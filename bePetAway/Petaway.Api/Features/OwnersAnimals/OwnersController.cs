using Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal;
using Petaway.Api.Features.OwnersAnimals.Animal.ViewOwnerAnimals;
using Petaway.Api.Features.OwnersAnimals.Animal.ViewRescuableAnimals;
using Petaway.Api.Features.OwnersAnimals.Owner.RegisterOwner;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Petaway.Api.Features.Owners
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly IAddAnimalCommandHandler addAnimalCommandHandler;
        private readonly IRegisterOwnerCommandHandler registerOwnerCommandHandler;
        private readonly IViewOwnerAnimalsCommandHandler viewOwnerAnimalsCommandHandler;
        private readonly IViewRescuableAnimalsCommandHandler viewRescuableAnimalsCommandHandler;

        public OwnersController(
            IAddAnimalCommandHandler addAnimalCommandHandler,
            IRegisterOwnerCommandHandler registerOwnerCommandHandler,
            IViewOwnerAnimalsCommandHandler viewOwnerAnimalsCommandHandler,
            IViewRescuableAnimalsCommandHandler viewRescuableAnimalsCommandHandler
            )
        {
            this.addAnimalCommandHandler = addAnimalCommandHandler;
            this.registerOwnerCommandHandler = registerOwnerCommandHandler;
            this.viewOwnerAnimalsCommandHandler = viewOwnerAnimalsCommandHandler;
            this.viewRescuableAnimalsCommandHandler = viewRescuableAnimalsCommandHandler;
        }

        [HttpPost("addAnimal")]
        //[Authorize] //(Policy = "OwnerAccess")
        public async Task<IActionResult> AddBookAsync(AddAnimalCommand command, CancellationToken cancellationToken)
        {

            await addAnimalCommandHandler.HandleAsync(command, command.Email, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created);
        }


        [HttpPost("registerOwner")]
        //[Authorize] //(Policy = "OwnerAccess")
        public async Task<IActionResult> RegisterOwnerAsync(RegisterOwnerCommand command, CancellationToken cancellationToken)
        {

            await registerOwnerCommandHandler.HandleAsync(command, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpGet("viewOwnerAnimals")]
        public async Task<IActionResult> ViewOwnerAnimals(string ownerEmail, CancellationToken cancellationToken)
        {
            if (ownerEmail == null)
            {
                throw new ArgumentNullException(nameof(ownerEmail));
            }

            var animals = await viewOwnerAnimalsCommandHandler.HandleAsync(ownerEmail, cancellationToken);

            return Ok(animals);
        }

        [HttpGet("viewRescuableAnimals")]
        public async Task<IActionResult> ViewRescuableAnimals( CancellationToken cancellationToken)
        {
            var animals = await viewRescuableAnimalsCommandHandler.HandleAsync(cancellationToken);

            return Ok(animals);
        }

        //        [HttpDelete("deleteBook/{id}")]
    }
}
