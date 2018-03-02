using System.Linq;
using BridgeManagement.DataAccessLayer.Models;

namespace BridgeManagement.DataAccessLayer.Repositories.SessionInfos
{
	public class SessionInfoRepository : Repository<SessionInfo>, ISessionInfoRepository
	{
		public SessionInfoRepository(BmtContext dbContext)
			: base(dbContext) { }

		public SessionInfo Get(int id)
		{
			return GetById(id);
		}

		public IQueryable<SessionInfo> GetInterfaceSessions(short id)
		{
			return GetAllQueryable().Where(x => x.InterfaceInfoID == id);
		}
	}
}
