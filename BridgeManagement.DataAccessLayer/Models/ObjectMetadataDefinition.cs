using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgeManagement.DataAccessLayer.Models
{
	[Table("ObjectMetadataDef", Schema = "HamSFA_Interface")]
	public partial class ObjectMetadataDefinition
	{
		[Key]
		[Column("OMTDD_ID")]
		public short ID { get; set; }
		[Column("II_ID")]
		public short InterfaceInfoID { get; set; }
		[Required]
		[Column("OMTDD_Label")]
		[StringLength(128)]
		public string Label { get; set; }

		public InterfaceInfo InterfaceInfo { get; set; }
		public ICollection<ObjectMetadata> ObjectMetadatas { get; set; }
	}
}
