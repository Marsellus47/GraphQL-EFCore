using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgeManagement.DataAccessLayer.Models
{
	[Table("RecordStatusLog", Schema = "HamSFA_Interface")]
	public class RecordStatusLog
	{
		[Required]
		[Column("RI_RecordID")]
		[StringLength(64)]
		public string RecordID { get; set; }

		[Column("SI_SessionID")]
		public int SessionID { get; set; }

		[Column("RSL_ID")]
		public long RecordStatusLogID { get; set; }

		[Column("RSL_Date", TypeName = "datetime")]
		public DateTime Date { get; set; }

		[Column("SD_ID")]
		public short StatusDefinitionID { get; set; }


		public RecordInfo RecordInfo { get; set; }

		public StatusDefinition StatusDefinition { get; set; }
	}
}
