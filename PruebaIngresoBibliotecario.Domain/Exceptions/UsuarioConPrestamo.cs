using System;
namespace PruebaIngresoBibliotecario.Domain.Exceptions
{
	public class UsuarioConPrestamo : Exception
	{
		public UsuarioConPrestamo(string message) : base(message)
		{
		}
	}
}

