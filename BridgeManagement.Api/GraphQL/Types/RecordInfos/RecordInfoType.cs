using BridgeManagement.Api.Extensions;
using BridgeManagement.Api.GraphQL.Types.RecordStatusLogs;
using BridgeManagement.Api.GraphQL.Types.SessionInfos;
using BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations;
using BridgeManagement.DataAccessLayer.Models;
using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.RecordInfos
{
	public class RecordInfoType : ObjectGraphType<RecordInfo>
	{
		public RecordInfoType()
		{
			Name = nameof(RecordInfo);
			Description = "Information about record.";

			Field(x => x.RecordID).Description("The ID of the Record.");
			Field(x => x.SessionID).Description("The ID of the Session.");
			Field(x => x.Created).Description("The date of Record creation.");
			Field(x => x.ReprocessID, type: typeof(IdGraphType), nullable: true).Description("The matching ID between reprocessed and reprocessing Record(s).");
			Field(x => x.StorageFileName, true).Description("Name of the file with processed data which is stored in blob storage.");
			Field(x => x.SessionInfo, type: typeof(SessionInfoType));

			Field<ListGraphType<RecordStatusLogType>>(
				"RecordStatusLogs",
				arguments: new QueryArguments(
					new QueryArgument<ProjectionType>
					{
						Name = nameof(Projection),
						Description = "Data projection."
					}),
				resolve: context =>
				{
					var projection = context.GetArgument<Projection>(nameof(Projection));
					var logs = context.Source.RecordStatusLogs.ProjectData(projection);
					return logs;
				});
		}
	}
}
