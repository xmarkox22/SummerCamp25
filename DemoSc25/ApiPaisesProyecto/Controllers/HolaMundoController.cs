using ApiPaisesProyecto.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPaisesProyecto.Controllers
{
    [Route("api/holamundo")]
    [ApiController]
    public class HolaMundoController : ControllerBase
    {

        public ISaludo saludo { get; set; }

        public HolaMundoController()
        {
            saludo = new ChineseSaludo();
        }

        [HttpGet]
        public IActionResult Get()
        {

            //ISaludo saludo = new EnglishSaludo();

            // Devuelve un saludo simple
            return Ok(saludo.Saludar("Juan"));
        }

       [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {
            // Crea una instancia del servicio de saludo
            //ISaludo saludo = new EnglishSaludo();
            // Devuelve un saludo personalizado
            return Ok(saludo.Saludar(nombre));
        }

    }
}
