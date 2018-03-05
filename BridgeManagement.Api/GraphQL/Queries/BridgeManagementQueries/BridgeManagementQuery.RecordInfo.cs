using BridgeManagement.Api.Extensions;
using BridgeManagement.Api.GraphQL.Types.RecordInfos;
using BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations;
using BridgeManagement.DataAccessLayer.Repositories.RecordInfos;
using GraphQL.Types;
using System.Collections.Generic;

namespace BridgeManagement.Api.GraphQL.Queries.BridgeManagementQueries
{
	public partial class BridgeManagementQuery
	{
		private void InitializeRecordInfoQuery(IRecordInfoRepository recordInfoRepository)
		{
			Field<RecordInfoType>(
				"RecordInfo",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<StringGraphType>>
					{
						Name = "RecordID",
						Description = "id of the record"
					},
					new QueryArgument<NonNullGraphType<IntGraphType>>
					{
						Name = "SessionID",
						Description = "id of the session"
					}),
				resolve: context =>
				{
					var recordId = context.GetArgument<string>("RecordID");
					var sessionId = context.GetArgument<int>("SessionID");
					return recordInfoRepository.Get(recordId, sessionId);
				});

			Field<ListGraphType<RecordInfoType>>(
				"RecordInfos",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IntGraphType>>
					{
						Name = "InterfaceID",
						Description = "id of the interface"
					},
					new QueryArgument<ProjectionType>
					{
						Name = nameof(Projection),
						Description = "Data projection."
					}),
				resolve: context =>
				{
					var interfaceId = context.GetArgument<short>("InterfaceID");
					var projection = context.GetArgument<Projection>(nameof(Projection));

					var selectionSet = context.Operation.SelectionSet;
					var includes = new List<string>();

					if (selectionSet.ContainsSelection("sessionInfo"))
					{
						includes.Add("SessionInfo");
					}
					if (selectionSet.ContainsSelection("recordStatusLogs"))
					{
						includes.Add("RecordStatusLogs");
					}
					if (selectionSet.ContainsSelection("statusDefinition"))
					{
						includes.Add("RecordStatusLogs.StatusDefinition");
					}

					return recordInfoRepository
						.GetAllByInterface(interfaceId, includes.ToArray())
						.ProjectData(projection);
				});
		}
	}
}
