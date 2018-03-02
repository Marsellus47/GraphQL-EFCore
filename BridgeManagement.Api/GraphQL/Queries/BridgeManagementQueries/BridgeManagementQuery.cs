using System;

using GraphQL.Types;

using BridgeManagement.DataAccessLayer.Repositories.InterfaceInfos;
using BridgeManagement.DataAccessLayer.Repositories.RecordInfos;
using BridgeManagement.DataAccessLayer.Repositories.SessionInfos;

namespace BridgeManagement.Api.GraphQL.Queries.BridgeManagementQueries
{
	public partial class BridgeManagementQuery : ObjectGraphType
	{
		public BridgeManagementQuery(
			IInterfaceInfoRepository interfaceInfoRepository,
			ISessionInfoRepository sessionInfoRepository,
			IRecordInfoRepository recordInfoRepository)
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
			InitializeRecordInfoQuery(recordInfoRepository);
		}
	}
}
