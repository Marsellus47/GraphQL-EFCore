using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations
{
	public class SortType : InputObjectGraphType
	{
		public SortType()
		{
			Name = nameof(Sort);
			Description = "Sort expression.";

			Field<StringGraphType>(nameof(Sort.Column), "Column name.");
			Field<SortingDirectionEnum>(nameof(Sort.SortingDirection), "Sorting direction.");
		}
    }
}
