using BridgeManagement.DataAccessLayer.Artificial.StatusDefinitions;

namespace BridgeManagement.DataAccessLayer.Models
{
	public partial class StatusDefinition
	{
		public StatusResult StatusResult => Success.HasValue
			? Success.Value
				? StatusResult.Positive
				: StatusResult.Negative
			: StatusResult.Neutral;
	}
}
