using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaIngresoBibliotecario.Business;
using PruebaIngresoBibliotecario.Domain;
using PruebaIngresoBibliotecario.Domain.Exceptions;

namespace PruebaIngresoBibliotecario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

    }

    public class PrestamoController : BaseController
    {
        private readonly IPrestamoService _prestamoService;

        public PrestamoController(IPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLend([FromBody]SolicitudPrestamo solicitudPrestamo)
        {
            try
            {
                var prestamo = await _prestamoService.CreateLend(solicitudPrestamo);
                return Ok(prestamo);
            }
            catch (UsuarioConPrestamo ex)
            {
                return BadRequest(new
                {
                    mensaje = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

    }
}
