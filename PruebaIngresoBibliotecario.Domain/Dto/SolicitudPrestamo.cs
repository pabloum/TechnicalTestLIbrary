using System;
using System.Text.Json.Serialization;

namespace PruebaIngresoBibliotecario.Domain
{
    public class SolicitudPrestamo
	{
        [JsonPropertyName("tipoDeUsuario")]
        public TipoUsuarioPrestamo TipoUsuario { get; set; }

        [JsonPropertyName("identificacionUsuario")]
		public string IdentificacionUsuario { get; set; }

        [JsonPropertyName("isbn")]
		public Guid Isbn { get; set; }
    }

    public class ReservaExitosa
    {
        public Guid Id { get; set; }
        public string FechaDevolucion { get; set; }
    }
}

