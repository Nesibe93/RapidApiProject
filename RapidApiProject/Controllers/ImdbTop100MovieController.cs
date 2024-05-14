using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiProject.Models;
using System.Text.Json.Serialization;

namespace RapidApiProject.Controllers
{
    public class ImdbTop100MovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "37a7d71a37msh26fee5c4314fa6dp1d1043jsn0c26a3096c90" }, // Api Keyimiz
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" }, // İstek yapılacak sunucu
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<MovieViewModel>>(body);
                return View(values);
            }
        }
    }
}
