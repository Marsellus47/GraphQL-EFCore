using BridgeManagement.DataAccessLayer.Artificial.InterfaceInfo;
using GraphQL.Types;

namespace BridgeManagement.Api.GraphQL.Types.InterfaceInfo
{
	public class InterfaceDirectionEnum : EnumerationGraphType
	{
		public InterfaceDirectionEnum()
		{
			Name = nameof(InterfaceDirection);
			Description = "The direction of the Interface.";

			AddValue(nameof(InterfaceDirection.Import), "Import interface", nameof(InterfaceDirection.Import));
			AddValue(nameof(InterfaceDirection.Export), "Export interface", nameof(InterfaceDirection.Export));
		}
	}
}
