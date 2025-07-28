using ApiPaisesProyecto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPaisesProyecto.Controllers
{
    /*
     * El archivo ApartamentosController.cs define un controlador vacío 
     * en ASP.NET Core para la API. El controlador se llama ApartamentosController 
     * y hereda de ControllerBase. 
     * Está decorado con los atributos [ApiController] y [Route("api/[controller]")], 
     * lo que indica que manejará solicitudes HTTP en la ruta api/apartamentos.
     * Actualmente, no contiene métodos ni lógica implementada. 
     * Su propósito es servir como punto de entrada 
     * para futuras acciones relacionadas con "apartamentos" en la API.
     */



    [Route("api/apartamentos")]  // Ruta base para el controlador : api/apartamentos
    [ApiController]


    // Nombre del controlador: Apartamentos
    //          ============
    //          Apartamentos Controller          

    public class ApartamentosController : ControllerBase
    {

        // GET: api/apartamentos
        [HttpGet]
        public IActionResult Get()
        {
            // Devuelve una lista de apartamentos simulada
         var lista = new List<ApartamentoDto>
            {
                new ApartamentoDto { Id = 1, Nombre = "Apartamento 1", Ciudad = "Ciudad A" },
                new ApartamentoDto { Id = 2, Nombre = "Apartamento 2", Ciudad = "Ciudad B" },
                new ApartamentoDto { Id = 3, Nombre = "Apartamento 3", Ciudad = "Ciudad C" }
            };

            return Ok(lista);
        }


    }
}
