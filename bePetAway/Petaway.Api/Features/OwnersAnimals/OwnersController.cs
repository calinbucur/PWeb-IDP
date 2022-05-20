using Petaway.Api.Features.OwnersAnimals.Animal.AddAnimal;
using Petaway.Api.Features.OwnersAnimals.Owner.RegisterOwner;
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

        public OwnersController(
            IAddAnimalCommandHandler addAnimalCommandHandler,
            IRegisterOwnerCommandHandler registerOwnerCommandHandler
            )
        {
            this.addAnimalCommandHandler = addAnimalCommandHandler;
            this.registerOwnerCommandHandler = registerOwnerCommandHandler;
        }

        [HttpPost("addAnimal")]
        //[Authorize] //(Policy = "OwnerAccess")
        public async Task<IActionResult> AddBookAsync(AddAnimalCommand command, CancellationToken cancellationToken)
        {

            await addAnimalCommandHandler.HandleAsync(command, command.OwnerId, cancellationToken);

            return StatusCode((int)HttpStatusCode.Created);
        }


        [HttpPost("registerOwner")]
        //[Authorize] //(Policy = "OwnerAccess")
        public async Task<IActionResult> RegisterOwnerAsync(RegisterOwnerCommand command, CancellationToken cancellationToken)
        {

            await registerOwnerCommandHandler.HandleAsync(command, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created);
        }



        //        [HttpGet("viewAllBooks")]
        //        [HttpDelete("deleteBook/{id}")]
    }
}
