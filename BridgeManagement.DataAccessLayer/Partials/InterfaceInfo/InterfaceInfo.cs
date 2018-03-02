using System;
using BridgeManagement.DataAccessLayer.Artificial.InterfaceInfos;

namespace BridgeManagement.DataAccessLayer.Models
{
	public partial class InterfaceInfo
	{
		public InterfaceDirection InterfaceDirection => Enum.Parse<InterfaceDirection>(II_Direction);
	}
}
