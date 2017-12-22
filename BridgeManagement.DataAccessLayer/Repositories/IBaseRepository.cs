using System.Linq;

namespace BridgeManagement.DataAccessLayer.Repositories
{
	public interface IBaseRepository<out TEntity>
		where TEntity: class
    {
	    IQueryable<TEntity> GetAllQueryable();
    }
}
