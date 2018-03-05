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

		public static void SortQuery<T>(ref IEnumerable<T> enumerable, IEnumerable<Sort> sorts)
		{
			IOrderedEnumerable<T> orderedEnumerable = null;
			foreach (var sort in sorts.Reverse())
			{
				if (orderedEnumerable == null)
				{
					orderedEnumerable = sort.SortingDirection == SortingDirection.Ascending
						? enumerable.OrderBy(entity => GetPropertyValue(entity, sort.Column))
						: enumerable.OrderByDescending(entity => GetPropertyValue(entity, sort.Column));
				}
				else
				{
					orderedEnumerable = sort.SortingDirection == SortingDirection.Ascending
						? orderedEnumerable.OrderBy(entity => GetPropertyValue(entity, sort.Column))
						: orderedEnumerable.OrderByDescending(entity => GetPropertyValue(entity, sort.Column));
				}
			}
			enumerable = orderedEnumerable ?? enumerable;
		}

		private static object GetPropertyValue<T>(T entity, string property)
		{
			var propertyInfo = entity.GetType().GetProperty(property);
			return propertyInfo?.GetValue(entity);
		}
	}
}
