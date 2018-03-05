using System.Collections.Generic;
using System.Linq;
using BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations;

namespace BridgeManagement.Api.Extensions
{
	public static class CollectionExtensions
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
		public static IEnumerable<T> ProjectData<T>(this IEnumerable<T> enumerable, Projection projection)
		{
			if (projection == null) return enumerable;

			projection.Filter?.FilterQuery(ref enumerable);

			Sort.SortQuery(ref enumerable, projection.Sorts);

			if (projection.Page != null)
			{
				enumerable = enumerable
					.Skip((projection.Page.Value - 1) * projection.PageSize)
					.Take(projection.PageSize);
			}

			return enumerable;
		}
	}
}
