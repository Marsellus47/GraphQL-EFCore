using BridgeManagement.DataAccessLayer.Models;
using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.StatusDefinitions
{
	public class StatusDefinitionType : ObjectGraphType<StatusDefinition>
	{
		public StatusDefinitionType()
		{
			Name = nameof(StatusDefinition);
			Description = "Information about status.";

			Field(x => x.StatusDefinitionID, type: typeof(IntGraphType)).Description("The ID of the Status.");
			Field(x => x.InternalID).Description("The ID of the Status which is known by AFS.");
			Field(x => x.ExternalID, true).Description("The ID of the Status which is known by external system.");
			Field(x => x.StatusResult, type: typeof(StatusResultEnum)).Description("The result of the Status.");
			Field(x => x.Description, true).Description("The description of the Status.");
		}
	}
}
