using BridgeManagement.DataAccessLayer.Models;

namespace BridgeManagement.DataAccessLayer.Repositories.InterfaceInfos
{
	public class InterfaceInfoRepository : Repository<InterfaceInfo>, IInterfaceInfoRepository
	{
		public InterfaceInfoRepository(BmtContext dbContext)
			: base(dbContext) { }

		public InterfaceInfo Get(short id)
		{
			return GetById(id);
		}
	}
}
