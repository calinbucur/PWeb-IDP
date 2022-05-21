using Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal;
using Petaway.Api.Features.OwnersAnimals.Animal.ViewOwnerAnimals;
using Petaway.Api.Features.OwnersAnimals.Animal.ViewRescuableAnimals;
using Petaway.Api.Features.OwnersAnimals.Owner.RegisterOwner;
using Petaway.Api.Authorization;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize("OwnerAccess")]
        public async Task<IActionResult> AddAnimalAsync(AddAnimalCommand command, CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            Console.WriteLine(identityId);
            await addAnimalCommandHandler.HandleAsync(command, identityId, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created);
        }

        /*[HttpPost("addAnimalByEmail")]
        //[Authorize] //(Policy = "OwnerAccess")
        public async Task<IActionResult> AddAnimalByEmailAsync(AddAnimalCommand command, CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }


            await addAnimalCommandHandler.HandleAsync(command, command.Email, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created);
        }*/


        [HttpPost("registerOwner")]
        [Authorize("OwnerAccess")] //(Policy = "")
        public async Task<IActionResult> RegisterOwnerAsync([FromBody] RegisterOwnerCommand command, CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();
            Console.WriteLine(identityId);

            if (identityId == null)
            {
                return Unauthorized();
            }

            await registerOwnerCommandHandler.HandleAsync(command, identityId, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpGet("viewOwnerAnimals")]
        [Authorize("OwnerAccess")]
        public async Task<IActionResult> ViewOwnerAnimals(CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            var animals = await viewOwnerAnimalsCommandHandler.HandleAsync(identityId, cancellationToken);

            return Ok(animals);
        }


        /*[HttpGet("viewOwnerAnimals")]
        public async Task<IActionResult> ViewOwnerAnimals(string ownerEmail, CancellationToken cancellationToken)
        {
            if (ownerEmail == null)
            {
                throw new ArgumentNullException(nameof(ownerEmail));
            }

            var animals = await viewOwnerAnimalsCommandHandler.HandleAsync(ownerEmail, cancellationToken);

            return Ok(animals);
        }
*/


        [HttpGet("viewRescuableAnimals")]
        [Authorize("FosterAccess")]
        public async Task<IActionResult> ViewRescuableAnimals( CancellationToken cancellationToken)
        {
            var animals = await viewRescuableAnimalsCommandHandler.HandleAsync(cancellationToken);

            return Ok(animals);
        }

        //        [HttpDelete("deleteBook/{id}")]
    }
}
