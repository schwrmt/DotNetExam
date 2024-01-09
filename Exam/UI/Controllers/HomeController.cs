using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;
using UI.Models;
using System.Net.Http.Json;

namespace UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static readonly HttpClient Client;
        private const string Url = "https://localhost:44390/Battle/Fight";
    public BattleResult Result;
    [BindProperty] public Player Player { get; set; } = new();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public async Task Fight(Player player)
    {
        if (!ModelState.IsValid) return;
        var result = await Client.PostAsJsonAsync(Url, Player);
        Result = await result.Content.ReadFromJsonAsync<BattleResult>();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}