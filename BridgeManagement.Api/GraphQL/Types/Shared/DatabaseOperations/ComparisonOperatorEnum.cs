using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations
{
	public class ComparisonOperatorEnum : EnumerationGraphType
	{
		public ComparisonOperatorEnum()
		{
			Name = nameof(ComparisonOperator);
			Description = "Comparison operator.";

			AddValue(nameof(ComparisonOperator.Lower), "Left operand has to be lower than right operand.", ComparisonOperator.Lower);
			AddValue(nameof(ComparisonOperator.LowerOrEqual), "Left operand has to be lower than or equal to right operand.", ComparisonOperator.LowerOrEqual);
			AddValue(nameof(ComparisonOperator.Equal), "Left operand has to be equal to right operand.", ComparisonOperator.Equal);
			AddValue(nameof(ComparisonOperator.NotEqual), "Left operand does not have to be equal to right operand.", ComparisonOperator.NotEqual);
			AddValue(nameof(ComparisonOperator.GreaterOrEqual), "Left operand has to be greater than or equal to right operand.", ComparisonOperator.GreaterOrEqual);
			AddValue(nameof(ComparisonOperator.Greater), "Left operand has to be greater than right operand.", ComparisonOperator.Greater);
			AddValue(nameof(ComparisonOperator.StartsWith), "Left operand has to start with right operand.", ComparisonOperator.StartsWith);
			AddValue(nameof(ComparisonOperator.EndsWith), "Left operand has to end with right operand.", ComparisonOperator.EndsWith);
		}
	}
}
