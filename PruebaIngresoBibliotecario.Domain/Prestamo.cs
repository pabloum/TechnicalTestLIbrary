using System.Text.Json.Serialization;

namespace PruebaIngresoBibliotecario.Domain
{
    public class Prestamo
    {
        public Guid Id { get; set; }
        public DateTime FechaDevolucion { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Guid LibroId { get; set; }
        public Libro Libro { get; set; }

    }
}

