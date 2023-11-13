using System.Text.Json.Serialization;

namespace PruebaIngresoBibliotecario.Domain
{
    public class Reserva
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("isbn")]
        public Guid Isbn { get; set; }

        [JsonPropertyName("identificacionUsuario")]
        public string IdentificacionUsuario { get; set; }

        [JsonPropertyName("tipoUsuario")]
        public int TipoUsuario { get; set; }

        [JsonPropertyName("fechaMaximaDevolucion")]
        public string FechaDevolucion { get; set; }
    }
}

