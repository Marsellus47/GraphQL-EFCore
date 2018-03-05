using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations
{
	public class Condition
	{
		public string Column { get; set; }
		public ComparisonOperator ComparisonOperator { get; set; }
		public object Value { get; set; }
		public IEnumerable<Condition> Conditions { get; set; } = new List<Condition>();
		public LogicalOperator ConditionsLogicalOperator { get; set; }

		public void FilterQuery<T>(ref IQueryable<T> queryable)
		{
			if (string.IsNullOrEmpty(Column) && !Conditions.Any()) return;

			queryable = queryable.Where(WhereCondition.Item1, WhereCondition.Item2);
			_argumentNumber = 0;
		}

		public void FilterQuery<T>(ref IEnumerable<T> enumerable)
		{
			if (string.IsNullOrEmpty(Column) && !Conditions.Any()) return;

			enumerable = enumerable.AsQueryable().Where(WhereCondition.Item1, WhereCondition.Item2);
			_argumentNumber = 0;
		}

		private static int _argumentNumber;

		private Tuple<string, object[]> WhereCondition
		{
			get
			{
				var conditions = new List<string>();
				var arguments = new List<object>();

				foreach (var innerCondition in Conditions)
				{
					var innerWhereCondition = innerCondition.WhereCondition;
					conditions.Add(innerWhereCondition.Item1);
					arguments.AddRange(innerWhereCondition.Item2);
				}

				if (!string.IsNullOrEmpty(Column))
				{
					switch (ComparisonOperator)
					{
						case ComparisonOperator.Lower:
							conditions.Add($" ({Column} < @{_argumentNumber}) ");
							break;
						case ComparisonOperator.LowerOrEqual:
							conditions.Add($" ({Column} <= @{_argumentNumber}) ");
							break;
						case ComparisonOperator.Equal:
							conditions.Add($" ({Column} == @{_argumentNumber}) ");
							break;
						case ComparisonOperator.NotEqual:
							conditions.Add($" ({Column} != @{_argumentNumber}) ");
							break;
						case ComparisonOperator.GreaterOrEqual:
							conditions.Add($" ({Column} >= @{_argumentNumber}) ");
							break;
						case ComparisonOperator.Greater:
							conditions.Add($" ({Column} > @{_argumentNumber}) ");
							break;
						case ComparisonOperator.StartsWith:
							conditions.Add($" ({Column}.StartsWith(@{_argumentNumber})) ");
							break;
						case ComparisonOperator.EndsWith:
							conditions.Add($" ({Column}.EndsWith(@{_argumentNumber})) ");
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}

					arguments.Add(Value);
					_argumentNumber++;
				}

				var condition = string.Join(ConditionsLogicalOperator == LogicalOperator.And ? " && " : " || ", conditions);

				return new Tuple<string, object[]>($" ({condition}) ", arguments.ToArray());
			}
		}
	}
}
