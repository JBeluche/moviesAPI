using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using MoviesAPI.Entities;
using MoviesAPI.Filters;
using MoviesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly ILogger<GenresController> logger;

        public GenresController(IRepository repository, ILogger<GenresController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        [HttpGet("list")]
        [HttpGet("/allgenres")]
        [ServiceFilter(typeof(MyActionFilter))]
        //[ResponseCache(Duration = 60)]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            logger.LogInformation("Getting all genres");
            return await repository.GetAllGenres();
        }

        [HttpGet("{Id:int}")]
        public ActionResult<Genre> Get(int Id, [BindRequired] string param2)
        {
            logger.LogWarning($"Getting {Id}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }    
            var genre = repository.GetGenreById(Id);

            if(genre == null)
            {
                throw new ApplicationException();
                return NotFound();
            }

            return genre;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genre genre)
        {
            repository.AddGenre(genre);
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genre genre)
        {
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
             return NoContent();
        }
    }
}
