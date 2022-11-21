using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using TareasMVC.Models;

namespace TareasMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            JsonSerializerOptions optiones = new JsonSerializerOptions() { PropertyNameCaseInsensitive=true};
            using(var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon/ditto");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var pokemon = JsonSerializer.Deserialize<PokemonViewModel>(contenido,optiones);
                    return View(pokemon);
                }
            }
       
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}