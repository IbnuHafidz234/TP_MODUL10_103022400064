using Microsoft.AspNetCore.Mvc;

namespace TP_MODUL10_103022400064.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        // List static untuk menyimpan data film secara temporary
        private static List<Film> _dataFilm = new List<Film>
        {
            new Film("Inception", "Christopher Nolan", "2010", "Sci-Fi", "9.0"),
            new Film("Interstellar", "Christopher Nolan", "2014", "Sci-Fi", "8.7"),
            new Film("Parasite", "Bong Joon-ho", "2019", "Thriller", "8.6")
        };

        // a. GET /api/Film
        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return _dataFilm;
        }

        // b. GET /api/Film/{index}
        [HttpGet("{id}")]
        public ActionResult<Film> Get(int id)
        {
            if (id < 0 || id >= _dataFilm.Count) return NotFound();
            return _dataFilm[id];
        }

        // c. POST /api/Film
        [HttpPost]
        public void Post([FromBody] Film film)
        {
            _dataFilm.Add(film);
        }

        // d. DELETE /api/Film/{index}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= _dataFilm.Count) return NotFound();
            _dataFilm.RemoveAt(id);
            return Ok();
        }
    }
}