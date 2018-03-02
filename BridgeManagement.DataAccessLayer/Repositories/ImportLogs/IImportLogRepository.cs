using System.Linq;
using BridgeManagement.DataAccessLayer.Models;

namespace BridgeManagement.DataAccessLayer.Repositories.ImportLogs
{
	public interface IImportLogRepository : IRepository<ImportLog>
	{
		IQueryable<ImportLog> GetAll(int sessionId);
	}
}
