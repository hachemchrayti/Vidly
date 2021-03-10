using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie{ Id=1,Name="Movie1"},
                new Movie{ Id=2,Name="Movie2"}

            };
            return View(movies);
        }

        public ActionResult Random()
        {
            Movie new_movie = new Movie() { Name = "Titanic" };
            return View(new_movie);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + " / " + month);
        }
    }
}