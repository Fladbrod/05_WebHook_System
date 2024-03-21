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
        var response = await client.PostAsJsonAsync("https://2fa1fb3d8f11edb548c53444825dc1ca.serveo.net/monitoring/alert", 
            new { url = "https://9d1c8fa74bffaf86790daee462230a57.serveo.net/Integration/receive", password = "1234" });
        var content = await response.Content.ReadAsStringAsync();
        return Ok(new { data = content });
    }
    
    [HttpDelete("alert")]
    public async Task<IActionResult> UnsubscribeAlert()
    {
        var client = _httpClientFactory.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Delete, "https://2fa1fb3d8f11edb548c53444825dc1ca.serveo.net/monitoring/alert")
        {
            Content = JsonContent.Create(new { url = "https://9d1c8fa74bffaf86790daee462230a57.serveo.net/Integration/receive", password = "1234" })
        };
        var response = await client.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        return Ok(new { data = content });
    }

    [HttpPost("access")]
    public async Task<IActionResult> AccessEvent()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.PostAsJsonAsync("https://2fa1fb3d8f11edb548c53444825dc1ca.serveo.net/monitoring/access", new { url = "https://9d1c8fa74bffaf86790daee462230a57.serveo.net/Integration/receive", password = "1234" });
        var content = await response.Content.ReadAsStringAsync();
        return Ok(new { data = content });
    }
    
    [HttpDelete("access")]
    public async Task<IActionResult> UnsubscribeAccess()
    {
        var client = _httpClientFactory.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Delete, "https://2fa1fb3d8f11edb548c53444825dc1ca.serveo.net/monitoring/access")
        {
            Content = JsonContent.Create(new { url = "https://9d1c8fa74bffaf86790daee462230a57.serveo.net/Integration/receive", password = "1234" })
        };
        var response = await client.SendAsync(request);
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