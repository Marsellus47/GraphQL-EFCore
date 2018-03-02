using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations
{
	public class SortingDirectionEnum : EnumerationGraphType
	{
		public SortingDirectionEnum()
		{
			Name = nameof(SortingDirection);
			Description = "Sorting direction.";

			AddValue(nameof(SortingDirection.Ascending), "Ascending sort.", SortingDirection.Ascending);
			AddValue(nameof(SortingDirection.Descending), "Descending sort.", SortingDirection.Descending);
		}
	}
}
