using SchoolProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.InfrastructureBases
{    
    public interface IGenericRepository<T> where T : BaseEntity
    {
        // Reading
        IQueryable<T> GetAll(bool asTracking = false);
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByCriteriaAsync(Expression<Func<T, bool>> criteria, bool asTracking = false);
        IQueryable<T> GetAllByCriteriaAsync(Expression<Func<T, bool>> criteria, bool asTracking = false);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);


        // Writing
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteRangeAsync(IEnumerable<T> entities);

        // Delete
        void HardDelete(T entity);
        Task SoftDeleteAsync(T entity);

        // Update control
        Task UpdateIncludeAsync(T entity, params string[] modifiedProperties);
        Task UpdateExcludeAsync(T entity, params string[] unmodifiedProperties);
        Task UpdateSmartAsync(T entity);

        // Save
        Task SaveChangesAsync();
    }

}
