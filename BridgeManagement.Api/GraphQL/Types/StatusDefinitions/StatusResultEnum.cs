using BridgeManagement.DataAccessLayer.Artificial.StatusDefinitions;
using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.StatusDefinitions
{
	public class StatusResultEnum : EnumerationGraphType
	{
		public StatusResultEnum()
		{
			Name = nameof(StatusResult);
			Description = "The result of the Status.";

			AddValue(nameof(StatusResult.Negative), "Negative result", nameof(StatusResult.Negative));
			AddValue(nameof(StatusResult.Neutral), "Neutral result", nameof(StatusResult.Neutral));
			AddValue(nameof(StatusResult.Positive), "Positive result", nameof(StatusResult.Positive));
		}
	}
}
