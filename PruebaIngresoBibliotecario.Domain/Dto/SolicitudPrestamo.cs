using System;
using System.Text.Json.Serialization;

namespace PruebaIngresoBibliotecario.Domain
{
    public class SolicitudPrestamo
	{
        [JsonPropertyName("tipoUsuario")]
        public TipoUsuarioPrestamo TipoUsuario { get; set; }

        [JsonPropertyName("identificacionUsuario")]
		public string IdentificacionUsuario { get; set; }

        [JsonPropertyName("isbn")]
		public Guid Isbn { get; set; }
    }

    public class ReservaExitosa
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("fechaMaximaDevolucion")]
        public string FechaDevolucion { get; set; }
    }
}

