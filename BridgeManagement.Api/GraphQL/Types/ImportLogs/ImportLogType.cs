using BridgeManagement.Api.GraphQL.Types.SessionInfos;
using BridgeManagement.Api.GraphQL.Types.Shared;
using BridgeManagement.DataAccessLayer.Models;
using BridgeManagement.DataAccessLayer.Repositories.SessionInfos;
using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.ImportLogs
{
	public class ImportLogType : ObjectGraphType<ImportLog>
	{
		public ImportLogType(ISessionInfoRepository sessionInfoRepository)
		{
			Name = nameof(ImportLog);
			Description = "Interface log.";

			Field(x => x.SessionID, type: typeof(IntGraphType)).Description("The ID of the Session.");
			Field(x => x.ItemID, type: typeof(IntGraphType)).Description("Interface log row number.");
			Field(x => x.RecordID, type: typeof(IntGraphType), nullable: true).Description("The ID of the Record.");
			Field(x => x.ObjectID, nullable: true).Description("The ID of the Object.");
			Field(x => x.AdditionalInfo1, nullable: true).Description("The ID of the first Additional info.");
			Field(x => x.AdditionalInfo2, nullable: true).Description("The ID of the second Additional info.");
			Field(x => x.ProcessingPhase, type: typeof(ProcessingPhaseEnum)).Description("Phase of the processing during which message has been logged.");
			Field(x => x.LogMessage).Description("Logged message.");
			Field(x => x.LogSeverity, type: typeof(LogLevelEnum)).Description("Severity of the logged message.");
			Field(x => x.TimeStamp, type: typeof(DateGraphType)).Description("Time when message has been logged.");

			Field<SessionInfoType>(nameof(SessionInfo),
				resolve: context => sessionInfoRepository.Get(context.Source.SessionID));
		}
	}
}
