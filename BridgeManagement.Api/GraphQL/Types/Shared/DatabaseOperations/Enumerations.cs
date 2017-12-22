namespace BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations
{
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
		Contains,
		NotContains,
		StartsWith,
		EndsWith
	}
}
