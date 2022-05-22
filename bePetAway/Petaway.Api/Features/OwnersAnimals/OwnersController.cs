using Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal;
using Petaway.Api.Features.OwnersAnimals.Animal.ViewOwnerAnimals;
using Petaway.Api.Features.OwnersAnimals.Animal.ViewRescuableAnimals;
using Petaway.Api.Features.OwnersAnimals.Animal.GetOwnerSpecificAnimal;
using Petaway.Api.Features.OwnersAnimals.Animal.GetOwnerSpecificAnimalByDbId;
using Petaway.Api.Features.OwnersAnimals.Animal.UpdateOwnerSpecificAnimal;
using Petaway.Api.Features.OwnersAnimals.Owner.RegisterOwner;
using Petaway.Api.Features.OwnersAnimals.Owner.GetOwner;
using Petaway.Api.Features.OwnersAnimals.Owner.GetOwnerExternal;
using Petaway.Api.Features.OwnersAnimals.Owner.UpdateOwner;
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
        private readonly IGetOwnerCommandHandler getOwnerCommandHandler;
        private readonly IUpdateOwnerCommandHandler updateOwnerCommandHandler;
        private readonly IViewOwnerAnimalsCommandHandler viewOwnerAnimalsCommandHandler;
        private readonly IViewRescuableAnimalsCommandHandler viewRescuableAnimalsCommandHandler;
        private readonly IGetOwnerExternalCommandHandler getOwnerExternalCommandHandler;
        private readonly IGetOwnerSpecificAnimalCommandHandler getOwnerSpecificAnimalCommandHandler;
        private readonly IGetOwnerSpecificAnimalByDbIdCommandHandler getOwnerSpecificAnimalByDbIdCommandHandler;
        private readonly IUpdateOwnerSpecificAnimalCommandHandler updateOwnerSpecificAnimalCommandHandler;

        public OwnersController(
            IAddAnimalCommandHandler addAnimalCommandHandler,
            IRegisterOwnerCommandHandler registerOwnerCommandHandler,
            IUpdateOwnerCommandHandler updateOwnerCommandHandler,
            IViewOwnerAnimalsCommandHandler viewOwnerAnimalsCommandHandler,
            IViewRescuableAnimalsCommandHandler viewRescuableAnimalsCommandHandler,
            IGetOwnerCommandHandler getOwnerCommandHandler,
            IGetOwnerExternalCommandHandler getOwnerExternalCommandHandler,
            IGetOwnerSpecificAnimalCommandHandler getOwnerSpecificAnimalCommandHandler,
            IGetOwnerSpecificAnimalByDbIdCommandHandler getOwnerSpecificAnimalByDbIdCommandHandler,
            IUpdateOwnerSpecificAnimalCommandHandler updateOwnerSpecificAnimalCommandHandler
            )
        {
            this.addAnimalCommandHandler = addAnimalCommandHandler;
            this.registerOwnerCommandHandler = registerOwnerCommandHandler;
            this.updateOwnerCommandHandler = updateOwnerCommandHandler;
            this.viewOwnerAnimalsCommandHandler = viewOwnerAnimalsCommandHandler;
            this.viewRescuableAnimalsCommandHandler = viewRescuableAnimalsCommandHandler;
            this.getOwnerCommandHandler = getOwnerCommandHandler;
            this.getOwnerExternalCommandHandler = getOwnerExternalCommandHandler;
            this.getOwnerSpecificAnimalCommandHandler = getOwnerSpecificAnimalCommandHandler;
            this.getOwnerSpecificAnimalByDbIdCommandHandler = getOwnerSpecificAnimalByDbIdCommandHandler;
            this.updateOwnerSpecificAnimalCommandHandler = updateOwnerSpecificAnimalCommandHandler;
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

        [HttpPost("registerOwner")]
        [Authorize("OwnerAccess")]
        public async Task<IActionResult> RegisterOwnerAsync([FromBody] RegisterOwnerCommand command, CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

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

        [HttpGet("getOwner")]
        [Authorize("OwnerAccess")]
        public async Task<IActionResult> GetOwner(CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            var owner = await getOwnerCommandHandler.HandleAsync(identityId, cancellationToken);

            return Ok(owner);
        }

        [HttpGet("getOwnerExternal")]
        [Authorize]
        public async Task<IActionResult> GetOwnerExternal(string ownerEmail, CancellationToken cancellationToken)
        {
            var owner = await getOwnerExternalCommandHandler.HandleAsync(ownerEmail, cancellationToken);

            return Ok(owner);
        }

        [HttpGet("viewRescuableAnimals")]
        [Authorize("FosterAccess")]
        public async Task<IActionResult> ViewRescuableAnimals( CancellationToken cancellationToken)
        {
            var animals = await viewRescuableAnimalsCommandHandler.HandleAsync(cancellationToken);

            return Ok(animals);
        }

        [HttpPut("updateOwner")]
        [Authorize("OwnerAccess")]
        public async Task<IActionResult> UpdateOwner([FromBody] UpdateOwnerDto command, CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            await updateOwnerCommandHandler.HandleAsync(command, identityId, cancellationToken);

            return NoContent();
        }

        [HttpGet("getOwnerSpecificAnimal")]
        [Authorize]
        public async Task<IActionResult> GetOwnerSpecificAnimal([FromQuery]string ownerEmail, [FromQuery]string animalName, [FromQuery]string animalType, [FromQuery]int animalAge, CancellationToken cancellationToken)
        {
            var animal = await getOwnerSpecificAnimalCommandHandler.HandleAsync(new GetOwnerSpecificAnimalCommandRequirements(ownerEmail, animalName, animalType, animalAge), cancellationToken);

            return Ok(animal);
        }

        [HttpGet("getOwnerSpecificAnimalByDbId")]
        [Authorize]
        public async Task<IActionResult> GetOwnerSpecificAnimalByDbId([FromQuery] string ownerEmail, [FromQuery] int animalId, CancellationToken cancellationToken)
        {
            var animal = await getOwnerSpecificAnimalByDbIdCommandHandler.HandleAsync(new GetOwnerSpecificAnimalByDbIdCommandRequirements(ownerEmail, animalId), cancellationToken);

            return Ok(animal);
        }

        [HttpPut("updateOwnerSpecificAnimal")]
        [Authorize("OwnerAccess")]
        public async Task<IActionResult> UpdateOwnerSpecificAnimal([FromBody] UpdateOwnerSpecificAnimalDto command, CancellationToken cancellationToken)
        {
            var identityId = User.GetUserIdentityId();

            if (identityId == null)
            {
                return Unauthorized();
            }

            await updateOwnerSpecificAnimalCommandHandler.HandleAsync(command, identityId, cancellationToken);

            return NoContent();
        }


        //        [HttpDelete("deleteBook/{id}")]
    }
}
