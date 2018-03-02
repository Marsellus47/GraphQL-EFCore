using BridgeManagement.DataAccessLayer.Artificial.Logging;
using BridgeManagement.DataAccessLayer.Artificial.SessionInfos;

namespace BridgeManagement.DataAccessLayer.Models
{
	public partial class SessionInfo
	{
		public LogLevel VerboseLevel => (LogLevel) SI_VerboseLevel;

		public SessionResult SessionResult => SI_Result.HasValue ? (SessionResult) SI_Result : SessionResult.Running;
	}
}
