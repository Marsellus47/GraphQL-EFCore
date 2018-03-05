using System.Linq;
using BridgeManagement.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BridgeManagement.DataAccessLayer.Repositories.RecordInfos
{
	public class RecordInfoRepository : Repository<RecordInfo>, IRecordInfoRepository
	{
		public RecordInfoRepository(BmtContext dbContext)
			: base(dbContext)
		{
		}

		public IQueryable<RecordInfo> GetAllByInterface(short interfaceId, params string[] includes)
		{
			var records = GetAllQueryable(includes).Where(x => x.SessionInfo.InterfaceInfoID == interfaceId);
			return records;
		}

		public RecordInfo Get(string recordId, int sessionId)
		{
			var record = GetById(recordId, sessionId);
			return record;
		}
	}
}
