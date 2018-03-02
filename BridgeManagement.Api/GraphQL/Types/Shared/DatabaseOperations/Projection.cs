using System.Collections.Generic;

namespace BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations
{
	public class Projection
	{
		public int? Page { get; set; }
		public int PageSize { get; set; } = 50;
		public IEnumerable<Sort> Sorts { get; set; } = new List<Sort>();
		public Condition Filter { get; set; }
	}
}
