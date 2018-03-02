using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BridgeManagement.DataAccessLayer.Repositories
{
	public abstract class Repository<TEntity> : IRepository<TEntity>
		where TEntity: class
	{
		protected Repository(BmtContext dbContext)
		{
			DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
			DbSet = DbContext.Set<TEntity>();
		}

		#region Properties

		protected BmtContext DbContext { get; }

		protected DbSet<TEntity> DbSet { get; private set; }

		protected static DateTime Deleted => DateTime.UtcNow.AddYears(-100);

		#endregion

		#region Public Methods

		public IQueryable<TEntity> GetAllQueryable()
		{
			return DbSet;
		}

		public IEnumerable<TEntity> GetAll()
		{
			return DbSet.ToList();
		}

		public TEntity GetById(params object[] id)
		{
			return DbSet.Find(id);
		}

		public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
		{
			return DbSet.Where(where).ToList();
		}

		public IEnumerable<TOut> GetMany<TOut>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOut>> columns)
		{
			return DbSet.Where(where).Select(columns);
		}

		#endregion
	}
}
