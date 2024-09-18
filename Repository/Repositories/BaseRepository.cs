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
        private readonly DbSet<T> _dbSet;
        public BaseRepository()
        {
            _context = new();
            _dbSet = _context.Set<T>();
        }


        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var response = _dbSet.FirstOrDefault(m => m.Id == id);

            _context.Set<T>().Remove(response);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var datas =  _context.Set<T>().ToList();
            return datas;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task UpdateAsync(int id,T entity)
        {
            var response = await _context.Set<T>().FindAsync(id);
            await _context.SaveChangesAsync();
        }
    }
}
