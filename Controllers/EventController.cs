using _05_WebHook_System_Exposee.Models;
using _05_WebHook_System_Exposee.Services;
using Microsoft.AspNetCore.Mvc;

namespace _05_WebHook_System_Exposee.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly EventService _eventService;

    public EventController(EventService eventService)
    {
        _eventService = eventService;
    }

    [HttpPost("trigger/{eventType}")]
    public async Task<IActionResult> TriggerEvent(EventType eventType, [FromBody] object eventData)
    {
        await _eventService.TriggerEventAsync(eventType, eventData);
        return Ok(new { Message = $"Event '{eventType}' triggered." });
    }
}