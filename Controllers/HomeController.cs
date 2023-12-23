using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly HttpClient _httpClient;

    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("API");
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("/api/yourEndpoint");
        // Handle the response, e.g., deserialize JSON, error handling, etc.

        return View();
    }

    // Other actions
}
