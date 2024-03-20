using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace _05_WebHook_System_Exposee.Controllers;

[ApiController]
[Route("[controller]")]
public class IntegrationController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public IntegrationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpPost("alert")]
    public async Task<IActionResult> AlertEvent()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.PostAsJsonAsync("https://webhookappkea.azurewebsites.net/monitoring/alert", new { url = "https://164ad82f53a35193703ddc0dcaff6eab.serveo.net/Monitoring/receive\n", password = "1234" });
        var content = await response.Content.ReadAsStringAsync();
        return Ok(new { data = content });
    }

    [HttpPost("access")]
    public async Task<IActionResult> AccessEvent()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.PostAsJsonAsync("https://webhookappkea.azurewebsites.net/monitoring/access", new { url = "https://164ad82f53a35193703ddc0dcaff6eab.serveo.net/Monitoring/receive\n", password = "1234" });
        var content = await response.Content.ReadAsStringAsync();
        return Ok(new { data = content });
    }

    [HttpPost("receive")]
    public async Task<IActionResult> ReceiveWebhook()
    {
        using var reader = new StreamReader(Request.Body, Encoding.UTF8);
        var body = await reader.ReadToEndAsync();
        Console.WriteLine(body);
        return Ok();
    }
}