using System;
using System.Text.Json.Serialization;

namespace PruebaIngresoBibliotecario.Domain.Dto
{
    public class RespuestaConsultaDto
    {
        [JsonPropertyName("id")]
        public Guid IdPrestamoLibro { get; set; }

        [JsonPropertyName("identificacionUsuario")]
        public string IdUsuarioPrestamoLibro { get; set; }

        [JsonPropertyName("isbn")]
        public Guid IsbnLibroPrestamo { get; set; }

        [JsonPropertyName("tipoUsuario")]
        public int TipoUsuarioServicioBibliteca { get; set; }

        [JsonPropertyName("fechaMaximaDevolucion")]
        public DateTime FechaDevolucionPrestamoLibro { get; set; }
    }
}

