using System.Linq;
using BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations;

namespace BridgeManagement.Api.Extensions
{
	public static class IQueryableExtensions
	{
		public static IQueryable<T> ProjectData<T>(this IQueryable<T> queryable, Projection projection)
		{
			if (projection == null) return queryable;

			projection.Filter?.FilterQuery(ref queryable);

			Sort.SortQuery(ref queryable, projection.Sorts);

			if (projection.Page != null)
			{
				queryable = queryable
					.Skip((projection.Page.Value - 1) * projection.PageSize)
					.Take(projection.PageSize);
			}

			return queryable;
		}
	}
}
