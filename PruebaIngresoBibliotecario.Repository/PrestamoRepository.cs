using System;
using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Domain;

namespace PruebaIngresoBibliotecario.Repository
{
	public interface IPrestamoRepository
	{
        bool CheckUserHasNoCurrentLends(string userId);
        Task<Usuario> CrearUsuario(Usuario usuario);
        Task<Prestamo> CrearPrestamo(Prestamo prestamo);
        Prestamo GetPrestamo(Guid prestamoId);
        Task<Prestamo> GetPrestamoAsync(Guid prestamoId);
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

        public async Task<Usuario> CrearUsuario(Usuario usuario)
        {
            var newuser = await _context.Set<Usuario>().AddAsync(usuario);
            await _context.SaveChangesAsync();
            return newuser.Entity;
        }

        public async Task<Prestamo> CrearPrestamo(Prestamo prestamo)
        {
            var newPrestamo = await _dbSet.AddAsync(prestamo);
            await _context.SaveChangesAsync();
            return newPrestamo.Entity;
        }

        public async Task<Prestamo> GetPrestamoAsync(Guid prestamoId)
        {
            return await _dbSet.FindAsync(prestamoId);
        }

        public Prestamo GetPrestamo(Guid prestamoId)
        {
            return  _dbSet.Where(p => p.Id == prestamoId).Include(p => p.Usuario).FirstOrDefault();
        }
    }
}

