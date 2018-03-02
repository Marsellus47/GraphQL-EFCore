using BridgeManagement.DataAccessLayer.Artificial.ImportLog;
using BridgeManagement.DataAccessLayer.Artificial.Logging;

namespace BridgeManagement.DataAccessLayer.Models
{
	public partial class ImportLog
	{
		public ProcessingPhase ProcessingPhase => (ProcessingPhase) IL_ProcessingPhase;

		public LogLevel LogSeverity => (LogLevel) IL_LogSeverity;
	}
}
