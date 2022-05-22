using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Petaway.Api.Features.Status;

[Route("api/v1/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
    public StatusController()
    {
        
    }

    [HttpGet]
    [AllowAnonymous]
    public string GetStatus()
    {
        return "up";
    }
}