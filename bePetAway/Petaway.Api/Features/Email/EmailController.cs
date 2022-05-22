using Microsoft.AspNetCore.Mvc;
using Petaway.Api.Infrastructure.RabbitMQ;

namespace Petaway.Api.Features.Email;

[Route("api/v1/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    //private IRabbitMQService _rabbitMqService;
    
    //public EmailController(IRabbitMQService rabbitMqService)
    public EmailController()
    {
        //_rabbitMqService = rabbitMqService;
    }
    
    [HttpGet]
    public void SendMail()
    {
        RabbitMQService.sendMail("petaway.test@gmail.com", "Test email", "SUBJECT");
        //_rabbitMqService.sendMail("petaway.test@gmail.com", "TEST EMAIL", "SUBJECT");
    }
}