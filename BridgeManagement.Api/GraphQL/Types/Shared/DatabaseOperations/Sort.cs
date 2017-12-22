using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations
{
	public class Sort
	{
		public string Column { get; set; }
		public SortingDirection SortingDirection { get; set; }

		public static void SortQuery<T>(ref IQueryable<T> queryable, IEnumerable<Sort> sorts)
		{
			IOrderedQueryable<T> orderedQueryable = null;
			foreach (var sort in sorts.Reverse())
			{
				if (orderedQueryable == null)
				{
					orderedQueryable = sort.SortingDirection == SortingDirection.Ascending
						? queryable.OrderBy(entity => EF.Property<object>(entity, sort.Column))
						: queryable.OrderByDescending(entity => EF.Property<object>(entity, sort.Column));
				}
				else
				{
					orderedQueryable = sort.SortingDirection == SortingDirection.Ascending
						? orderedQueryable.ThenBy(entity => EF.Property<object>(entity, sort.Column))
						: orderedQueryable.OrderByDescending(entity => EF.Property<object>(entity, sort.Column));
				}
			}
			queryable = orderedQueryable ?? queryable;
		}
	}
}
