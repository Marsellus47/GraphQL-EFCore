using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgeManagement.DataAccessLayer.Models
{
	[Table("ProcessedObject", Schema = "HamSFA_Interface")]
	public class ProcessedObject
	{
		[Column("SI_SessionID")]
		public int SessionID { get; set; }

		[Required]
		[Column("RI_RecordID")]
		[StringLength(64)]
		public string RecordID { get; set; }

		[Required]
		[Column("PO_ObjectID")]
		[StringLength(128)]
		public string ObjectID { get; set; }

		[Column("PO_ObjectResult")]
		public byte ObjectResult { get; set; }


		public SessionInfo SessionInfo { get; set; }

		public RecordInfo RecordInfo { get; set; }
	}
}
