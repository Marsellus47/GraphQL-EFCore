using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgeManagement.DataAccessLayer.Models
{
	[Table("RecordInfo", Schema = "HamSFA_Interface")]
	public class RecordInfo
	{
		[Required]
		[Column("RI_RecordID")]
		[StringLength(64)]
		public string RecordID { get; set; }

		[Column("SI_SessionID")]
		public int SessionID { get; set; }

		[Column("RI_Created", TypeName = "datetime")]
		public DateTime Created { get; set; }

		[Column("RI_ReprocessID")]
		public Guid? ReprocessID { get; set; }

		[Column("RI_StorageFileName")]
		[StringLength(128)]
		public string StorageFileName { get; set; }


		public SessionInfo SessionInfo { get; set; }

		public ICollection<RecordStatusLog> RecordStatusLogs { get; set; }
	}
}
