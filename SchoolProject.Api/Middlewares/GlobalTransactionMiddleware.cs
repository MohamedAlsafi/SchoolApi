using Microsoft.EntityFrameworkCore.Storage;
using SchoolProject.Infrastructure.Data;

namespace SchoolProject.Api.Middlewares
{
    public class GlobalTransactionMiddleware : IMiddleware
    {
        private readonly SchoolDbContext _dbContext;
        public GlobalTransactionMiddleware(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            IDbContextTransaction Transaction = null!;
            try
            {
                Transaction = _dbContext.Database.BeginTransaction();
                await next(context);
                Transaction.Commit();

            }
            catch (Exception)
            {

                Transaction?.Rollback();
                throw;
            }


        }
    }
}
