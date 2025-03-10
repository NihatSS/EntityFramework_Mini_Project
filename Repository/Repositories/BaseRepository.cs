﻿using Domain.Common;
using Domain.Entities;
using Entity_Framework_Mini_Project.Helper.Exceptions;
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
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(m => m.Id == id);
         
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
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

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
