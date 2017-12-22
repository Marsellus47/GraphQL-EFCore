using BridgeManagement.DataAccessLayer.Artificial.Logging;
using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.Shared
{
	public class LogLevelEnum : EnumerationGraphType
	{
		public LogLevelEnum()
		{
			Name = nameof(LogLevel);
			Description = "The level of the log.";

			AddValue(nameof(LogLevel.SysInfo), "System info", LogLevel.SysInfo);
			AddValue(nameof(LogLevel.Fatal), "Fatal", LogLevel.Fatal);
			AddValue(nameof(LogLevel.Alert), "Alert", LogLevel.Alert);
			AddValue(nameof(LogLevel.Critical), "Critical", LogLevel.Critical);
			AddValue(nameof(LogLevel.Error), "Error", LogLevel.Error);
			AddValue(nameof(LogLevel.Warning), "Warning", LogLevel.Warning);
			AddValue(nameof(LogLevel.Notice), "Notice", LogLevel.Notice);
			AddValue(nameof(LogLevel.Info), "Info", LogLevel.Info);
			AddValue(nameof(LogLevel.Debug), "Debug", LogLevel.Debug);
			AddValue(nameof(LogLevel.Trace), "Trace", LogLevel.Trace);
		}
	}
}
