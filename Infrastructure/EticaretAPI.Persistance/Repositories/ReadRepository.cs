using EticaretAPI.Application.Repositories;
using EticaretAPI.Domain.Entities.Common;
using EticaretAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly EticaretAPIDbContext _context;

        public ReadRepository(EticaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        /*
        public IQueryable<T> GetAll(bool tracking = true)
            => Table;
        */

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        /*
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
            => Table.Where(method)
        */

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        /*
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
            => await Table.FirstOrDefaultAsync(method);

        */

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);

        }
        /*
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
            //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            => await Table.FindAsync(Guid.Parse(id));
        */
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
            

    }
}
