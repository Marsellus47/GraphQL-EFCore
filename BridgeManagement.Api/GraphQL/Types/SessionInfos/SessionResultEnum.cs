using BridgeManagement.DataAccessLayer.Artificial.SessionInfos;
using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.SessionInfos
{
	public class SessionResultEnum : EnumerationGraphType
	{
		public SessionResultEnum()
		{
			Name = nameof(SessionResult);
			Description = "The result of the Session.";

			AddValue(nameof(SessionResult.ProcessedSuccessfully), "Session has been processed successfully", SessionResult.ProcessedSuccessfully);
			AddValue(nameof(SessionResult.ProcessedWithWarnings), "Session has been processed with warning(s)", SessionResult.ProcessedWithWarnings);
			AddValue(nameof(SessionResult.ProcessedWithErrors), "Session has been processed with error(s)", SessionResult.ProcessedWithErrors);
			AddValue(nameof(SessionResult.Failed), "Session failed", SessionResult.Failed);
			AddValue(nameof(SessionResult.Running), "Session is actually running", SessionResult.Running);
		}
	}
}
