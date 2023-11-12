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
				FechaDevolucion = CalcularDiasEntrega(solicitudPrestamo.TipoUsuario)
			};

			var prestamo = await _prestamoRepository.CrearPrestamo(newPrestamo);

			return new ReservaExitosa
			{
				Id = prestamo.Id,
				FechaDevolucion = prestamo.FechaDevolucion.ToString("MM/dd/yyyy")
			};
		}

		private DateTime CalcularDiasEntrega(TipoUsuarioPrestamo tipoUsuario)
		{
            var weekend = new[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            var fechaDevolucion = DateTime.Now;
            int diasPrestamo = tipoUsuario switch
            {
                TipoUsuarioPrestamo.AFILIADO => 10,
                TipoUsuarioPrestamo.EMPLEADO => 8,
                TipoUsuarioPrestamo.INVITADO => 7,
                _ => -1,
            };

            for (int i = 0; i < diasPrestamo;)
            {
                fechaDevolucion = fechaDevolucion.AddDays(1);
                i = (!weekend.Contains(fechaDevolucion.DayOfWeek)) ? ++i : i;
            }

            return fechaDevolucion;
        }
    }
}

