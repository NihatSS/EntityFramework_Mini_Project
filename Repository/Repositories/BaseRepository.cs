using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public BaseRepository()
        {
            _context = new();
        }


        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _context.Set<T>().FirstOrDefaultAsync(m => m.Id == id);
            _context.Set<T>().Remove(response);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var datas = await _context.Set<T>().ToListAsync();
            return datas;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(int id,T entity)
        {
            var response = await _context.Set<T>().FindAsync(id);
            await _context.SaveChangesAsync();
        }
    }
}
