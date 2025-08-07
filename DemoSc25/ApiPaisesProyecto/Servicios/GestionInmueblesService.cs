using ApiPaisesProyecto.Entidades;
using ApiPaisesProyecto.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiPaisesProyecto.Servicios
{
    public interface IGestionInmueblesService
    {
        Task<IEnumerable<Apartamento>> ObtenerApartamentosAsync();
        Task<IEnumerable<Edificio>> ObtenerEdificiosAsync();
        Task<IEnumerable<Distrito>> ObtenerDistritosAsync();
        // Puedes agregar más métodos según la lógica de negocio
    }

    public class GestionInmueblesService : IGestionInmueblesService
    {
        private readonly IRepository<Apartamento> _apartamentoRepo;
        private readonly IRepository<Edificio> _edificioRepo;
        private readonly IRepository<Distrito> _distritoRepo;

        public GestionInmueblesService(
            IRepository<Apartamento> apartamentoRepo,
            IRepository<Edificio> edificioRepo,
            IRepository<Distrito> distritoRepo)
        {
            _apartamentoRepo = apartamentoRepo;
            _edificioRepo = edificioRepo;
            _distritoRepo = distritoRepo;
        }

        public async Task<IEnumerable<Apartamento>> ObtenerApartamentosAsync()
            => await _apartamentoRepo.GetAllAsync();

        public async Task<IEnumerable<Edificio>> ObtenerEdificiosAsync()
            => await _edificioRepo.GetAllAsync();

        public async Task<IEnumerable<Distrito>> ObtenerDistritosAsync()
            => await _distritoRepo.GetAllAsync();
    }
}
