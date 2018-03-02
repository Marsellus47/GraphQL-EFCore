using System.Linq;

using GraphQL.Types;

using BridgeManagement.DataAccessLayer.Repositories.SessionInfos;
using BridgeManagement.Api.Extensions;
using BridgeManagement.Api.GraphQL.Types.SessionInfos;
using BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations;

namespace BridgeManagement.Api.GraphQL.Queries.BridgeManagementQueries
{
	public partial class BridgeManagementQuery
	{
		private void InitializeSessionInfoQuery(ISessionInfoRepository sessionInfoRepository)
		{
			Field<SessionInfoType>(
				"Session",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IntGraphType>>
					{
						Name = "ID",
						Description = "id of the session"
					}),
				resolve: context =>
				{
					var id = context.GetArgument<int>("Id");
					return sessionInfoRepository.Get(id);
				});

			Field<ListGraphType<SessionInfoType>>(
				"Sessions",
				arguments: new QueryArguments(
					new QueryArgument<NonNullGraphType<IntGraphType>>
					{
						Name = "InterfaceID",
						Description = "id of the interface."
					},
					new QueryArgument<ProjectionType>
					{
						Name = nameof(Projection),
						Description = "Data projection."
					}),
				resolve: context =>
				{
					var id = context.GetArgument<short>("InterfaceID");
					var projection = context.GetArgument<Projection>(nameof(Projection));
					var sessions = sessionInfoRepository
						.GetInterfaceSessions(id)
						.ProjectData(projection);

					return sessions.ToList();
				});
		}
	}
}
