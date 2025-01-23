using OpenBench.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace OpenBench.Repositories
{
    public abstract class CoreRepository<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        public CoreRepository(TDbContext context)
        {
            this._dbContext = context;
        }

        public async Task<List<TEntity>> GetAllRows()
        {
            try
            {
                return await _dbContext.Set<TEntity>().ToListAsync();
            }
            catch (DbUpdateException e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                throw;
            }

        }

        public async Task<TEntity> GetRowById(int? id)
        {
            try
            {
                return await _dbContext.Set<TEntity>().FindAsync(id);

            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                throw;
            }

        }

        public async Task<TEntity> AddRow(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                throw;
            }
        }

        public async Task<TEntity> UpdateRow(TEntity entity)
        {
            try
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                throw;
            }
        }

        public async Task DeleteRow(int id)
        {
            try
            {

                var entity = GetRowById(id);
                _dbContext.Set<TEntity>().Remove(await entity);
                await _dbContext.SaveChangesAsync();


            }
            catch (DbUpdateException e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                throw;
            }
        }

        public async Task<TEntity> FindRowByCompositeIds(object[] keyValues)
        {
            try
            {
                return await _dbContext.Set<TEntity>().FindAsync(keyValues);

            }
            catch (DbUpdateException e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                throw;
            }
        }
    }
}
