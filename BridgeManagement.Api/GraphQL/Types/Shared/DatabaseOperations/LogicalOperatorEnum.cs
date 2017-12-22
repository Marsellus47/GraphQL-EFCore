using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations
{
	public class LogicalOperatorEnum : EnumerationGraphType
	{
		public LogicalOperatorEnum()
		{
			Name = nameof(LogicalOperator);
			Description = "Logical operator.";

			AddValue(nameof(LogicalOperator.And), "Conjunction operator - all conditions must be true.", LogicalOperator.And);
			AddValue(nameof(LogicalOperator.Or), "Disjunction operator - at least one condition must be true.", LogicalOperator.Or);
		}
    }
}
