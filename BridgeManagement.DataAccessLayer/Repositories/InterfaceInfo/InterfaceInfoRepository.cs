using System.Linq;

namespace BridgeManagement.DataAccessLayer.Repositories.InterfaceInfo
{
	public class InterfaceInfoRepository : BaseRepository<Models.InterfaceInfo>, IInterfaceInfoRepository
	{
		public InterfaceInfoRepository(BmtContext dbContext)
			: base(dbContext) { }

		public Models.InterfaceInfo Get(short id)
		{
			return GetAllQueryable().SingleOrDefault(x => x.ID == id);
		}
	}
}
