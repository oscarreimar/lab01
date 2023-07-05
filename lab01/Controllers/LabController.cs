using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace lab01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<LabController> _logger;

        public LabController(ILogger<LabController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
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

        [Route("AddHistory")]
        public string AddHistory()
        {
            _logger.LogInformation("AddHistory");

            try
            {
                var path = "/var/logs/lab01";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var file = $"{path}/{DateTime.Now.ToString("ddMMyyyy_HH_mm_ss")}.log";

                System.IO.File.WriteAllText(file, "Log de pruebas");

                return "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en AddHistory");
                return "ERROR";
            }
        }


    }
}
