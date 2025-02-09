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
        private readonly ILogger<CoreRepository<TEntity, TDbContext>> _logger;
        public CoreRepository(TDbContext context, ILogger<CoreRepository<TEntity, TDbContext>> logger)
        {
            this._dbContext = context;
            _logger = logger;
        }

        public async Task<List<TEntity>> GetAllRows()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetRowById(int id)
        {
            var found = await _dbContext.Set<TEntity>().FindAsync(id);
            if (found == null)
            {
                throw new KeyNotFoundException($"{typeof(TEntity).Name} with ID {id} was not found");
            }
            return found;

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
                _logger.LogError($"Database update failed: {e.Message}");
                throw new DbUpdateException("An error occurred while updating the database.", e);
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
                _logger.LogError($"Database update failed: {e.Message}");
                throw new DbUpdateException($"An error occurred while updating the entity {typeof(TEntity).Name}.", e);
            }
        }

        public async Task DeleteRow(int id)
        {
            try
            {

                var entity = await _dbContext.Set<TEntity>().FindAsync(id);
                if (entity == null)
                {
                    throw new KeyNotFoundException($"{typeof(TEntity).Name} with ID {id} was not found");
                }
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();


            }
            catch (DbUpdateException e)
            {
                _logger.LogError($"Error deleting entity with ID {id}: {e.Message}");
                throw new DbUpdateException($"An error occurred while deleting the entity {typeof(TEntity).Name}.", e);
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
                _logger.LogError($"Error finding entity: {e.Message}");
                throw new DbUpdateException($"An error occurred while retrieving the entity {typeof(TEntity).Name} with IDs {keyValues}.", e);
            }
        }
    }
}
