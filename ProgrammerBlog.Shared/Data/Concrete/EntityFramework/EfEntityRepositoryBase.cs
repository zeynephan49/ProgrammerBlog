using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProgrammerBlog.Shared.Data.Abstract;
using ProgrammerBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerBlog.Shared.Data.Concrete.EntityFramework //Entity Framework için EfEntityRepositoryBase'i kodlamış olduk.Diğer dal classlarımıza burdaki kpdları dağıtırak büyük bir iş yükünden kurtulmuş olacağız.
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;
        private DbContext context;

        public EfEntityRepositoryBase(DbContext _context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Expression<Func<TEntity, bool>> predicate1 = predicate;
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }


        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().CountAsync(predicate);

        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Remove(entity); });
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> querry = _context.Set<TEntity>();
            if (predicate != null)
            {
                querry = querry.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    querry = querry.Include(includeProperty);
                }
            }
            return await querry.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> querry = _context.Set<TEntity>();
            if (predicate != null)
            {
                querry = querry.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    querry = querry.Include(includeProperty);
                }
            }
            return await querry.SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Update(entity); });
        }
    }
}
