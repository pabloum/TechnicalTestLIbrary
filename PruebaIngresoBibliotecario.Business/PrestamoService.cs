using PruebaIngresoBibliotecario.Domain;
using PruebaIngresoBibliotecario.Domain.Exceptions;
using PruebaIngresoBibliotecario.Repository;

namespace PruebaIngresoBibliotecario.Business
{
	public interface IPrestamoService
	{
        Task<ReservaExitosa> CreateLend(SolicitudPrestamo solicitudPrestamo);
    }

	public class PrestamoService : IPrestamoService
    {
		private readonly IPrestamoRepository _prestamoRepository;

		public PrestamoService(IPrestamoRepository prestamoRepository)
		{
			_prestamoRepository = prestamoRepository;
		}

        public async Task<ReservaExitosa> CreateLend(SolicitudPrestamo solicitudPrestamo)
		{
			if (_prestamoRepository.CheckUserHasNoCurrentLends(solicitudPrestamo.IdentificacionUsuario))
			{
				var message = $"El usuario con identificacion {solicitudPrestamo.IdentificacionUsuario} ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo";
                throw new UsuarioConPrestamo(message);
			}

			var newPrestamo = new Prestamo
			{
				LibroId = solicitudPrestamo.Isbn,
				UsuarioId = solicitudPrestamo.IdentificacionUsuario,
				FechaDevolucion = DateTime.Now.AddDays(7)
			};

			var prestamo = await _prestamoRepository.CrearPrestamo(newPrestamo);

			return new ReservaExitosa
			{
				Id = prestamo.Id,
				FechaDevolucion = prestamo.FechaDevolucion.ToString()
			};
		}
    }
}

