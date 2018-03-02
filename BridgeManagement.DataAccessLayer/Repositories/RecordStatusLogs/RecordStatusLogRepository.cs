using System.Linq;
using BridgeManagement.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BridgeManagement.DataAccessLayer.Repositories.RecordStatusLogs
{
	public class RecordStatusLogRepository : Repository<RecordStatusLog>, IRecordStatusLogRepository
	{
		public RecordStatusLogRepository(BmtContext dbContext)
			: base(dbContext)
		{
		}

		public IQueryable<RecordStatusLog> GetAllForRecordAndSession(string recordId, int sessionId)
		{
			var logs = GetAllQueryable().Where(x => x.RecordID == recordId && x.SessionID == sessionId)
				.Include(x => x.StatusDefinition);
			return logs;
		}
	}
}
