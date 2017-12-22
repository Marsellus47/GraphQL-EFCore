using System;
using System.Linq;

namespace BridgeManagement.DataAccessLayer.Repositories
{
	public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
		where TEntity: class
    {
		public BmtContext DbContext { get; }

	    protected BaseRepository(BmtContext dbContext)
	    {
		    DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
	    }

		public IQueryable<TEntity> GetAllQueryable()
		{
			return DbContext.Set<TEntity>();
		}
	}
}
