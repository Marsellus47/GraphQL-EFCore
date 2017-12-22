namespace BridgeManagement.DataAccessLayer.Repositories.InterfaceInfo
{
	public interface IInterfaceInfoRepository : IBaseRepository<Models.InterfaceInfo>
    {
	    Models.InterfaceInfo Get(short id);
    }
}
