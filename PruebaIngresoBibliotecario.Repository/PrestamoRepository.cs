using System;
using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Domain;

namespace PruebaIngresoBibliotecario.Repository
{
	public interface IPrestamoRepository
	{
        bool CheckUserHasNoCurrentLends(string userId);
        Task<Prestamo> CrearPrestamo(Prestamo prestamo);
    }

    public class PrestamoRepository : IPrestamoRepository
    {
        internal PersistenceContext _context;
        internal DbSet<Prestamo> _dbSet;

        public PrestamoRepository(PersistenceContext context)
        {
            _context = context;
            _dbSet = context.Set<Prestamo>();
        }

        public bool CheckUserHasNoCurrentLends(string userId)
        {
            return _dbSet.Where(s => s.UsuarioId == userId).Any();
        }

        public async Task<Prestamo> CrearPrestamo(Prestamo prestamo)
        {
            var newPrestamo = await _dbSet.AddAsync(prestamo);
            await _context.SaveChangesAsync();
            return newPrestamo.Entity;
        }
    }
}

