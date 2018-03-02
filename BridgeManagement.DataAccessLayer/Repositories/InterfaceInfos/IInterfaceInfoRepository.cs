using BridgeManagement.DataAccessLayer.Models;

namespace BridgeManagement.DataAccessLayer.Repositories.InterfaceInfos
{
	public interface IInterfaceInfoRepository : IRepository<InterfaceInfo>
	{
		InterfaceInfo Get(short id);
	}
}
