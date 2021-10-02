using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MinhaAPICore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : MainController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("obtertodos")]
        public IEnumerable<WeatherForecast> ObterTodos()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

        }


        [HttpGet("obtertodos2")]
        public ActionResult<IEnumerable<WeatherForecast>> ObterTodos2()
        {
            var rng = new Random();
            var resultado = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
             .ToArray();


            return CustomReponse(resultado);
        }
    }

    public abstract class MainController : ControllerBase
    {
        protected ActionResult CustomReponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    sucess = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                sucess = false,
                errors = ObterErros()
            });
        }

        public bool OperacaoValida()
        {
            //as minha validações
            return true;
        }

        protected string ObterErros()
        {
            return "";
        }
    }

}
