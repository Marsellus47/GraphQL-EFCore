using System;
using System.Linq;
using BridgeManagement.Api.Extensions;
using BridgeManagement.Api.GraphQL.Types.InterfaceInfo;
using BridgeManagement.Api.GraphQL.Types.SessionInfo;
using BridgeManagement.Api.GraphQL.Types.Shared.DatabaseOperations;
using BridgeManagement.DataAccessLayer.Repositories.InterfaceInfo;
using BridgeManagement.DataAccessLayer.Repositories.SessionInfo;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace BridgeManagement.Api.GraphQL.Queries
{
	public class BridgeManagementQuery : ObjectGraphType
    {
	    public BridgeManagementQuery(
			IInterfaceInfoRepository interfaceInfoRepository,
			ISessionInfoRepository sessionInfoRepository)
	    {
		    if (interfaceInfoRepository == null)
		    {
			    throw new ArgumentNullException(nameof(interfaceInfoRepository));
			}
		    if (sessionInfoRepository == null)
		    {
			    throw new ArgumentNullException(nameof(sessionInfoRepository));
		    }

			#region Interface Info

			Field<InterfaceInfoType>(
			    "interface",
			    arguments: new QueryArguments(
				    new QueryArgument<NonNullGraphType<IntGraphType>>
				    {
					    Name = "id",
					    Description = "id of the interface"
				    }),
			    resolve: context =>
			    {
				    var id = context.GetArgument<short>("id");
				    return interfaceInfoRepository.Get(id);
			    });

		    Field<ListGraphType<InterfaceInfoType>>(
			    "interfaces",
			    resolve: context => interfaceInfoRepository.GetAllQueryable()
				    .ToListAsync()
				    .Result);

			#endregion

			#region Session Info

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
					    Name = "id",
					    Description = "id of the interface."
				    },
				    new QueryArgument<ProjectionType>
				    {
					    Name = nameof(Projection),
					    Description = "Data projection."
					}),
			    resolve: context =>
			    {
				    var id = context.GetArgument<short>("id");
				    var projection = context.GetArgument<Projection>(nameof(Projection));
					var sessions = sessionInfoRepository
						.GetInterfaceSessions(id)
						.ProjectData(projection);

				    return sessions.ToList();
			    });

			#endregion
		}
    }
}
