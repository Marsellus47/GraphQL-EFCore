namespace BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations
{
	public enum SortingDirection
	{
		Ascending = 0,
		Descending
	}

	public enum LogicalOperator
	{
		And,
		Or
	}

	public enum ComparisonOperator
	{
		Lower,
		LowerOrEqual,
		Equal,
		NotEqual,
		GreaterOrEqual,
		Greater,
		StartsWith,
		EndsWith
	}
}
