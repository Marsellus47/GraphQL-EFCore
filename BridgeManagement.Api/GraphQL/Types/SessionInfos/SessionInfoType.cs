﻿using BridgeManagement.Api.Extensions;
using BridgeManagement.Api.GraphQL.Types.ImportLogs;
using BridgeManagement.Api.GraphQL.Types.InterfaceInfos;
using BridgeManagement.Api.GraphQL.Types.Shared;
using BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations;
using BridgeManagement.DataAccessLayer.Models;
using BridgeManagement.DataAccessLayer.Repositories.ImportLogs;
using BridgeManagement.DataAccessLayer.Repositories.InterfaceInfos;
using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.SessionInfos
{
	public class SessionInfoType : ObjectGraphType<SessionInfo>
	{
		public SessionInfoType(
			IInterfaceInfoRepository interfaceInfoRepository,
			IImportLogRepository importLogRepository)
		{
			Name = nameof(SessionInfo);

			Field(x => x.SessionID).Description("The id of the Session.");
			Field(x => x.UserID, true, typeof(IntGraphType)).Description("The id of the user which started the Session.");
			Field(x => x.JobID, true).Description("The id of the job in which Session has been started.");
			Field(x => x.FileName, true).Description("Name of the file which was processed during Session.");
			Field(x => x.ObjectType).Description("Type of the processed object.");
			Field(x => x.VerboseLevel, type: typeof(LogLevelEnum)).Description("Logging verbose level.");
			Field(x => x.ImportMode, true).Description("Mode of the import.");
			Field(x => x.MessageCount, true, typeof(IntGraphType)).Description("Number of processed messages.");
			Field(x => x.SessionStart).Description("Start time of the Session.");
			Field(x => x.ValidationStart, true, typeof(DateGraphType)).Description("Start time of the validation phase.");
			Field(x => x.ValidationEnd, true, typeof(DateGraphType)).Description("End time of the validation phase.");
			Field(x => x.ImportStart, true, typeof(DateGraphType)).Description("Start time of the import phase.");
			Field(x => x.ImportEnd, true, typeof(DateGraphType)).Description("End time of the import phase.");
			Field(x => x.SessionEnd, true, typeof(DateGraphType)).Description("End time of the Session.");
			Field(x => x.SessionResult, type: typeof(SessionResultEnum)).Description("The result of the Session.");
			Field(x => x.ExportDownloaded, true, typeof(BooleanGraphType)).Description("Determines if export file has been downloaded.");
			Field(x => x.InterfaceInfoID, type: typeof(IntGraphType)).Description("The id of the Interface.");
			Field(x => x.StorageFileName, true).Description("Name of the file with processed data which is stored in blob storage.");

			Field<InterfaceInfoType>(nameof(InterfaceInfo),
				resolve: context => interfaceInfoRepository.Get(context.Source.InterfaceInfoID));

			Field<ListGraphType<ImportLogType>>(
				"ImportLogs",
				arguments: new QueryArguments(
					new QueryArgument<ProjectionType>
					{
						Name = nameof(Projection),
						Description = "Data projection."
					}),
				resolve: context =>
				{
					var projection = context.GetArgument<Projection>(nameof(Projection));
					var logs = importLogRepository.GetAll(context.Source.SessionID).ProjectData(projection);
					return logs;
				});
		}
	}
}
