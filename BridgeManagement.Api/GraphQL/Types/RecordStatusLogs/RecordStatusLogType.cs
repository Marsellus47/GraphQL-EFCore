using BridgeManagement.Api.GraphQL.Types.StatusDefinitions;
using BridgeManagement.DataAccessLayer.Models;
using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.RecordStatusLogs
{
	public class RecordStatusLogType : ObjectGraphType<RecordStatusLog>
	{
		public RecordStatusLogType()
		{
			Name = nameof(RecordStatusLog);
			Description = "Changes of record status.";

			Field(x => x.RecordID).Description("The ID of the Record.");
			Field(x => x.SessionID, type: typeof(IntGraphType)).Description("The ID of the Session.");
			Field(x => x.RecordStatusLogID, type: typeof(IntGraphType)).Description("The ID of the Record status log.");
			Field(x => x.Date).Description("Date of the Record status change.");
			Field(x => x.StatusDefinition, type: typeof(StatusDefinitionType)).Description("The status of the Record.");
		}
	}
}
