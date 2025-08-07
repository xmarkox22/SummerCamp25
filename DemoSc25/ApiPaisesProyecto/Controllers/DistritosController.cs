using Microsoft.AspNetCore.Mvc;
using ApiPaisesProyecto.Models;
using ApiPaisesProyecto.Entidades;
using ApiPaisesProyecto.Interfaces;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPaisesProyecto.Controllers
{
    [Route("api/distritos")]
    [ApiController]
    public class DistritosController : ControllerBase
    {
        private readonly IRepository<Distrito> _distritoRepo;
        private readonly ILogger<DistritosController> _logger;
        private readonly IMapper _mapper;
        public DistritosController(ILogger<DistritosController> logger,
                                   IRepository<Distrito> distritoRepo,
                                   IMapper mapper)
        {

            _distritoRepo = distritoRepo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistritoDto>>> GetDistritos()
        {
            _logger.LogInformation("Obteniendo lista de distritos");
            var distritos = await _distritoRepo.GetAllAsync();
            if (distritos == null || !distritos.Any())
            {
                _logger.LogWarning("No se encontraron distritos");
                return NotFound("No se encontraron distritos");
            }
            var dtoList = _mapper.Map<List<DistritoDto>>(distritos);
            return Ok(dtoList);
        }

        // GET api/distritos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DistritoDto>> GetDistrito([FromRoute]   int id)
        {
            _logger.LogInformation($"Obteniendo distrito con ID: {id}");
            var distrito = await _distritoRepo.GetByIdAsync(id);
            if (distrito == null)
            {
                _logger.LogWarning($"Distrito con ID: {id} no encontrado");
                return NotFound($"Distrito con ID: {id} no encontrado");
            }
            var dto = _mapper.Map<DistritoDto>(distrito);
            return Ok(dto);
        }

        // POST api/distritos
        [HttpPost]
        public async Task<ActionResult<DistritoDto>> CreateDistrito([FromBody] DistritoCreateDto dto)
        {
            if (dto == null)
            {
                _logger.LogError("Distrito no puede ser nulo");
                return BadRequest("Distrito no puede ser nulo");
            }
            var distrito = _mapper.Map<Distrito>(dto);
            await _distritoRepo.AddAsync(distrito);
            _logger.LogInformation($"Distrito creado con ID: {distrito.Id}");
            var resultDto = _mapper.Map<DistritoDto>(distrito);
            return CreatedAtAction(nameof(GetDistrito), new { id = distrito.Id }, resultDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<DistritoDto>> UpdateDistrito([FromRoute] int id, [FromBody] DistritoUpdateDto dto)
        {
            if (dto == null)
            {
                _logger.LogError("Distrito no puede ser nulo");
                return BadRequest("Distrito no puede ser nulo");
            }
            var distrito = await _distritoRepo.GetByIdAsync(id);
            if (distrito == null)
            {
                _logger.LogWarning($"Distrito con ID: {id} no encontrado");
                return NotFound($"Distrito con ID: {id} no encontrado");
            }
            _mapper.Map(dto, distrito);
            await _distritoRepo.UpdateAsync(distrito);
            var resultDto = _mapper.Map<DistritoDto>(distrito);
            return Ok(resultDto);
        }

        // DELETE api/distritos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistrito([FromRoute] int id)
        {
            _logger.LogInformation($"Eliminando distrito con ID: {id}");
            var distrito = await _distritoRepo.GetByIdAsync(id);
            if (distrito == null)
            {
                _logger.LogWarning($"Distrito con ID: {id} no encontrado");
                return NotFound($"Distrito con ID: {id} no encontrado");
            }
            await _distritoRepo.DeleteAsync(id);
            _logger.LogInformation($"Distrito con ID: {id} eliminado");
            return NoContent();
        }
    }
}
