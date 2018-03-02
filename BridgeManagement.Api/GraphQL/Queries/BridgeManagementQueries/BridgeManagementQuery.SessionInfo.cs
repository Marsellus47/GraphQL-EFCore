using System.Linq;

using GraphQL.Types;

using BridgeManagement.DataAccessLayer.Repositories.SessionInfo;
using BridgeManagement.Api.Extensions;
using BridgeManagement.Api.GraphQL.Types.SessionInfo;
using BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations;

namespace BridgeManagement.Api.GraphQL.Queries.BridgeManagementQueries
{
	public partial class BridgeManagementQuery
	{
		private void InitializeSessionInfoQuery(ISessionInfoRepository sessionInfoRepository)
		{
			Field<SessionInfoType>(
				"session",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IntGraphType>>
					{
						Name = "id",
						Description = "id of the session"
					}),
				resolve: context =>
				{
					var id = context.GetArgument<int>("id");
					return sessionInfoRepository.Get(id);
				});

			Field<ListGraphType<SessionInfoType>>(
				"sessions",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IntGraphType>>
					{
						Name = "interfaceId",
						Description = "id of the interface."
					},
					new QueryArgument<ProjectionType>
					{
						Name = nameof(Projection),
						Description = "Data projection."
					}),
				resolve: context =>
				{
					var id = context.GetArgument<short>("interfaceId");
					var projection = context.GetArgument<Projection>(nameof(Projection));
					var sessions = sessionInfoRepository
						.GetInterfaceSessions(id)
						.ProjectData(projection);

					return sessions.ToList();
				});
		}
	}
}
