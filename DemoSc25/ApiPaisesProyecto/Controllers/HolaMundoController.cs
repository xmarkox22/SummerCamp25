using ApiPaisesProyecto.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPaisesProyecto.Controllers
{
    [Route("api/holamundo")]
    [ApiController]
    public class HolaMundoController : ControllerBase
    {

        private ISaludo _saludo;

        public HolaMundoController(ISaludo saludo)
        {
            //_saludo = new ChineseSaludo();
            _saludo = saludo; // Inyección de dependencia   
        }

        [HttpGet]
        public IActionResult Get()
        {

            //ISaludo _saludo = new EnglishSaludo();

            // Devuelve un _saludo simple
            return Ok(_saludo.Saludar("Juan"));
        }

       [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {
            // Crea una instancia del servicio de _saludo
            //ISaludo _saludo = new EnglishSaludo();
            // Devuelve un _saludo personalizado
            return Ok(_saludo.Saludar(nombre));
        }

    }
}
