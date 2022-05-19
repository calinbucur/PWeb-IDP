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
    public string GetStatus()
    {
        return "up";
    }
}