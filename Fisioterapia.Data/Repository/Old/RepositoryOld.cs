using Fisioterapia.Core.Data.Old;
using Fisioterapia.Core.DomainObjects.Old;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Data.Repository.Old
{
    public abstract class RepositoryOld<TEntity> : IRepositoryOld<TEntity> where TEntity : EntityOld, new()
    {
        protected readonly FisioterapiaDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected RepositoryOld(FisioterapiaDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
