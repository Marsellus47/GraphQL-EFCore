using System.Linq;
using BridgeManagement.DataAccessLayer.Models;

namespace BridgeManagement.DataAccessLayer.Repositories.SessionInfos
{
	public interface ISessionInfoRepository : IRepository<SessionInfo>
	{
		SessionInfo Get(int id);

		IQueryable<SessionInfo> GetInterfaceSessions(short id);
	}
}
