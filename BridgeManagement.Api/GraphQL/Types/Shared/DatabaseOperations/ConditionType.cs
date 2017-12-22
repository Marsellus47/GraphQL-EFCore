using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations
{
	public class ConditionType : InputObjectGraphType
	{
		public ConditionType()
		{
			Name = nameof(Condition);
			Description = "Condition which must be true.";

			Field<StringGraphType>(nameof(Condition.Column), "Condition column.");
			Field<ComparisonOperatorEnum>(nameof(Condition.ComparisonOperator), "Comparison operator.");
			Field<ListGraphType<ConditionType>>(nameof(Condition.Conditions), "Sub conditions.");
			Field<LogicalOperatorEnum>(nameof(Condition.ConditionsLogicalOperator), "Logical operator between sub conditions.");
			Field<StringGraphType>(nameof(Condition.Value), "Condition value.");
		}
	}
}
