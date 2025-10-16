using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entites;
using SchoolProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.InfrastructureBases
{

    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
       
        protected readonly DbSet<T> _dbSet;
        private readonly SchoolDbContext _context;

        public GenericRepository(SchoolDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
           
        }

        #region Reading

        public IQueryable<T> GetAll(bool asTracking = false)
            => asTracking ? _dbSet.AsTracking() : _dbSet.AsNoTracking();

        public async Task<T?> GetByIdAsync(int id)
            => await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id && !x.Deleted);

        public async Task<T?> GetByCriteriaAsync(Expression<Func<T, bool>> criteria, bool asTracking = false)
            => await (asTracking ? _dbSet.AsTracking() : _dbSet.AsNoTracking())
                    .FirstOrDefaultAsync(criteria);

        public IQueryable<T> GetAllByCriteriaAsync(Expression<Func<T, bool>> criteria, bool asTracking = false)
        {
            var query = asTracking ? _dbSet.AsQueryable() : _dbSet.AsNoTracking();
            return query.Where(criteria);
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        => await _dbSet.AnyAsync(predicate, cancellationToken);

        #endregion

        #region Writing

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
            => await _dbSet.AddRangeAsync(entities);

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
            => _dbSet.RemoveRange(entities);

        #endregion

        #region Delete

        public void HardDelete(T entity)
            => _dbSet.Remove(entity);

        public async Task SoftDeleteAsync(T entity)
        {
            entity.Deleted = true;
            await UpdateIncludeAsync(entity, nameof(BaseEntity.Deleted));
        }

        #endregion

        #region Update Control

        public async Task UpdateIncludeAsync(T entity, params string[] modifiedProperties)
        {
            var localEntity = _dbSet.Local.FirstOrDefault(e => e.ID == entity.ID);
            var entry = localEntity is null
                ? _context.Entry(entity)
                : _context.ChangeTracker.Entries<T>().First(x => x.Entity.ID == entity.ID);

            foreach (var prop in modifiedProperties)
            {
                var propertyInfo = entity.GetType().GetProperty(prop);
                if (propertyInfo is not null)
                {
                    var value = propertyInfo.GetValue(entity);
                    entry.Property(prop).CurrentValue = value;
                    entry.Property(prop).IsModified = true;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateExcludeAsync(T entity, params string[] unmodifiedProperties)
        {
            var localEntity = _dbSet.Local.FirstOrDefault(e => e.ID == entity.ID);
            var entry = localEntity is null
                ? _context.Entry(entity)
                : _context.ChangeTracker.Entries<T>().First(x => x.Entity.ID == entity.ID);

            foreach (var prop in entry.Properties)
            {
                if (!unmodifiedProperties.Contains(prop.Metadata.Name))
                {
                    var value = entity.GetType().GetProperty(prop.Metadata.Name)?.GetValue(entity);
                    prop.CurrentValue = value;
                    prop.IsModified = true;
                }
            }

            await _context.SaveChangesAsync();
        }

        #endregion

        #region Save

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();

       
        #endregion
    }


}
