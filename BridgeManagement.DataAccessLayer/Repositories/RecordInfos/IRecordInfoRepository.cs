using System.Linq;
using BridgeManagement.DataAccessLayer.Models;

namespace BridgeManagement.DataAccessLayer.Repositories.RecordInfos
{
	public interface IRecordInfoRepository : IRepository<RecordInfo>
	{
		IQueryable<RecordInfo> GetAllByInterface(short interfaceId);
		RecordInfo Get(string recordId, int sessionId);
	}
}
