using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgeManagement.DataAccessLayer.Models
{
	[Table("ImportLog", Schema = "HamSFA_Interface")]
	public partial class ImportLog
	{
		[Column("SI_SessionID")]
		public int SessionID { get; set; }

		[Column("IL_ItemID")]
		public int ItemID { get; set; }

		[Column("IL_RecordID")]
		public int? RecordID { get; set; }

		[Column("IL_ObjectID")]
		[StringLength(128)]
		public string ObjectID { get; set; }

		[Column("IL_ExternalID2")]
		[StringLength(128)]
		public string AdditionalInfo1 { get; set; }

		[Column("IL_ExternalID3")]
		[StringLength(128)]
		public string AdditionalInfo2 { get; set; }

		[Column("IL_ImportPhase")]
		public short IL_ProcessingPhase { get; set; }

		[Required]
		[Column("IL_LogMessage")]
		public string LogMessage { get; set; }

		[Column("IL_LogSeverity")]
		public short IL_LogSeverity { get; set; }

		[Column("IL_TimeStamp", TypeName = "datetime")]
		public DateTime TimeStamp { get; set; }


		public SessionInfo SessionInfo { get; set; }
	}
}
