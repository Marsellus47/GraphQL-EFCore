using System.Linq;
using BridgeManagement.DataAccessLayer.Models;

namespace BridgeManagement.DataAccessLayer.Repositories.RecordStatusLogs
{
	public interface IRecordStatusLogRepository : IRepository<RecordStatusLog>
	{
		IQueryable<RecordStatusLog> GetAllForRecordAndSession(string recordId, int sessionId);
	}
}
