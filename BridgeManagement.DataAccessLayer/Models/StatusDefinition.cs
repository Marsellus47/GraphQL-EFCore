using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgeManagement.DataAccessLayer.Models
{
	[Table("StatusDefinition", Schema = "HamSFA_Interface")]
	public partial class StatusDefinition
	{
		[Key]
		[Column("SD_ID")]
		public short StatusDefinitionID { get; set; }

		[Required]
		[Column("SD_IntID")]
		[StringLength(64)]
		public string InternalID { get; set; }

		[Column("SD_ExtID")]
		[StringLength(64)]
		public string ExternalID { get; set; }

		[Column("SD_Success")]
		[StringLength(64)]
		public bool? Success { get; set; }

		[Column("SD_Description")]
		[StringLength(255)]
		public string Description { get; set; }

		public ICollection<RecordStatusLog> RecordStatusLogs { get; set; }
	}
}
