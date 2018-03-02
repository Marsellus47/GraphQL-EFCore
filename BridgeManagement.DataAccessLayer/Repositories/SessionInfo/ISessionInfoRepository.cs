using System.Linq;

namespace BridgeManagement.DataAccessLayer.Repositories.SessionInfo
{
	public interface ISessionInfoRepository : IBaseRepository<Models.SessionInfo>
	{
		Models.SessionInfo Get(int id);

		IQueryable<Models.SessionInfo> GetInterfaceSessions(short id);
	}
}
