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
			queryable = queryable.Where(WhereCondition.Item1, WhereCondition.Item2);
			//queryable = queryable.Where(x => new int?[] { 1, 2 }.Contains((x as DataAccessLayer.Models.SessionInfo).MessageCount));
		}

		private Tuple<string, object[]> WhereCondition
		{
			get
			{
				if (string.IsNullOrEmpty(Column) || Value == null)
				{
					return new Tuple<string, object[]>(string.Empty, null);
				}

				var conditions = new List<string>();
				var arguments = new List<object>();

				foreach (var innerCondition in Conditions)
				{
					var innerWhereCondition = innerCondition.WhereCondition;
					conditions.Add(innerWhereCondition.Item1);
					arguments.Add(innerWhereCondition.Item2);
				}

				switch (ComparisonOperator)
				{
					case ComparisonOperator.Lower:
						conditions.Add($" ({Column} < @0) ");
						break;
					case ComparisonOperator.LowerOrEqual:
						conditions.Add($" ({Column} <= @0) ");
						break;
					case ComparisonOperator.Equal:
						conditions.Add($" ({Column} == @0) ");
						break;
					case ComparisonOperator.NotEqual:
						conditions.Add($" ({Column} != @0) ");
						break;
					case ComparisonOperator.GreaterOrEqual:
						conditions.Add($" ({Column} >= @0) ");
						break;
					case ComparisonOperator.Greater:
						conditions.Add($" ({Column} > @0) ");
						break;
					case ComparisonOperator.Contains:
						conditions.Add(" (1 = 1) ");
						break;
					case ComparisonOperator.NotContains:
						conditions.Add(" (1 = 1) ");
						break;
					case ComparisonOperator.StartsWith:
						conditions.Add($" ({Column}.StartsWith(@0)) ");
						break;
					case ComparisonOperator.EndsWith:
						conditions.Add($" ({Column}.EndsWith(@0)) ");
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				arguments.Add(Value);
				var condition = string.Join(ConditionsLogicalOperator == LogicalOperator.And ? " && " : " || ", conditions);

				return new Tuple<string, object[]>($" ({condition}) ", arguments.ToArray());
			}
		}
	}
}
