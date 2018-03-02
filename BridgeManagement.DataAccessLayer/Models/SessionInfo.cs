using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgeManagement.DataAccessLayer.Models
{
	[Table("SessionInfo", Schema = "HamSFA_Interface")]
	public partial class SessionInfo
	{
		[Key]
		[Column("SI_SessionID")]
		public int SessionID { get; set; }

		[Column("SI_UserID")]
		public short? UserID { get; set; }

		[Column("SI_JobID")]
		[StringLength(128)]
		public string JobID { get; set; }

		[Column("II_ID")]
		public short InterfaceInfoID { get; set; }

		[Column("SI_FileName")]
		[StringLength(128)]
		public string FileName { get; set; }

		[Required]
		[Column("SI_ObjectType")]
		[StringLength(128)]
		public string ObjectType { get; set; }

		[Column("SI_VerboseLevel")]
		public short SI_VerboseLevel { get; set; }

		[Column("SI_ImportMode")]
		[StringLength(16)]
		public string ImportMode { get; set; }

		[Column("SI_MessageCount")]
		public int? MessageCount { get; set; }

		[Column("SI_SessionStart", TypeName = "datetime")]
		public DateTime SessionStart { get; set; }

		[Column("SI_ValidationStart", TypeName = "datetime")]
		public DateTime? ValidationStart { get; set; }

		[Column("SI_ValidationEnd", TypeName = "datetime")]
		public DateTime? ValidationEnd { get; set; }

		[Column("SI_ImportStart", TypeName = "datetime")]
		public DateTime? ImportStart { get; set; }

		[Column("SI_ImportEnd", TypeName = "datetime")]
		public DateTime? ImportEnd { get; set; }

		[Column("SI_SessionEnd", TypeName = "datetime")]
		public DateTime? SessionEnd { get; set; }

		[Column("SI_Result")]
		public byte? SI_Result { get; set; }

		[Column("SI_ExportDownloaded")]
		public bool? ExportDownloaded { get; set; }

		[Column("SI_StorageFileName")]
		[StringLength(128)]
		public string StorageFileName { get; set; }


		public InterfaceInfo InterfaceInfo { get; set; }

		public ICollection<ImportLog> ImportLogs { get; set; }

		public ICollection<RecordInfo> RecordInfos { get; set; }
	}
}
