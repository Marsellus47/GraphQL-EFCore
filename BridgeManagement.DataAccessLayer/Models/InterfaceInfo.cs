using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgeManagement.DataAccessLayer.Models
{
	[Table("InterfaceInfo", Schema = "HamSFA_Interface")]
	public partial class InterfaceInfo
	{
		[Key]
		[Column("II_ID")]
		public short ID { get; set; }

		[Required]
		[Column("II_IntID")]
		[StringLength(128)]
		public string IntID { get; set; }

		[Required]
		[Column("II_Name")]
		[StringLength(128)]
		public string Name { get; set; }

		[Required]
		[Column("II_Direction")]
		[StringLength(6)]
		public string II_Direction { get; set; }

		[Column("II_SupportsDataLoadingTool")]
		public bool SupportsDataLoadingTool { get; set; }

		[Required]
		[Column("II_Version")]
		[StringLength(16)]
		public string Version { get; set; }

		[Column("II_LastInstallation", TypeName = "datetime")]
		public DateTime LastInstallation { get; set; }

		[Column("II_Desc")]
		public string Description { get; set; }

		[Required]
		[Column("II_ObjectIDLabel")]
		[StringLength(128)]
		public string ObjectIDLabel { get; set; }

		[Column("II_ExternalID2Label")]
		[StringLength(128)]
		public string AdditionalInfo1Label { get; set; }

		[Column("II_ExternalID3Label")]
		[StringLength(128)]
		public string AdditionalInfo2Label { get; set; }

		[Column("II_FileBased")]
		public bool FileBased { get; set; }

		[Column("II_SupportsReprocessing")]
		public bool SupportsReprocessing { get; set; }


		public ICollection<SessionInfo> SessionInfos { get; set; }

		public ICollection<ObjectMetadataDefinition> ObjectMetadataDefinitions { get; set; }
	}
}
