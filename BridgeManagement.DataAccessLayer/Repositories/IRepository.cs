using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BridgeManagement.DataAccessLayer.Repositories
{
	public interface IRepository<TEntity>
		where TEntity: class
	{
		IEnumerable<TEntity> GetAll();

		IQueryable<TEntity> GetAllQueryable();

		TEntity GetById(params object[] id);

		IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);

		IEnumerable<TOut> GetMany<TOut>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOut>> columns);
	}
}
