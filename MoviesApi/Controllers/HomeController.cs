using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoviesApi.Controllers
{
    public class Movie
    {
        public string title { get; set; }
        public string image { get; set; }
        public decimal rating { get; set; }
        public int releaseYear { get; set; }
        public string[] genre { get; set; }
    }
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {

            List<Movie> movie = new List<Movie>();
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://api.androidhive.info/json/movies.json");
            if (response.IsSuccessStatusCode)
            {
                var MovieResponse = response.Content.ReadAsStringAsync().Result;

                movie = JsonConvert.DeserializeObject<List<Movie>>(MovieResponse);
            }
            response.EnsureSuccessStatusCode();
            return View(movie);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}