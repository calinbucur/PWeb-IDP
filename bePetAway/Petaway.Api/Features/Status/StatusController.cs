using Microsoft.AspNetCore.Mvc;

namespace Petaway.Api.Features.Status;

[ApiController]
[Route("api/v1/[controller]")]
public class StatusController : ControllerBase
{
    public StatusController()
    {
        
    }
    
    public string GetStatus()
    {
        return "up";
    }
}