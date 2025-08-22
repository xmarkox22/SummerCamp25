using ApiPaisesProyecto.Contexto;
using ConversorAcme.Api.Entidades;
using ConversorAcme.Api.Servicios;
using Microsoft.EntityFrameworkCore;

namespace ApiPaisesProyecto.Servicios
{
    public class GestionPaisesBBDD : IGestionPaises
    {
        private readonly ContextoApi contextoApi;

        public GestionPaisesBBDD(ContextoApi contextoApi)
        {
            this.contextoApi = contextoApi;
        }
        public void ActualizarPais(Pais pais)
        {
            contextoApi.Paises.Update(pais);
        }

        public void Agregar(Pais pais)
        {
            contextoApi.Paises.Add(pais);
        }

        public void EliminarPais(Pais pais)
        {
            contextoApi.Paises.Remove(pais);
        }

        public async Task<bool> GuardarCambios()
        {
            return await contextoApi.SaveChangesAsync() > 0;
        }

        public async Task<Pais?> ObtenerPorId(int id)
        {

            return await contextoApi.Paises.FirstOrDefaultAsync(pais => pais.Id == id);
        }


        public async Task<List<Pais>> ObtenerTodos()
        {
            return await contextoApi.Paises.ToListAsync();
        }

        // Cambiar la firma para devolver una tupla con la lista y el total de registros
        public async Task<(List<Pais> paises, int totalRegistros)> ObtenerTodosFiltrado(string? idioma, string? nombre, int numeroPagina, int TamañoPagina)
        {
            var consulta = contextoApi.Paises.AsQueryable();

            if (!string.IsNullOrEmpty(idioma))
            {
                idioma = idioma.Trim();
                consulta = consulta.Where(pais => pais.Idioma == idioma);
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                nombre = nombre.Trim();
                consulta = consulta.Where(pais => pais.Nombre.Contains(nombre));
            }

            var totalRegistros = await consulta.CountAsync();

            var paises = await consulta
                .OrderBy(pais => pais.Nombre)
                .Skip((numeroPagina - 1) * TamañoPagina)
                .Take(TamañoPagina)
                .ToListAsync();

            return (paises, totalRegistros);
        }
    }
}
