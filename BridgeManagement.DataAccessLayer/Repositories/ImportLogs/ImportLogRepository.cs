using System.Linq;

using BridgeManagement.DataAccessLayer.Models;

namespace BridgeManagement.DataAccessLayer.Repositories.ImportLogs
{
	public class ImportLogRepository : Repository<ImportLog>, IImportLogRepository
	{
		public ImportLogRepository(BmtContext dbContext)
			: base(dbContext)
		{
		}

		public IQueryable<ImportLog> GetAll(int sessionId)
		{
			var logs = GetAllQueryable().Where(x => x.SessionID == sessionId);
			return logs;
		}
	}
}
