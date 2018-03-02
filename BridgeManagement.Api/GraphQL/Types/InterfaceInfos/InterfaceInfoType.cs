using System.Linq;
using BridgeManagement.Api.GraphQL.Types.SessionInfos;
using BridgeManagement.DataAccessLayer.Models;
using BridgeManagement.DataAccessLayer.Repositories.SessionInfos;
using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.InterfaceInfos
{
	public class InterfaceInfoType : ObjectGraphType<InterfaceInfo>
	{
		public InterfaceInfoType(ISessionInfoRepository sessionInfoRepository)
		{
			Name = nameof(InterfaceInfo);
			Description = "Information about interface.";

			Field(x => x.ID, type: typeof(IntGraphType)).Description("The ID of the Interface.");
			Field(x => x.IntID).Description("Internal identification of the Interface.");
			Field(x => x.Name).Description("The name of the Interface.");
			Field(x => x.InterfaceDirection, type: typeof(InterfaceDirectionEnum)).Description("The direction of the Interface.");
			Field(x => x.SupportsDataLoadingTool).Description("Determines if Interface is supported by Data loading tool.");
			Field(x => x.Version).Description("The version of the Interface.");
			Field(x => x.LastInstallation).Description("The last installation date of the Interface.");
			Field(x => x.Description, true).Description("The description of the Interface.");
			Field(x => x.ObjectIDLabel).Description("The label of the Object ID column of the Interface.");
			Field(x => x.AdditionalInfo1Label, true).Description("The label of the additional info 1 column of the Interface.");
			Field(x => x.AdditionalInfo2Label, true).Description("The label of the additional info 2 column of the Interface.");
			Field(x => x.FileBased).Description("Determines if Interface process data from file or not.");
			Field(x => x.SupportsReprocessing).Description("Determines if Interface supports reprocessing of data.");

			Field<ListGraphType<SessionInfoType>>(
				"Sessions",
				resolve: context =>
				{
					var sessions = sessionInfoRepository.GetInterfaceSessions(context.Source.ID).ToList();
					return sessions;
				});
		}
	}
}
