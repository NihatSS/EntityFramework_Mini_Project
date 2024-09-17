using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository()
        {
            _context = new();
            _dbSet = _context.Set<T>();
        }


        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _dbSet.FirstOrDefaultAsync(m => m.Id == id);
            _dbSet.Remove(response);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(int id,T entity)
        {
            var response = await _dbSet.FindAsync(id);
            await _context.SaveChangesAsync();
        }
    }
}
