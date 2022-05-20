using Microsoft.AspNetCore.Mvc;
using Petaway.Api.Infrastructure;

namespace Petaway.Api.Features.Email;

[Route("api/v1/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private IRabbitMQService _rabbitMqService;
    
    public EmailController(IRabbitMQService rabbitMqService)
    {
        _rabbitMqService = rabbitMqService;
    }
    
    [HttpGet]
    public void SendMail()
    {
        _rabbitMqService.sendMail("petaway.test@gmail.com", "TEST EMAIL", "SUBJECT");
    }
}