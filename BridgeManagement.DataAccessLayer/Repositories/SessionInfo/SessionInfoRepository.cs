using System.Linq;

namespace BridgeManagement.DataAccessLayer.Repositories.SessionInfo
{
	public class SessionInfoRepository : BaseRepository<Models.SessionInfo>, ISessionInfoRepository
	{
		public SessionInfoRepository(BmtContext dbContext)
			: base(dbContext) { }

		public Models.SessionInfo Get(int id)
		{
			return GetAllQueryable().SingleOrDefault(x => x.SessionID == id);
		}

		public IQueryable<Models.SessionInfo> GetInterfaceSessions(short id)
		{
			return GetAllQueryable().Where(x => x.InterfaceInfoID == id);
		}
	}
}
