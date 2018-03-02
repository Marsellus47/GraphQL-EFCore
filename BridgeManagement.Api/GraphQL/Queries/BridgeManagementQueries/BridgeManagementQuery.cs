using System;

using GraphQL.Types;

using BridgeManagement.DataAccessLayer.Repositories.InterfaceInfo;
using BridgeManagement.DataAccessLayer.Repositories.SessionInfo;

namespace BridgeManagement.Api.GraphQL.Queries.BridgeManagementQueries
{
	public partial class BridgeManagementQuery : ObjectGraphType
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

			InitializeInterfaceInfoQuery(interfaceInfoRepository);
			InitializeSessionInfoQuery(sessionInfoRepository);
		}
	}
}
