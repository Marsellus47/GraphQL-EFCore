using BridgeManagement.DataAccessLayer.Artificial.ImportLogs;
using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.ImportLogs
{
	public class ProcessingPhaseEnum : EnumerationGraphType
	{
		public ProcessingPhaseEnum()
		{
			Name = nameof(ProcessingPhase);
			Description = "Phase of the processing.";

			AddValue(nameof(ProcessingPhase.Unknown), "Unknown processing phase", nameof(ProcessingPhase.Unknown));
			AddValue(nameof(ProcessingPhase.Staging), "Phase of staging data into staging tables", nameof(ProcessingPhase.Staging));
			AddValue(nameof(ProcessingPhase.Validation), "Phase of validating data", nameof(ProcessingPhase.Validation));
			AddValue(nameof(ProcessingPhase.PrepareData), "Phase of preparing data", nameof(ProcessingPhase.PrepareData));
			AddValue(nameof(ProcessingPhase.Processing), "Phase of processing data", nameof(ProcessingPhase.Processing));
		}
	}
}
